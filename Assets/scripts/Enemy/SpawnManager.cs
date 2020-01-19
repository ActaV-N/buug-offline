using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxCount;//적당한 적의 수
    public int enemyCount;
    public float spawnTime = 3f; //curTime이 spawnTime보다 크면 생성코드실행
    public float curTime; //Rime.deltaTime 이용해서 curTime 매 프레임 증가
    public Transform[] spawnPoints;
    public GameObject enemy;
    public bool[] isSpawn;

    public static SpawnManager _instance;
    private void Start()
    {
        isSpawn = new bool[spawnPoints.Length];//spawnpoint의 크기만큼 초기화
        for (int i = 0; i < isSpawn.Length; i++)
        {
            isSpawn[i] = false;
        }
        _instance = this;
    }

    private void Update()
    {
        if (curTime >= spawnTime && enemyCount < maxCount) 
        {
            int x = Random.Range(0, spawnPoints.Length);//한곳에 겹쳐서 스폰ㄴㄴ
            if(!isSpawn[x])
            SpawnEnemy(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        enemyCount++;//최대 몬스터 수 맞추기위해
        Instantiate(enemy, spawnPoints[ranNum]);//랜덤 생성
        isSpawn[ranNum] = true;
    }
}
