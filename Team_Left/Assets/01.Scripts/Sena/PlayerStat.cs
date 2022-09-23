using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    private string weapon_name;
    private int weapon_type;
    private int weapon_power;

    private int power;
    private float delay;
    private int coin;

    private float attacktime = 0;
    private bool isDelay; // 공격 딜레이 시간. 

    private void Start()
    {
        isDelay = false;
        delay = 1;
    }

    private void Update()
    {
        PlayerAttack();

    }



    void PlayerAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isDelay==false)
            {
                isDelay = true;
                Debug.Log("포도 공격!");
                gameObject.GetComponent<Animator>().SetBool("Attack", true);
                StartCoroutine(AttackDelay());
            }
            else
            {
           
                Debug.Log("포도 공격하기엔 딜레이가....");
            }




            
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Animator>().GetBool("Attack"))
            Destroy(other.gameObject);
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(delay);
        isDelay = false;
    }


    void AttackStart()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", true);
    }

    void AttackEnd()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }


}