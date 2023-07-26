using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bill
{
    public class PlayerController : MonoBehaviour
    {
        [Range(0, 10)]
        [SerializeField] private float moveSpeed;
        [Range(0, 20)]
        [SerializeField] private float jumpForce;
        [SerializeField] bool isJumping = false;
        Vector3 moveDir;
        Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Jump();
        }
        private void Movement()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            moveDir = new Vector3(moveSpeed * horizontal, rb.velocity.y);
            rb.velocity = moveDir;
        }
        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // Kiểm tra không nhảy nếu nhân vật đã đang nhảy
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true; // Đánh dấu là nhân vật đã nhảy
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isJumping = false; // Đặt lại biến isJumping khi nhân vật chạm đất
            }
        }
    }
}
