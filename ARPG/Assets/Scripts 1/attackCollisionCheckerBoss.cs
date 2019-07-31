using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollisionCheckerBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<BaseHero>().HP.BaseValue -= 20;
        }
    }
}
