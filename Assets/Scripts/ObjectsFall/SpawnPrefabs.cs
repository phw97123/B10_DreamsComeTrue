using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] Prefabs;        //0 배드 버그 1 픽스 버그 2 살충제 3 cpu 4 건전지 5 chatgpt 6 null  이미지
    public GameObject[] PullObject;     //풀링 오브젝트
    private float randomX = 2.7f;
    private float Y = 3.15f;
    private float time = 0;
    public static int _spawnNum ;
    public static float spawntime;
    private int _count = 0;
    private int _pivot = 0;
    
    void Start()
    {
        PullObject = new GameObject[500];
        for (int i = 0; i < PullObject.Length; i++)
        {
            int index = 0;
            if (i >= 400)
            {
                index = Random.Range(2, 7);
                
            }
            else if (i >= 300)
            {
                index = 1; 
            }
            Vector3 spawnPos = new Vector3(Random.Range(-randomX, randomX), Y, 1);
            GameObject gameObject = Instantiate(Prefabs[index], spawnPos, Prefabs[index].transform.rotation);
            PullObject[i] = gameObject;
            gameObject.SetActive(false);
        }
        PullObject = ShuffleArray(PullObject);
    }
    public static T[] ShuffleArray<T>(T[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.7f)//spawntime -> 얘를 점점 감소 시키는 것이다. 스폰을 얼마나 일정주기로 할건가
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
           // spawnNum++;
        }
        time = 0;
    }
}
