
// Code for showing health and calculate health and die function

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using section;

public class HeartCount : MonoBehaviour
{
    private Text HeartNum;
    public float startingHealth = 3;
    private float currentHealth = 3;
    private bool dead = false;
    private GameObject player;
    public ScoreCount ScoreCount;

    public gameManager gamemanager;

    void Start()
    {
        player = GameObject.Find("Player");
        HeartNum = GetComponent<Text>();
        currentHealth = startingHealth;
        ScoreCount = FindObjectOfType<ScoreCount>();
        gamemanager = FindObjectOfType<gameManager>();
        PlayerPrefs.SetInt("Score", ScoreCount.Score);
        
        //gameManager = GameObject.Find("GameoverPanel");
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
        HeartNum.text = " X " + currentHealth.ToString() + " / " + startingHealth.ToString();


        // Dead or not?
        if ( currentHealth <= 0)
        {
            dead = true;
            // Gameover
            if (dead)
            {
                PlayerPrefs.SetInt("Score", ScoreCount.Score);
            
                //gamemanager.GameOver_fi();
                
            }
        }


    }
}