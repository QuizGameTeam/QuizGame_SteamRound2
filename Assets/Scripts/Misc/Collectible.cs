
// Collectibles mechanic

using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int Coin = 0;
    private HeartCount HeartCount;
    private ScoreCount ScoreCount;

    void Start()
    {
        HeartCount = FindObjectOfType<HeartCount>();
        ScoreCount = FindObjectOfType<ScoreCount>();
        // ShowCollectible();
    }

    // Make object disapear
    // public void ShowCollectible()
    // {
    //     GameObject.FindGameObjectsWithTag("Coin").SetActive(true);
    // }
    public void HideCollectible()
    {
        gameObject.SetActive(false);
    }

    // Apply bonus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            
            if ( gameObject.tag == "Heart")
            {
                HeartCount.AddHealth(1);
            }
            if ( gameObject.tag == "Coin")
            {
                ScoreCount.EarnCoin();
                Coin = Coin + 1;
            }
            HideCollectible();
        }
    }
}
