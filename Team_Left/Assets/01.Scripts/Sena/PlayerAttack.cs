using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerStat stat;
   // private Vector3 startlocation; // 처음 위치 저장
    private float delay; // 공격 딜레이 시간
    private bool isDelay; // 공격 딜레이가 발생해야 하는지 확인함

    private void Start()
    {
        stat=GetComponent<PlayerStat>();    
        stat.startlocation = transform.position;
        isDelay = false;
        delay = 0.5f;
    }


    private void Update()
    {
        Playerattack();
    }


    void Playerattack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isDelay == false)
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



