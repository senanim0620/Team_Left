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
        //도착지점에 도착하면 삭제
        if (Arrival)
        {
            Destroy(gameObject);
        }
    }
    public void AddTarget(Vector3 Vector)
    {
        //목적지 설정
        _NavMeshAgent.destination = Vector;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "End")
        {
            //도착 판정 여따 써도 됨
            Arrival = true;
        }
    }
}
