using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //Determines the limitations of vertical camera movement
    private const float Y_ANGLE_MIN = 15f;
    private const float Y_ANGLE_MAX = 15f;

    public Transform character; //What the camera is looking at..the main character

    public float distance = -5.0f; // Distance to stay from character, Make sure it is negative
    private float currentX = 0.0f; // Holds value of X mouse movement
    private float currentY = 0.0f; // Holds value of Y mouse movement

    public float camSpeed = 5f;

    void start() { }

    void FixedUpdate()
    {
         if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
         {

            currentX += Input.GetAxis("Mouse X") * camSpeed;
            currentY += Input.GetAxis("Mouse Y") * camSpeed;
        }
        

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {                                                        //Rotation around character............/...Keeps distance from character          
        gameObject.transform.position = character.position + Quaternion.Euler(currentY, currentX, 0) * new Vector3(0, 0, distance);
        gameObject.transform.LookAt(character.position);//Points camera at character
    }
}