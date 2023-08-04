
// Auto move for platforms or enemies

using UnityEngine;

public class LeftRight : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private SpriteRenderer Turning;

    private void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        Turning = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (movingLeft)
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else movingLeft = false;
        else
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else movingLeft = true;
        if ( gameObject.tag == "Enemy")
                {
                    Turning.flipX = movingLeft;
                    
                }
    }
}