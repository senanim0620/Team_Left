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



    public void _AddGold(int Number)
    {
        // ∞ÒµÂ ∞™¿ª ¥ı«ÿ¡‹
        Gold += Number;
        SetGoldText();
    }
    public void _SetGold(int Number)
    {
        // ∞ÒµÂ ∞™¿ª ¥Î¿‘«‘
        Gold = Number;
        SetGoldText();
    }

    private void SetGoldText()
    {
        GoldText.text = $"{Gold}";
    }
}
