using System.Collections;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.Search;
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
    public GameObject start;
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

    private void Start()
    {
        StageStart(Stage, SpawnTime);
    }


    private void FixedUpdate()
    {
        _UI_Manager.LiveMonster = LiveCheck();
    }
    private void Update()
    {


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
                    AddMonster(1, Monster1[0]);
                    AddMonster(2, Monster2[0]);
                    AddMonster(3, Monster3[0]);
                    AddMonster(4, Monster4[0]);
                    AddMonster(5, Monster5[0]);
                    AddMonster(6, Monster6[0]);
                }
                break;
            case 2:
                {
                    AddMonster(1, Monster1[1]);
                    AddMonster(2, Monster2[1]);
                    AddMonster(3, Monster3[1]);
                    AddMonster(4, Monster4[1]);
                    AddMonster(5, Monster5[1]);
                    AddMonster(6, Monster6[1]);
                }
                break;
            case 3:
                {
                    AddMonster(1, Monster1[2]);
                    AddMonster(2, Monster2[2]);
                    AddMonster(3, Monster3[2]);
                    AddMonster(4, Monster4[2]);
                    AddMonster(5, Monster5[2]);
                    AddMonster(6, Monster6[2]);
                }
                break;
            case 4:
                {
                    AddMonster(1, Monster1[3]);
                    AddMonster(2, Monster2[3]);
                    AddMonster(3, Monster3[3]);
                    AddMonster(4, Monster4[3]);
                    AddMonster(5, Monster5[3]);
                    AddMonster(6, Monster6[3]);
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
            GameObject Monster = Instantiate(MonsterPrefab[StageMonster[i]], start.transform.position, Quaternion.identity);
            LiveMonster.Add(Monster);
            
            // 소환한 몬스터의 목적지 설정
            Monster.GetComponent<MonsterNav>().AddTarget(End.transform.position);

            if (i==1)
                _UI_Manager.Stagestart = true;
            yield return new WaitForSeconds(SpawnTime);
        }
        _UI_Manager.MonsterZenEnd = true;


        // 마지막 까지 for문으로 전부 소환한 후 리스트를 비움
        StageMonster.Clear();
        StageProgress = true;
        Stage += 1;
    }
}