using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_text_script : MonoBehaviour
{
    public Vector3 point;
    public Camera cam;

    void Update()
    {
        transform.position = cam.WorldToScreenPoint(point);
    }
}
