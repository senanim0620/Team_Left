using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
//using Unity.VisualScripting;
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


    void Update()
    {
        Move();
        LookAt();
        AnimatorControl();
    }

    void Move()
    {
        gameObject.GetComponent<Animator>().SetBool("Move",true);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| (Input.GetKey(KeyCode.D)))
        {
            transform.Translate(0f, 0, speed * Time.deltaTime);
        }

    }

    void LookAt()
    {
        if(Horizontal > 0 && Vertical > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f , 0f));
        else if (Horizontal > 0 && Vertical < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
        else if(Horizontal < 0 && Vertical > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        else if (Horizontal < 0 && Vertical < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        
        else if (Horizontal > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 270f-45f, 0f));
        else if(Horizontal < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f - 45f, 0f));
        else if (Vertical > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f - 45f, 0f));
        else if (Vertical < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f - 45f, 0f));
    }

    void AnimatorControl()
    {
        if ((Horizontal != 0 || (Vertical != 0)))
        {
            gameObject.GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
        }

    }


}


