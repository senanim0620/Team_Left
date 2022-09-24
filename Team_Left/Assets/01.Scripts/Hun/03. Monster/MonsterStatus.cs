using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterStatus : MonoBehaviour
{
    public Color MonsterColor;
    public int MonsterNumber;   
    public string Name;
    public float HP;
    public float Speed;
    public int MinDropGold;
    public int MaxDropGold;

    private void Start()
    {
       // GetComponent<Renderer>().material.color = MonsterColor;
    }

}
