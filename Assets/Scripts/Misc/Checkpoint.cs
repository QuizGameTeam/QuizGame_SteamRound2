using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Respawn playerRespawn;

    // Start is called before the first frame update
    void Start()
    {
        playerRespawn = GameObject.Find("Player").GetComponent<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerRespawn.respawnPoint = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
