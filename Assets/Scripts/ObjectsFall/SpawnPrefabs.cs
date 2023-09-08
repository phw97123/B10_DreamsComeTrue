using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] Prefabs;        //0 ��� ���� 1 �Ƚ� ���� 2 ȸ��
    public GameObject[] PullObject;     //Ǯ�� ������Ʈ
    private float randomX = 2.7f;       //�������� ���� ����
    private float spawnY = 5.2f;        //������ ó�� ��ȯ ��ġ
    private float time = 0;
    private float stageUpTime = 0;
    private int _spawnNum = 3;          //��ȯ ����
    public int pivot = 0;               //���° ������Ʈ����

    void Start()
    {
        PullObject = new GameObject[120];       //Ǯ�� ������Ʈ ����
        for(int i = 0; i < PullObject.Length; i++)      //������ �Ҵ�
        {
            int index = Random.Range(0, 10);    //�������� 70% ���۹��� 20% �������� 10% ȸ����
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
            Vector3 spawnPos = new Vector3(Random.Range(-randomX, randomX), spawnY, 1);     //��ġ ����
            GameObject gameObject = Instantiate(Prefabs[index], spawnPos, Prefabs[index].transform.rotation);   //������ ��ġ�� ������ ��ȯ
            PullObject[i] = gameObject;     //Ǯ�� ������Ʈ�� ������ �߰�
            gameObject.SetActive(false);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)        //0.5�ʸ���
        {
            SpawnPrefab(_spawnNum);
        }
    }

    private void SpawnPrefab(int spawnNum)
    {
        for(int i = 0; i < spawnNum; i++)       //��ȯ������ŭ ��ȯ
        {
            PullObject[pivot++].SetActive(true);
            if (pivot == 120)
            {
                pivot = 0;
            }
        }
        stageUpTime += time;
        if (stageUpTime == 15)      //15�ʸ��� ��ȯ���� 1�� ����
        {
            _spawnNum++;
            stageUpTime = 0;
        }
        time = 0;
    }
}
