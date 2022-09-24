using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private UI_Life _UI_Life;
    private UI_Gold _UI_Gold;
    
    [Header("UI")]
    public GameObject UI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddLife(-1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddGold(-1);
        }
    }

    private void Awake()
    {
        _UI_Life = UI.GetComponent<UI_Life>();
        _UI_Gold = UI.GetComponent<UI_Gold>(); 
    }
    public void AddLife(int Number)
    {
        _UI_Life._AddLife(Number);
    }

    public void AddGold(int Number)
    {
        _UI_Gold._AddGold(Number);
    }
}
