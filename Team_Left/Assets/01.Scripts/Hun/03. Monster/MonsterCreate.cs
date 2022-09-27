using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Jobs;

public class MonsterCreate : MonoBehaviour
{

    public List<int> StageMonster;
    public List<GameObject> LiveMonster;
    private UI_Manager _UI_Manager;

    [Header("GameObject")]
    public GameObject UI_Manager;

    [Header("MonsterPrefab")]
    public GameObject[] MonsterPrefab = new GameObject[0];

    [Header("Nav Mesh")]
    public GameObject Start;
    public GameObject End;

    [Header("Stage")]
    public int Stage;
    public float SpawnTime;


    [Header("StageMonster")]
    public int[] Monster1 = new int[0];
    public int[] Monster2 = new int[0];
    public int[] Monster3 = new int[0];
    public int[] Monster4 = new int[0];
    public int[] Monster5 = new int[0];
    public int[] Monster6 = new int[0];
    private bool StageProgress;

    private void Awake()
    {
        StageProgress = true;
        _UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StageStart(Stage, SpawnTime);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log(LiveCheck());
        }
    }
    private void AddStage(int StageNumber)
    {
        switch (StageNumber)
        {
            case 1:
                {
                    for (int i = 1; i < 7; i++)
                    {
                        AddMonster(i, Monster1[0]);
                    }
                }
                break;
            case 2:
                {
                    for (int i = 1; i < 7; i++)
                    {
                        AddMonster(i, Monster1[1]);
                    }
                }
                break;
            case 3:
                {
                    for (int i = 1; i < 7; i++)
                    {
                        AddMonster(i, Monster1[2]);
                    }
                }
                break;
            case 4:
                {
                    for (int i = 1; i < 7; i++)
                    {
                        AddMonster(i, Monster1[3]);
                    }
                }
                break;
            default:
                break;
        }
    }

    private void StageStart(int stage, float spawnTime)
    {
        if (!StageProgress)
        {
            return;
        }
        StageProgress = false;
        StartCoroutine(StartText(stage, spawnTime));
    }

    private IEnumerator StartText(int stage, float spawnTime)
    {
        _UI_Manager.SetSenterText("3", 1);
        yield return new WaitForSeconds(1);
        _UI_Manager.SetSenterText("2", 1);
        yield return new WaitForSeconds(1);
        _UI_Manager.SetSenterText("1", 1);
        yield return new WaitForSeconds(1);

        AddStage(stage);
        MonsterSpawn(spawnTime);
    }

    public int LiveCheck()
    {
        if (LiveMonster.Count == 0)
        {
            return 0;
        }

        int LiveMonsterNum = 0;

        for (int i = 0; i < LiveMonster.Count; i++)
        {
            if (LiveMonster[i] != null)
            {
                LiveMonsterNum++;
            }
        }
        if (LiveMonsterNum == 0)
        {
            LiveMonster.Clear();
        }
        return LiveMonsterNum;
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

        for (int i = 0; i < StageMonster.Count; i++)
        {
            // 몬스터 생성
            GameObject Monster = Instantiate(MonsterPrefab[StageMonster[i]], Start.transform.position, Quaternion.identity);
            LiveMonster.Add(Monster);

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