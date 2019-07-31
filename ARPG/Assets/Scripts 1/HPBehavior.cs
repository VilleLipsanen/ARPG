using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBehavior : MonoBehaviour
{

    public int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP <= 0)
            this.gameObject.SetActive(false);
    }

    public void takeDamage(int damage)
    {
        HP -= damage;
    }
}
