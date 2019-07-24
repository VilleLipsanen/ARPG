using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{

    public CharacterStat HP;

    public CharacterStat Stamina;

    public CharacterStat Speed;

    public CharacterStat Mana;

    public CharacterStat Atk;

    public CharacterStat Def;

    public CharacterStat Crit;

    public int Level;
    int Exp;

    public List<BaseAttack> attacks;
    public List<BaseMagic> magics;

}
