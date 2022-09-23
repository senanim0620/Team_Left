using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    private MonsterStatus _MonsterStatus;

    [Header("Prefab")]
    public GameObject CoinPrefab;

    [Header("HP")]
    [SerializeField] private float MaxHP;
    [SerializeField] private float HP;
    [SerializeField] private Slider HpSlider;

    
    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        MaxHP = _MonsterStatus.HP;
        HP = MaxHP;
    }

    private void Update()
    {
        // ü�¹ٰ� ī�޶� �����ϱ�
        HpSlider.transform.LookAt(Camera.main.transform);

        if (Input.GetKey(KeyCode.H))
        {
            Hit(0.1f);
        }
    }
    public void Hit(float Damage)
    {
        // ü�¹� ����
        HP -= Damage;
        HpSlider.value = HP / (MaxHP / 100);
        // ü���� ���� �� ���
        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // �׾��� �� ���ζ���߸�
        GameObject coin = Instantiate(CoinPrefab,transform.position,transform.rotation);
        // ����߸� ���ο� ������ �ֱ�
        int DropMoney = Random.Range(_MonsterStatus.MinDropGold, _MonsterStatus.MaxDropGold + 1);
        coin.GetComponent<Coin>().DropMoney = DropMoney;
        // 
        Destroy(gameObject);
    }

}
