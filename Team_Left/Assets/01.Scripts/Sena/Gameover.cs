using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private UI_Manager _UI_Manager;
    public GameObject clearcanvas;
    public GameObject defeatcanvas;

    // Start is called before the first frame update
    void Start()
    {
        defeatcanvas.SetActive(false);
        clearcanvas.SetActive(false);
        _UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_UI_Manager.GetLife() < 0)// �������� ���� �ʾƼ� ����
        {
            defeatcanvas.SetActive(true);
            Debug.Log("�й�!");
           
        }
        else // ������ �������� 
        {
            if (_UI_Manager.LiveMonster == 0 && _UI_Manager.Stagestart)
            {
                clearcanvas.SetActive(true);
                Debug.Log("���!");
                // gameObject.SetActive(true);
                // Win
            }
        }
    }
}
