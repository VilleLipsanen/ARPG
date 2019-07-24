using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHero : BaseClass
{

    private int maxHP = 100;
    private float lastStamina = 0.1f;
    private float lastHP = 0.1f;
    public Transform staminaBar;
    public Transform healthBar;
    public bool canRegenStamina = true;
    

    private void Start()
    {
        HP.BaseValue = maxHP;
        Stamina.BaseValue = 100;
        Speed.BaseValue = 10;
        Atk.BaseValue = 10;
        Def.BaseValue = 10;
    }

    public void setRegen(bool regen)
    {
        canRegenStamina = regen;
    }

    private void FixedUpdate()
    {
        if (canRegenStamina && Stamina.BaseValue < 100)
        {
            Stamina.BaseValue += 1;
        }
        if (lastStamina != Stamina.BaseValue) {
            lastStamina = Stamina.BaseValue;
            Stamina.BaseValue = Mathf.Clamp(Stamina.BaseValue, 0, 100);
            Vector3 gona = new Vector3((Stamina.BaseValue / 100), 1, 1);
            staminaBar.localScale = gona;
        }
        if (lastHP != HP.BaseValue)
        {
            lastHP = HP.BaseValue;
            HP.BaseValue = Mathf.Clamp(HP.BaseValue, 0, maxHP);
            Vector3 gona = new Vector3((HP.BaseValue / 100), 1, 1);
            healthBar.localScale = gona;
        }



    }
}
