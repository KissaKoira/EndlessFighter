using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellBar : MonoBehaviour
{
    Vector3 scale;
    private void Start()
    {
        scale = transform.GetChild(1).transform.localScale;
    }

    void Update()
    {
        float cooldown = GameObject.Find("GameController").GetComponent<spell_handler>().spells[0].cooldown;

        transform.GetChild(1).transform.localScale = new Vector3(scale.x * cooldown, scale.y, scale.z);
    }
}
