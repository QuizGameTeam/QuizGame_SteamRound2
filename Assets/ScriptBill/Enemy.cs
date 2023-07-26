using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bill
{
    public class Enemy : BaseEnemy
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            // Override and set any properties for EnemyA if needed
            moveSpeed = 4f; // For example, setting moveSpeed to 5 for EnemyA
        }
        
    }
}