
// Code for showing health and calculate health and die function

using UnityEngine;
using UnityEngine.UI;

public class HeartCount : MonoBehaviour
{
    private Text count;
    public float startingHealth = 3;
    private float currentHealth = 3;
    private bool dead = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        count = GetComponent<Text>();
        currentHealth = startingHealth;
    }

    // Calculate heart
    public void TakeDamage(float damage)
    {
        // Take damage
        currentHealth = currentHealth - damage;
    }
    public void AddHealth(float value)
    {
        if ( currentHealth < startingHealth)
        {
            // Collect heart
            currentHealth = currentHealth + value;
        }
    }

    void Update()
    {
        // Show heart counter
        count.text = " X " + currentHealth.ToString() + " / " + startingHealth.ToString();

        // Dead or not?
        if ( currentHealth <= 0)
        {
            dead = true;
            // Dead
            if (dead)
            {
                Destroy(player);
            }
        }
    }
}