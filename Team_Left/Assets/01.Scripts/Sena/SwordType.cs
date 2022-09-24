using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordType : MonoBehaviour
{
    public static SwordType instance;
    public int Weapontype;
    public int coin;
    




    private void Awake()
    {
        if(instance==null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        
        Weapontype = 0;
        DontDestroyOnLoad(gameObject);


    }

}
