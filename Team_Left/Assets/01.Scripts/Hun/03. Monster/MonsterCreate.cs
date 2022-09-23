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
        // ��ȯ�� ���� ��ȣ�� ����Ʈ�� ����
        for (int i = 0; i < MonsterVolume; i++)
        {
            StageMonster.Add(MonsterNumber - 1);
        }
    }

    public void MonsterSpawn(float SpawnTime)
    {
        // ����ƮStageMonster�� ���� ���͸� ��ȯ
        StartCoroutine(_MonsterSpawn(SpawnTime));
    }
    private IEnumerator _MonsterSpawn(float SpawnTime)
    {
        StageProgress = false;
        for (int i = 0; i < StageMonster.Count; i++)
        {
            // ���� ����
            GameObject Monster = Instantiate(MonsterPrefab[StageMonster[i]], Start.transform.position, Quaternion.identity);
            // ��ȯ�� ������ ������ ����
            Monster.GetComponent<MonsterNav>().AddTarget(End.transform.position);

            yield return new WaitForSeconds(SpawnTime);
        }
        // ������ ���� for������ ���� ��ȯ�� �� ����Ʈ�� ���
        StageMonster.Clear();
        StageProgress = true;
        Stage += 1;
    }
}
