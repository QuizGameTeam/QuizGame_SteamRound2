
// Code to respawn when lose health point

using UnityEngine;
using section;

public class Respawn : MonoBehaviour
{
    private float border = -100;
    private HeartCount HeartCount;
    public gameManager gamemanager;

    // Code for respawning
    public Vector3 respawnPoint;
    public Vector3 resetPoint;

    void Start()
    {
        HeartCount = FindObjectOfType<HeartCount>();
        resetPoint = respawnPoint;
    }

    
    public void RespawnNow() 
    {
        transform.position = respawnPoint; 
    }

    // Take damage and respawn
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Collision with trap
        if (collision.gameObject.tag == "Death")
        {
            RespawnNow();
            HeartCount.TakeDamage(1);
        }
        // Collision with enemy
        if (collision.gameObject.tag == "Enemy")
        {
            RespawnNow();
            Debug.Log("TouchEnemy");
            gamemanager.Ques_Pressed();
            gamemanager.randomques();
            //gamemanager.questionText.text = question;
            //questionText.gameObject.SetActive(true);
        }
    }

    // Respawn when fallings
    void Update()
    {
        if (transform.position.y < border)
        {
            RespawnNow();
            // HeartCount.TakeDamage(1);
        }
    }
}
