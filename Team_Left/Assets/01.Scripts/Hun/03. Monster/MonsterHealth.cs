using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    private MonsterStatus _MonsterStatus;

    [Header("Prefab")]
    [SerializeField] private GameObject CoinPrefab;

    [Header("HP")]
    [SerializeField] private Slider HpSlider;
    
    private float MaxHP;
    private float HP;
    Vector3 DieV;
    public bool DieSound;

    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        MaxHP = _MonsterStatus.HP;
        HP = MaxHP;
    }

    private void Update()
    {
        HpSlider.transform.LookAt(Camera.main.transform);
        DieV = transform.position;
        DieV.y += 0.5f;
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
            DieSound = true;
            Die();
        }
    }

    public void Die()
    {
        //gameObject.GetComponent<AudioSource>().Play();
        // �׾��� �� ���ζ���߸�
        GameObject coin = Instantiate(CoinPrefab, DieV, transform.rotation);

        // ����߸� ���ο� ������ �ֱ�
        int DropMoney = Random.Range(_MonsterStatus.MinDropGold, _MonsterStatus.MaxDropGold + 1);
        coin.GetComponent<Coin>().DropMoney = DropMoney;
        // 
        Destroy(gameObject);
    }

}
