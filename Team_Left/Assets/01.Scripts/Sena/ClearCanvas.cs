using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearCanvas : MonoBehaviour
{
    //private UI_Manager _UI_Manager;

    public SwordType swordType;
    public PlayerStat stat;
    public Button swordButton;
    // Start is called before the first frame update
    void Start()
    {
        //_UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();

        swordType = FindObjectOfType<SwordType>();
        stat = FindObjectOfType<PlayerStat>();

        swordButton.interactable = false;
        swordType.coin = stat.coin;
        swordType.WeaponPower = 3;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
        swordType.WeaponPower = 5;
        //swordButton.interactable = false;
    }

}
