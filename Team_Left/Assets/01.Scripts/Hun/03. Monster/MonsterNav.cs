using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNav : MonoBehaviour
{
    private MonsterStatus _MonsterStatus;
    private NavMeshAgent _NavMeshAgent;

    private GameObject EndPosition;
    public bool Arrival = false;

    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        _NavMeshAgent = GetComponent<NavMeshAgent>();
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
        if (other.gameObject.tag == "End")
        {
            //���� ���� ���� �ᵵ ��
            Arrival = true;
        }
    }
}
