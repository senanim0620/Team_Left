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
    [SerializeField]
    private int coin;

    private float attacktime = 0;
    private bool isDelay; // ���� ������ �ð�. 



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
                Debug.Log("���� ����!");
                gameObject.GetComponent<Animator>().SetBool("Attack", true);
                StartCoroutine(AttackDelay());
            }
            else
            {
           
                Debug.Log("���� �����ϱ⿣ �����̰�....");
            }

        }


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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sena");

        if(other.CompareTag("coin"))
        {
            coin +=other.GetComponent<Coin>().DropMoney;
            Destroy(other.gameObject);
        }
    }


}