using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerStat2 : MonoBehaviour
{
    public UI_Manager _UI_Manager;

    public SwordType swordtype;
    public GameObject longsword;
    public GameObject shortsword;

    public Vector3 startlocation;

    private string weapon_name;
    public int weapon_type;
    public int weapon_power;

    public int power;
    private float delay;
    [SerializeField]
    public int coin;

    private float attacktime = 0;
    private void Awake()
    {
       // _UI_Manager = FindObjectOfType<UI_Manager>();
      //  swordtype = FindObjectOfType<SwordType>();

       // _UI_Manager.SetLife(7);
    }
    // Start is called before the first frame update
    void Start()
    {
        _UI_Manager = FindObjectOfType<UI_Manager>();
        swordtype = FindObjectOfType<SwordType>();

        _UI_Manager.SetLife(7);


        startlocation = transform.position;
        longsword.SetActive(false);
        shortsword.SetActive(false);

        //Debug.Log(swordtype.WeaponPower);

        weapon_type = swordtype.Weapontype;
        coin = swordtype.coin;

        if (weapon_type == 1) // 장검
        {
            weapon_power = 5;
            longsword.SetActive(true);
        }
        else // 장검 안산 경우
        {
            weapon_power = 3;
            shortsword.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            _UI_Manager.AddLife(1);
        }

        _UI_Manager.SetGold(coin);
        _UI_Manager.SetDamage(SwordType.instance.WeaponPower);
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("sena");

        if (other.CompareTag("coin"))
        {
            GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<BGMManager>().CoinGet); 
            coin += other.GetComponent<Coin>().DropMoney;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Deadzone"))
        {
            gameObject.transform.position = startlocation;
        }

    }

}
