using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] Prefabs;        //0 배드 버그 1 픽스 버그 2 살충제 3 cpu 4 건전지 5 chatgpt 6 null  이미지
    public GameObject[] PullObject;     //풀링 오브젝트
    private float randomX = 2.7f;
    private float Y = 5.2f;
    private float time = 0;
    private int _spawnNum = 3;
    private int _count = 0;
    private int _pivot = 0;

    void Start()
    {
        PullObject = new GameObject[500];
        for (int i = 0; i < PullObject.Length; i++)
        {
            int index = Random.Range(0, 101);
            if (index >= 35)
            {
                index = 0;
            }
            else if (index >= 5)
            {
                index = 1;
            }
            else
            {
                index = Random.Range(2, 7);
            }
            Vector3 spawnPos = new Vector3(Random.Range(-randomX, randomX), Y, 1);
            GameObject gameObject = Instantiate(Prefabs[index], spawnPos, Prefabs[index].transform.rotation);
            PullObject[i] = gameObject;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            SpawnPrefab(_spawnNum);
        }
    }

    private void SpawnPrefab(int spawnNum)
    {
        for (int i = 0; i < spawnNum; i++)
        {
            PullObject[_pivot++].SetActive(true);
            if (_pivot == 500)
            {
                _pivot = 0;
            }
        }
        _count++;
        if (_count > 30)
        {
            _count = 0;
            spawnNum++;
        }
        time = 0;
    }
}
