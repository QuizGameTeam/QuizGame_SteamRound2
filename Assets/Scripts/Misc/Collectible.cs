
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
    }

    // Make object disapear
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    // Apply bonus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            DestroyGameObject();
            if ( gameObject.tag == "Heart")
            {
                HeartCount.AddHealth(1);
            }
            if ( gameObject.tag == "Coin")
            {
                ScoreCount.EarnCoin();
                Coin = Coin + 1;
            }
        }
    }
}
