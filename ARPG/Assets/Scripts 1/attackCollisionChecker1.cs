using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollisionChecker1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<HPBehavior>().takeDamage(50);
        }
    }
}
