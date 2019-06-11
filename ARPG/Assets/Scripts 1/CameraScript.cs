using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    public float rotateSpeed = 8f;

    private Vector3 _cameraOffset;

    public bool RotateAroundPlayer = true;
   

    private void Start()
    {
        _cameraOffset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (RotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);

                _cameraOffset = camTurnAngle * _cameraOffset;
            }
        }

        Vector3 newPos = target.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);

        if (RotateAroundPlayer)
        {
            
            transform.LookAt(target);
        }
    }
}