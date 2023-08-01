
// Show final score

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    private Text ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = GetComponent<Text>();
        ScoreNum.text = " Score: " + PlayerPrefs.GetInt("Score").ToString();

    }
}
