using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Jobs;

public class MonsterCreate : MonoBehaviour
{
    private UI_Manager _UI_Manager;
    private bool stagestart = false;

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

    public  List<int> StageMonster;
    public List<GameObject> LiveMonster;

    private bool StageProgress;

    private void Awake()
    {
        stagestart = true;
        StageProgress = true;
        _UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
    }
    private void FixedUpdate()
    {
        _UI_Manager.LiveMonster = LiveCheck();
    }



    private void Update()
    {
        if (stagestart)
        {
            StageStart(Stage, SpawnTime);
            stagestart = false;
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
            return 0 ;
        }

        int LiveMonsterNum = 0;

        for (int i = 0; i < LiveMonster.Count; i++)
        {
            if (LiveMonster[i] != null)
            {
                LiveMonsterNum ++;
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
            _UI_Manager.Start = true;

            yield return new WaitForSeconds(SpawnTime);
        }
        // 마지막 까지 for문으로 전부 소환한 후 리스트를 비움
        StageMonster.Clear();
        StageProgress = true;
        Stage += 1;
    }
}
