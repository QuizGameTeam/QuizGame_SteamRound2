
// Code to respawn when lose health point

using UnityEngine;

public class Respawn : MonoBehaviour
{
    private float border = -100;
    private HeartCount HeartCount;

    void Start()
    {
        HeartCount = FindObjectOfType<HeartCount>();
    }

    // Code for respawning
    public Vector3 respawnPoint;
    public void RespawnNow() 
    {
        HeartCount.TakeDamage(1);
        transform.position = respawnPoint; 
    }

    // Take damage and respawn
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Collision with trap
        if (collision.gameObject.tag == "Death")
        {
            RespawnNow();
        }
        // Collision with enemy
        if (collision.gameObject.tag == "Enemy")
        {
            RespawnNow();
        }
    }

    // Respawn when fallings
    void Update()
    {
        if (transform.position.y < border)
        {
            RespawnNow();
        }
    }
}
