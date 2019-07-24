using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackHandler1 : MonoBehaviour
{
    public GameObject hitboxHolder;

    private void Start()
    {
        hitboxHolder.SetActive(false);
    }

    public void attackStart()
    {
        hitboxHolder.SetActive(true);
        Invoke("attackEnd", 0.2f);
    }

    public void attackEnd()
    {
        hitboxHolder.SetActive(false);
    }
}
