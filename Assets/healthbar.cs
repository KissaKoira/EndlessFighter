using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    Vector3 scale;
    private void Start()
    {
        scale = transform.GetChild(1).transform.localScale;
    }

    void Update()
    {
        float health = GameObject.Find("Player").GetComponent<player_controller>().health;

        transform.GetChild(1).transform.localScale = new Vector3(scale.x * (health / 100), scale.y, scale.z);
    }
}
