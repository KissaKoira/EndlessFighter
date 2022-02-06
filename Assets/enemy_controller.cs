using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public int health, speed, damage;

    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        speed = 70;
        damage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (GameObject.Find("Player").transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed * 0.05f;

        //speed is not constant :(
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject player = GameObject.Find("Player");

        if (collision.gameObject.tag == "Player")
        {
            if (counter <= 0)
            {
                player.GetComponent<player_controller>().health -= damage;

                if(player.GetComponent<player_controller>().health < 0)
                {
                    player.GetComponent<player_controller>().health = 0;
                }

                counter = 0.5f;
            }

            counter -= Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            counter = 0;
        }
    }
}
