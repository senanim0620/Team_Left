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
        // 체력바가 카메라 보게하기
        HpSlider.transform.LookAt(Camera.main.transform);

        if (Input.GetKey(KeyCode.H))
        {
            Hit(0.1f);
        }
    }
    public void Hit(float Damage)
    {
        // 체력바 조정
        HP -= Damage;
        HpSlider.value = HP / (MaxHP / 100);
        // 체력이 없을 시 사망
        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // 죽었을 때 코인떨어뜨림
        GameObject coin = Instantiate(CoinPrefab,transform.position,transform.rotation);
        // 떨어뜨린 코인에 램덤값 넣기
        int DropMoney = Random.Range(_MonsterStatus.MinDropGold, _MonsterStatus.MaxDropGold + 1);
        coin.GetComponent<Coin>().DropMoney = DropMoney;
        // 
        Destroy(gameObject);
    }

}
