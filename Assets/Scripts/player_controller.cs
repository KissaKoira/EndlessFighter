using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    public float health, speed;
    private bool alive;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        speed = 100;
        alive = true;

        direction = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            alive = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //death animation plays
        }

        if (alive)
        {
            //player controls
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * 0.05f;

            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                GetComponent<Rigidbody2D>().velocity *= 0.7f;
            }

            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                direction = GetComponent<Rigidbody2D>().velocity.normalized;
            }
        }
    }
}