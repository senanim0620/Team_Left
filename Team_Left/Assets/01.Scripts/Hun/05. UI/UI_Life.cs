using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Life : MonoBehaviour
{
    public int Life;

    public Text LifeText;

    private void Awake()
    {
        SetLifeText();
    }

    public void _AddLife(int Number)
    {
        Life += Number;
        SetLifeText();
    }
    private void SetLifeText()
    {
        LifeText.text = $"Life : {Life}";
    }
}
