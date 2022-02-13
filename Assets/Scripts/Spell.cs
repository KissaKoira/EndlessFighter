using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public string name;
    public float damage;
    public float speed;
    public float cooldown;
    public float activeCD;

    public Spell(string aName, float aDamage, float aSpeed, float aCooldown) 
    {
        name = aName;
        damage = aDamage;
        speed = aSpeed;
        cooldown = aCooldown;
        activeCD = cooldown;
    }
}
