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
        // 라이프 값을 더해줌
        Life += Number;
        SetLifeText();
    }
    public void _SetLife(int Number)
    {
        // 라이프 값을 대입함
        Life = Number;
        SetLifeText();
    }

    private void SetLifeText()
    {

        LifeText.text = $"{Life} / 7";

    }
}
