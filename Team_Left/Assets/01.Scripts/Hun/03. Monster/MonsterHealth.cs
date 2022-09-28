using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
        
        if (Input.GetKey(KeyCode.H))
        {
            Hit(0.1f);
        }
        // 체력이 없을 시 사망
        if (HP <= 0)
        {
            DieSound = true;
            Die();
        }
    }
    public void Hit(float Damage)
    {
        // 체력바 조정
        HP -= Damage;
        HpSlider.value = HP / (MaxHP / 100);
    }

    public void Die()
    {
        //gameObject.GetComponent<AudioSource>().Play();
        // 죽었을 때 코인떨어뜨림
        GameObject coin = Instantiate(CoinPrefab, transform.position, transform.rotation);

        // 떨어뜨린 코인에 램덤값 넣기
        int DropMoney = Random.Range(_MonsterStatus.MinDropGold, _MonsterStatus.MaxDropGold + 1);
        coin.GetComponent<Coin>().DropMoney = DropMoney;
        // 
        Destroy(gameObject);
    }

}
