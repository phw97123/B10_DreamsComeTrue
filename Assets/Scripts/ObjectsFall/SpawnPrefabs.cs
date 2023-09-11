using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] Prefabs;        //0 배드 버그 1 픽스 버그 2 회복
    private float randomX = 2.7f;
    private float Y = 5.2f;
    private float time = 0;
    private int _spawnNum = 4;
    private int _count = 0;
    private int _maxSpeed = 8;
    private int _minSpeed = 4;

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
            int index = Random.Range(0, 10);
            if (index > 4)
            {
                index = 0;
            }
            else if (index > 3)
            {
                index = 1;
            }
            else if (index > 2) 
            {
                index = 3;
            }
            else
            {
                index = 2;
            }
            Vector3 spawnPos = new Vector3(Random.Range(-randomX, randomX), Y, 1);
            GameObject prefabs = Instantiate(Prefabs[index], spawnPos, Prefabs[index].transform.rotation);
            prefabs.GetComponent<ObjectsFall>().speed = Random.Range(_minSpeed , _maxSpeed);
        }
        _count++;
        if (_count > 30)
        {
            _count = 0;
            spawnNum++;
            _maxSpeed += 2;
            _minSpeed++;
        }
        time = 0;
    }
}
