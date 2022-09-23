using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Jobs;

public class MonsterCreate : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject[] MonsterPrefab = new GameObject[0];

    [Header("Nav Mesh")]
    public GameObject Start;
    public GameObject End;

    [Header("Stage")]
    public int Stage;
    public float SpawnTime;

    public  List<int> StageMonster;
    private bool StageProgress;

    private void Awake()
    {
        StageProgress = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && StageProgress)
        {
            AddStage(Stage);
            MonsterSpawn(SpawnTime);
        }
    }

    private void AddStage(int StageNumber)
    {
        switch (StageNumber)
        {
            case 1:
                {
                    //AddMonster(1, 1);
                    //AddMonster(2, 1);
                    //AddMonster(3, 1);
                    //AddMonster(4, 1);
                    //AddMonster(5, 1);
                    //AddMonster(6, 1);
                    AddMonster(1, 13);
                    AddMonster(2, 7);
                }
                break;
            case 2:
                {
                    AddMonster(1, 13);
                    AddMonster(2, 11);
                    AddMonster(3, 6);
                }
                break;
            case 3:
                {
                    AddMonster(1, 10);
                    AddMonster(2, 14);
                    AddMonster(3, 15);
                    AddMonster(5, 1);
                }
                break;
            case 4:
                {
                    AddMonster(1, 15);
                    AddMonster(2, 13);
                    AddMonster(3, 12);
                    AddMonster(4, 9);
                    AddMonster(6, 1);
                }
                break;
            default:
                break;
        }
    }

    private void AddMonster(int MonsterNumber, int MonsterVolume)
    {
        // 소환할 몬스터 번호를 리스트에 넣음
        for (int i = 0; i < MonsterVolume; i++)
        {
            StageMonster.Add(MonsterNumber - 1);
        }
    }

    public void MonsterSpawn(float SpawnTime)
    {
        // 리스트StageMonster에 넣은 몬스터를 소환
        StartCoroutine(_MonsterSpawn(SpawnTime));
    }
    private IEnumerator _MonsterSpawn(float SpawnTime)
    {
        StageProgress = false;
        for (int i = 0; i < StageMonster.Count; i++)
        {
            // 몬스터 생성
            GameObject Monster = Instantiate(MonsterPrefab[StageMonster[i]], Start.transform.position, Quaternion.identity);
            // 소환한 몬스터의 목적지 설정
            Monster.GetComponent<MonsterNav>().AddTarget(End.transform.position);

            yield return new WaitForSeconds(SpawnTime);
        }
        // 마지막 까지 for문으로 전부 소환한 후 리스트를 비움
        StageMonster.Clear();
        StageProgress = true;
        Stage += 1;
    }
}
