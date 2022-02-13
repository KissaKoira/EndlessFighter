using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    public float health, speed, level, xp, max_xp;
    public bool alive;

    public Vector2 direction;

    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        speed = 100;
        level = 1;
        xp = 0;
        alive = true;

        direction = new Vector2(1, 0);

        panel = GameObject.Find("Panel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            alive = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().isKinematic = true;
            //death animation plays
            panel.SetActive(true);
        }

        if (alive)
        {
            //player controls
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * 0.05f;
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                GetComponent<Rigidbody2D>().velocity *= 0.7f;
            }

            //defines player's direction
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                direction = GetComponent<Rigidbody2D>().velocity.normalized;
            }

            //flips the player sprite based on direction
            if(GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
            }

            //tells animator when player is moving
            if(GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
            {
                GetComponent<Animator>().SetBool("moving", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("moving", false);
            }
        }

        max_xp = level * 100;

        if(xp >= max_xp)
        {
            xp -= max_xp;
            level++;
        }
    }
}