using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    void Start()
    {
        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(3.5f, 4.0f);
        transform.position = new Vector3(x, y, 0);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            Debug.Log("땅에게 닿았습니다. 사라지기");
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "player")
        {
            Debug.Log("플레이어에게 닿았습니다. 에너지 추가");
            //점수 추가 메서드
            Destroy(gameObject);
        }
    }
}
