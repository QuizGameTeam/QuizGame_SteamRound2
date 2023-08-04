
// Controller for player (fix later)

using UnityEngine;

public class Controller : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;

    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();

        t = transform;
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            animator.SetFloat("Speed", moveDirection);
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f || r2d.velocity.magnitude > -0.01f)
            {
                moveDirection = 0;
                animator.SetFloat("Speed", moveDirection);
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }
    }



    // private void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     if (collision.gameObject.tag == "Ground")
    //     {
            

    //         isGrounded = true;
    //         // Jumping
    //         if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
    //         {
    //             r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
    //             isGrounded = false;
    //         }
    //     }
    // }


    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
        Debug.Log(isGrounded);

       // Jumping
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            isGrounded = false;
        }
        
        animator.SetBool("IsJumping", !isGrounded);

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }
}