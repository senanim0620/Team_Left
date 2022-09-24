using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNav : MonoBehaviour
{
    private MonsterStatus _MonsterStatus;
    private NavMeshAgent _NavMeshAgent;
    private UI_Manager _UI_Manager;
    
    public bool Arrival = false;

    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        _NavMeshAgent = GetComponent<NavMeshAgent>();

        _UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }

    private void FixedUpdate()
    {
        _NavMeshAgent.speed = _MonsterStatus.Speed;
    }

    private void Update()
    {
        //���������� �����ϸ� ����
        if (Arrival)
        {
            Destroy(gameObject);
        }
    }
    public void AddTarget(Vector3 Vector)
    {
        //������ ����
        _NavMeshAgent.destination = Vector;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "End")
        {
            //���� ���� ���� �ᵵ ��
            _UI_Manager.AddLife(-1);
            Arrival = true;
        }
    }
}
