using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public float health, speed, damage;
    private GameObject player;

    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (GameObject.Find("Player").transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed * 0.05f;

        //speed is not constant :(

        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }

        if (GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            GetComponent<Animator>().SetBool("moving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("moving", false);
        }

        if (health <= 0)
        {
            player.GetComponent<player_controller>().xp += 10;
            GameObject.Destroy(gameObject);
        }
    }

    public void takeDamage(float inDamage)
    {
        GetComponent<Animator>().SetTrigger("damage");
        health -= inDamage;
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
