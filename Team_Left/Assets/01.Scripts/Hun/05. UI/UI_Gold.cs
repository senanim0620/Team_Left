using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gold : MonoBehaviour
{
    public int Gold;

    public Text GoldText;

    private void Awake()
    {
        SetGoldText();
    }

<<<<<<< HEAD
    public void _AddGold(int Number)
    {
=======


    public void _AddGold(int Number)
    {
        // °ñµå °ªÀ» ´õÇØÁÜ
>>>>>>> main
        Gold += Number;
        SetGoldText();
    }
    public void _SetGold(int Number)
    {
<<<<<<< HEAD
=======
        // °ñµå °ªÀ» ´ëÀÔÇÔ
>>>>>>> main
        Gold = Number;
        SetGoldText();
    }

    private void SetGoldText()
    {
        GoldText.text = $"Gold : {Gold}";
    }
}
