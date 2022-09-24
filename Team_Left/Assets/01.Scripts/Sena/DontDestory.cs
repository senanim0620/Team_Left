using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestory : MonoBehaviour
{
    public bool ison;


    private void Awake()
    {
        ison = true;
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
   
       // ison = Opening.instance.ison.GetComponent<Toggle>().isOn;
    }
}
