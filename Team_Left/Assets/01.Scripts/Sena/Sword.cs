using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator player;

    public AudioClip dead;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            if (player.GetBool("Attack") == true)
            {
                
                other.GetComponent<MonsterHealth>().Hit(SwordType.instance.WeaponPower);

                if(other.GetComponent<MonsterHealth>().DieSound)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(dead);
                }

            }

        }


    }
}
