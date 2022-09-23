using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Key_Space { get; private set; }

    private void FixedUpdate()
    {
        Horizontal  = Input.GetAxis("Horizontal");
        Vertical    = Input.GetAxis("Vertical");
        Key_Space   = Input.GetKey(KeyCode.Space);
    }

}
