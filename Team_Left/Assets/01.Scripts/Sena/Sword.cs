using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            if (player.GetBool("Attack") == true)
            {
                other.GetComponent<MonsterHealth>().Hit(SwordType.instance.WeaponPower);
            }

        }


    }
}
