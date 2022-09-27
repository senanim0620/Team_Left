using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerStat2 stat;
   // private Vector3 startlocation; // ó�� ��ġ ����
    public float delay ; // ���� ������ �ð�
    private bool isDelay; // ���� �����̰� �߻��ؾ� �ϴ��� Ȯ����

    private void Start()
    {
        stat=GetComponent<PlayerStat2>();    
        stat.startlocation = transform.position;
        isDelay = false;
        
    }


    private void Update()
    {
        Playerattack();
    }


    void Playerattack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack2");
            if (isDelay == false)
            {
                isDelay = true;
                Debug.Log("���� ����!");
               // gameObject.GetComponent<Animator>().SetTrigger("Attack2");
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
      //  gameObject.GetComponent<Animator>().SetTrigger("Attack2");
       // gameObject.GetComponent<Animator>().SetBool("Attack", true);
    }

    void AttackEnd()
    {
       // gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }
}



