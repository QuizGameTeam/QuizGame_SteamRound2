using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform follow;
    [Range(0, 10)]
    [SerializeField] float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 followChar = new Vector3(follow.position.x, follow.position.y, cameraTransform.position.z);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, followChar, cameraSpeed * Time.deltaTime);
    }
}
