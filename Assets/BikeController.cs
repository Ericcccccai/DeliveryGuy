using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of the bike
    public float rotationSpeed = 5f; // Speed of rotation
    public float tiltAmount = 15f; // Amount of tilt
    public float tiltSpeed = 2f; // Speed of tilting

    private Quaternion targetRotation;
    private float targetTilt;

    void Start()
    {
        targetRotation = transform.rotation;
        targetTilt = 0f;
    }

    void Update()
    {
        HandleInput();
        MoveBike();
        RotateAndTiltBike();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            targetRotation = Quaternion.Euler(0, 315, 0); // Facing top-left (315 degrees)
            targetTilt = tiltAmount;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            targetRotation = Quaternion.Euler(0, 45, 0); // Facing top-right (45 degrees)
            targetTilt = -tiltAmount;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            targetRotation = Quaternion.Euler(0, 225, 0); // Facing bottom-left (225 degrees)
            targetTilt = tiltAmount;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            targetRotation = Quaternion.Euler(0, 135, 0); // Facing bottom-right (135 degrees)
            targetTilt = -tiltAmount;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            targetRotation = Quaternion.Euler(0, 0, 0); // Facing upward
            targetTilt = -tiltAmount;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetRotation = Quaternion.Euler(0, 270, 0); // Facing left
            targetTilt = tiltAmount;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetRotation = Quaternion.Euler(0, 180, 0); // Facing downward
            targetTilt = tiltAmount;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetRotation = Quaternion.Euler(0, 90, 0); // Facing right
            targetTilt = -tiltAmount;
        }
        else
        {
            targetTilt = 0f; // Reset tilt when no keys are pressed
        }
    }

    void MoveBike()
    {
        // Get input from the user
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Move the bike forward/backward
        transform.Translate(Vector3.forward * move);
    }

    void RotateAndTiltBike()
    {
        // Smoothly interpolate towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Smoothly interpolate towards the target tilt
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        currentEulerAngles.z = Mathf.LerpAngle(currentEulerAngles.z, targetTilt, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
}
