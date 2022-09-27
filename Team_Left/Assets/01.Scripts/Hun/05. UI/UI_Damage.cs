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
        // ������ ���� ������
        Damage += Number;
        SetDamageText();
    }
    public void _SetDamage(float Number)
    {
        // ������ ���� ������
        Damage = Number;
        SetDamageText();
    }

    private void SetDamageText()
    {
        DamageText.text = $"{Damage}";
    }
}
