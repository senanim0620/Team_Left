using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearCanvas : MonoBehaviour
{
    public SwordType swordType;
    public PlayerStat stat;
    public Button swordButton;
    // Start is called before the first frame update
    void Start()
    {
        swordButton.interactable = false;
        swordType.coin = stat.coin;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //여기 다훈이가 만듬
        // 만약 win이라면 


        if(swordType.coin >= 200)
        {
            swordButton.interactable = true;
        }
        else
        {
            swordButton.interactable = false;
        }
    }

    public void MainButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void NextStageButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void SwordClick()
    {
        swordType.Weapontype = 1;
        swordType.coin -= 200;
        //swordButton.interactable = false;
    }

}
