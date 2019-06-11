using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 0.2f, 0.5f) + 1, transform.position.z);
    }
}
