
// Checkpoint code

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Renderer ColorRenderer;
    private Respawn playerRespawn;
    // Start is called before the first frame update
    void Start()
    {
        playerRespawn = GameObject.Find("Player").GetComponent<Respawn>();
        ColorRenderer = GetComponent<Renderer>();
    }

    // Get checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerRespawn.respawnPoint = transform.position;
            ColorRenderer.material.color = Color.blue;
        }
    }
}