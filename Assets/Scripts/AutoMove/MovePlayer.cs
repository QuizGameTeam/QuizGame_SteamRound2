
// Auto move for player while standing in moving things

using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Moving player along with platformer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    // Stop moving player when player leave platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}