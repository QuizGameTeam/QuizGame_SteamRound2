
// Collectibles mechanic

using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int Coin = 0;
    private HeartCount HeartCount;

    void Start()
    {
        HeartCount = FindObjectOfType<HeartCount>();
    }


    // Make object disapear
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
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
                Coin = Coin + 1;
            }
        }
    }
}
