using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    private SwordType swordtype;
    public GameObject longsword;
    public GameObject shortsword;

    public Vector3 startlocation;

    private string weapon_name;
    public int weapon_type;
    private int weapon_power;

    private int power;
    private float delay;
    [SerializeField]
    public int coin;

    private float attacktime = 0;


    private void Start()
    {
        swordtype = FindObjectOfType<SwordType>(); // �̼����� �ᱹ Find�� ���� ���µ�

        longsword.SetActive(false);
        shortsword.SetActive(false);

        weapon_type = swordtype.Weapontype;
        coin = swordtype.coin;

        if(weapon_type == 1) // ���
        {
            longsword.SetActive(true);
        }
        else // ��� �Ȼ� ���
        {
            shortsword.SetActive(true);
        }

    }





    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sena");

        if(other.CompareTag("coin"))
        {
            coin +=other.GetComponent<Coin>().DropMoney;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Deadzone"))
        {
            gameObject.transform.position = startlocation;
        }

    }


}