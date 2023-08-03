using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using section;


public class Endpoint : MonoBehaviour
{
    public ScoreCount ScoreCount;
    public gameManager gamemanager;

    void Start()
    {
        ScoreCount = FindObjectOfType<ScoreCount>();
        gamemanager = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("Score", ScoreCount.Score);
            gamemanager.GameWin_fi();
        }
    }
}