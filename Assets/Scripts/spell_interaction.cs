using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_interaction : MonoBehaviour

{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<enemy_controller>().takeDamage(damage);
            GameObject.Find("Canvas").GetComponent<ui_handler>().displayDamage(collision.transform.position, damage);
        }

        GameObject.Destroy(this.gameObject);
    }
}
