
// Calculate score

using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private Text ScoreNum;
    public int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = GetComponent<Text>();
    }

    public void EarnCoin()
    {
        Score += 200;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreNum.text = " Score: " + Score.ToString();
    }
}
