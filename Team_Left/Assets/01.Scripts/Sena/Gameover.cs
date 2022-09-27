using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private UI_Manager _UI_Manager;
    public GameObject clearcanvas;
    public GameObject defeatcanvas;
    public AudioClip Dead;
    public AudioClip Win;

    private bool AudioTriger;

    // Start is called before the first frame update
    void Start()
    {
        AudioTriger = false;
        defeatcanvas.SetActive(false);
        clearcanvas.SetActive(false);
        _UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_UI_Manager.GetLife());

        if (_UI_Manager.GetLife() < 0)// 라이프가 남지 않아서 죽음
        {

               // gameObject.GetComponent<AudioSource>().PlayOneShot(Dead);
                defeatcanvas.SetActive(true);
                Debug.Log("패배!");
                 AudioTriger = true;



        }
        else // 라이프 남아있음 
        {
            if (_UI_Manager.LiveMonster == 0 && _UI_Manager.Stagestart && _UI_Manager.MonsterZenEnd)
            {


                    //gameObject.GetComponent<AudioSource>().PlayOneShot(Win);
                    clearcanvas.SetActive(true);
                    Debug.Log("우승!");
                    AudioTriger=true;

            }
        }
    }
}
