using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bill
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 3f;
        [SerializeField] protected float timeMove = 2f;
        [SerializeField] protected float dir = 1;

        private protected float timeCount;
        private enum EnemyState
        {
            MOVE,
            STANDBY,
            FLIP,
            FALL,
        }
        protected Rigidbody2D rb;
        private EnemyState currentState = EnemyState.MOVE;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            timeCount = timeMove / 2;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            timeCount -= Time.deltaTime;
            Patrol();
            
        }

        protected virtual void Patrol()
        {
            switch (currentState)
            {
                case EnemyState.MOVE:
                    Move();
                    break;
                case EnemyState.STANDBY:
                    Standby();
                    break;
                case EnemyState.FLIP:
                    Flip();
                    break;
                case EnemyState.FALL:
                    FallDown();
                    break;
            }
        }

        protected virtual void Move()
        {
            rb.velocity = new Vector2(moveSpeed * dir, rb.velocity.y);
            if (timeCount <= 0)
            {
                currentState = EnemyState.STANDBY;
                timeCount = timeMove;
            }
        }

        protected virtual void Standby()
        {
            rb.velocity = Vector2.zero;
            
            if (timeCount <= 0)
            {
                currentState = EnemyState.FLIP;
                timeCount = 1f; // Add a delay before starting to move in the opposite direction
            }
        }

        protected virtual void Flip()
        {
            dir = (dir > 0) ? -1 : 1;
            if (transform.localScale.x > 0)
            {
                
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else
            {            
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            currentState = EnemyState.MOVE;
        }
        protected virtual void FallDown() 
        {
            if (rb.velocity.y < 0) 
            {
                currentState = EnemyState.FALL;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
        }
    }
}
