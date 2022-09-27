using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Damage : MonoBehaviour
{
    public float Damage;

    public Text DamageText;

    private void Awake()
    {
        SetDamageText();
    }

    public void _AddDamage(float Number)
    {
        // 데미지 값을 더해줌
        Damage += Number;
        SetDamageText();
    }
    public void _SetDamage(float Number)
    {
        // 데미지 값을 대입함
        Damage = Number;
        SetDamageText();
    }

    private void SetDamageText()
    {
        DamageText.text = $"{Damage}";
    }
}
