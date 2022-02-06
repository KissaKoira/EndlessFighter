using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_interaction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }
}
