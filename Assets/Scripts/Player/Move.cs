
// Code to fix moving

using UnityEngine;

public class Move : MonoBehaviour {

    private float horizontal;
    public float maxSpeed = 5f;
    public float accelation = 1f;
    public float deceleration = 1f;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        horizontal *= maxSpeed * Time.deltaTime * accelation ;
        transform.Translate(new Vector3(horizontal, 0f, 0f));
        if (Input.GetKey("Horizontal")) {
            animator.Play("Player_Run");
        }
        

        // Slow down after releasing the button
        if (horizontal == 0f) {
            horizontal -= deceleration * Time.deltaTime;
        }
    }
}
