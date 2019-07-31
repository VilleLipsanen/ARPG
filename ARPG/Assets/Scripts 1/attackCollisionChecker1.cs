using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollisionChecker1 : MonoBehaviour
{
    BaseHero hero;
    private void Start()
    {
        hero = GetComponentInParent<BaseHero>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<HPBehavior>().takeDamage(25 + (int)hero.Atk.BaseValue);
        }
    }
}
