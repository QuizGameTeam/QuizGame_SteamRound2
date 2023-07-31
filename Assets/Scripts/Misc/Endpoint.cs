
// End game

using UnityEngine;
using UnityEngine.SceneManagement;


public class Endpoint : MonoBehaviour
{
    public ScoreCount ScoreCount;

    void Start()
    {
        ScoreCount = FindObjectOfType<ScoreCount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("Score", ScoreCount.Score);
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }
}
