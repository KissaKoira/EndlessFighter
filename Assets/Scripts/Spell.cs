using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public string name;
    public int speed;
    public float cooldown;

    public Spell(string aName, int aSpeed) 
    {
        name = aName;
        speed = aSpeed;
        cooldown = 0;
    }
}
