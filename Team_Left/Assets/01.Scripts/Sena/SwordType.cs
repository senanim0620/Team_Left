using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordType : MonoBehaviour
{
    public static SwordType instance;
    public int Weapontype;
    public int WeaponPower;
    public int coin;


    private void Awake()
    {
        if(instance==null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
 
        DontDestroyOnLoad(gameObject);

        // ��Ÿ�� �����ϴ� ��

    }

    private void FixedUpdate()
    {
        if (Weapontype == 0)
        {
            WeaponPower = 3;
        }
        else if (Weapontype == 1)
        {
            WeaponPower = 5;
        }
        else
        {
            Debug.Log("���⿡ ���Դٸ� �ͺ��");
        }
    }

}
