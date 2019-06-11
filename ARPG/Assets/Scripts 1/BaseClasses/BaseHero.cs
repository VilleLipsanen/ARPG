using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHero : BaseClass
{

    public void gona()
    {
        this.Atk.BaseValue = 10;
        StatModifier sm = new StatModifier(.2f, StatModType.PercentAdd, this);
        this.Atk.AddModifier(sm);
        this.Atk.AddModifier(sm);
    }

    private void Awake()
    {
        gona();
        Debug.Log(this.Atk.Value);
        foreach (StatModifier sms in Atk.StatModifiers){
            Debug.Log(sms.Source);
        }
        this.Atk.RemoveAllModifiersFromSource(this);
        Debug.Log(this.Atk.Value);
    }

}
