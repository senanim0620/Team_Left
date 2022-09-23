using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
 

    public float Horizontal
    {
        get; private set; 
    }
    public float Vertical
    {
        get; private set;
    }

    private void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }


    // Update is called once per frame
    void Update()
    {

        Move();
       // PlayerAttack();

        if ((Horizontal !=0|| (Vertical !=0)))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
        }
    }

    void Move()
    {
        gameObject.GetComponent<Animator>().SetBool("Move",true);

        Vector3 move = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");

        move.y = 0;

        transform.position += move * speed * Time.deltaTime;
        
    }

}
