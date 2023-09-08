using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] Prefabs;        //0 배드 버그 1 픽스 버그 2 회복
    public GameObject[] PullObject;     //풀링 오브젝트
    private float randomX = 2.7f;       //프리팹의 생성 범위
    private float spawnY = 5.2f;        //프리팹 처음 소환 위치
    private float time = 0;
    private float stageUpTime = 0;
    private int _spawnNum = 3;          //소환 개수
    public int pivot = 0;               //몇번째 오브젝트인지

    void Start()
    {
        PullObject = new GameObject[120];       //풀링 오브젝트 생성
        for(int i = 0; i < PullObject.Length; i++)      //프리팹 할당
        {
            int index = Random.Range(0, 10);    //랜덤으로 70% 나쁜버그 20% 좋은버그 10% 회복템
            if (index > 2)
            {
                index = 0;
            }
            else if (index > 0)
            {
                index = 1;
            }
            else
            {
                index = 2;
            }
            Vector3 spawnPos = new Vector3(Random.Range(-randomX, randomX), spawnY, 1);     //위치 지정
            GameObject gameObject = Instantiate(Prefabs[index], spawnPos, Prefabs[index].transform.rotation);   //지정한 위치에 프리팹 소환
            PullObject[i] = gameObject;     //풀링 오브젝트에 프리팹 추가
            gameObject.SetActive(false);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)        //0.5초마다
        {
            SpawnPrefab(_spawnNum);
        }
    }

    private void SpawnPrefab(int spawnNum)
    {
        for(int i = 0; i < spawnNum; i++)       //소환개수만큼 소환
        {
            PullObject[pivot++].SetActive(true);
            if (pivot == 120)
            {
                pivot = 0;
            }
        }
        stageUpTime += time;
        if (stageUpTime == 15)      //15초마다 소환개수 1개 증가
        {
            _spawnNum++;
            stageUpTime = 0;
        }
        time = 0;
    }
}
