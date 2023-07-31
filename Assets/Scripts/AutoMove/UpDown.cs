
// Auto move for platforms or enemies

using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingUp;
    private float upEdge;
    private float downEdge;

    private void Start()
    {
        upEdge = transform.position.y + movementDistance;
        downEdge = transform.position.y - movementDistance;
    }

    private void Update()
    {
        if (movingUp)
            if (transform.position.y < upEdge)
                transform.position = new Vector3(transform.position.x , transform.position.y + speed * Time.deltaTime, transform.position.z);
            else movingUp = false;
        else
            if (transform.position.y > downEdge)
                transform.position = new Vector3(transform.position.x , transform.position.y - speed * Time.deltaTime, transform.position.z);
            else movingUp = true;
    }
}