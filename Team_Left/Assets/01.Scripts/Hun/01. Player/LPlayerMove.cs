using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPlayerMove : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private Rigidbody _Rigidbody;

    public float MoveSpeed;
    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        _Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_PlayerInput.Horizontal, _PlayerInput.Vertical);
    }

    private void Movement(float Horizontal, float Vertical)
    {
        _Rigidbody.velocity = new Vector3(Horizontal, 0, Vertical) * MoveSpeed * Time.deltaTime;
        //transform.position += new Vector3(Horizontal, 0, Vertical) * MoveSpeed * Time.deltaTime;
    }

}
