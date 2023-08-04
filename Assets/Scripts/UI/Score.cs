
// Show final score

using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using section;



public class Score : MonoBehaviour
{
    private Text ScoreNum;
    private gameManager gamemanager;
    private int ScoreFinal;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = GetComponent<Text>();
        gamemanager = FindObjectOfType<gameManager>();
        

    }
    void Update() {
        ScoreFinal = gamemanager.MyScore;
        // ScoreNum.text = " Score: " + PlayerPrefs.GetInt("Score").ToString();
        ScoreNum.text = " Score: " + ScoreFinal.ToString();
    }
}
