using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    public GameObject PausePage;

    public Button[] button = new Button[4];
    
    private void Awake()
    {
        button[0].onClick.AddListener(() => buttonClick(0));
        button[1].onClick.AddListener(() => buttonClick(1));
        button[2].onClick.AddListener(() => buttonClick(2));
        button[3].onClick.AddListener(() => buttonClick(3));
        VisibilitPause(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PausePage.activeSelf)
        {
            buttonClick(0);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && PausePage.activeSelf)
        {
            buttonClick(1);
        }
    }

    public void buttonClick(int Key)
    {
        switch (Key)
        {
            case 0:// Pause 켜기
                {
                    VisibilitPause(true);
                }
                break;
            case 1:// 게임 재개
                {
                    VisibilitPause(false);
                }
                break;
            case 2:// 메인 메뉴
                {
                    SceneManager.LoadScene("Opening");
                    Time.timeScale = 1;
                }
                break;
            case 3:// 나가기
                {
                    Application.Quit();
                }
                break;
            default:
                break;
        }
    }
    public void VisibilitPause(bool Visit)
    {
        if (Visit)
        {
            PausePage.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!Visit)
        {
            PausePage.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
