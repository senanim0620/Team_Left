using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private UI_Life _UI_Life;
    private UI_Gold _UI_Gold;
    private UI_Damage _UI_Damage;
    private UI_Senter _UI_Senter;

    [Header("UI")]
    public GameObject UI;

    private void Awake()
    {
        _UI_Life = UI.GetComponent<UI_Life>();
        _UI_Gold = UI.GetComponent<UI_Gold>();
        _UI_Damage = UI.GetComponent<UI_Damage>();
        _UI_Senter = UI.GetComponent<UI_Senter>();
    }

    // 라이프 관련
    public void AddLife(int Number)
    {
        _UI_Life._AddLife(Number);
    }
    public void SetLife(int Number)
    {
        _UI_Life._SetLife(Number);
    }
    public int GetLife()
    {
        return _UI_Life.Life;
    }

    // 골드 관련
    public void AddGold(int Number)
    {
        _UI_Gold._AddGold(Number);
    }
    public void SetGold(int Number)
    {
        _UI_Gold._SetGold(Number);
    }
    public int GetGold()
    {
        return _UI_Gold.Gold;
    }

    // 데미지 관련
    public void AddDamage(float Number)
    {
        _UI_Damage._AddDamage(Number);
    }
    public void SetDamage(float Number)
    {
        _UI_Damage._SetDamage(Number);
    }

    public float GetDamage()
    {
        return _UI_Damage.Damage;
    }

    // 센터 텍스트 관련
    public void SetSenterText(string String, float Value)
    {
        _UI_Senter._SetSenterText(String, Value);
    }
}
