using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // The target that the camera will follow
    public Vector3 offset;      // Offset between the camera and the target
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
