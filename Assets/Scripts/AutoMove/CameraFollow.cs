
// Auto move for camera

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Follow player
    private Transform player;
    [SerializeField] private float aheadDistance = 1;
    [SerializeField] private float cameraSpeed = 1;
    private float lookAhead;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
