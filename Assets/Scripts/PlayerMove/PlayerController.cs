using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public int Hp = 5;
    public int MaxHp = 5;
    public int Score = 0;
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BadBug")
        {
            if (GameManager.instance.BugDieItem.activeSelf == true)//만약 활성화 되어있다면.
            {
                GameManager.instance.BugDieItemCount();  //얘네들도 함수로 만들기
            }
            if (Hp > 0)
            {
                
                Hp--;
            }
        }
        else if(other.gameObject.tag == "FixBug")
        {
            Score++;
        }
        else if (other.gameObject.tag == "RecoveryItem")
        {
            if (MaxHp > Hp)
            {
                Hp++;
            }
        }
        else if (other.gameObject.tag == "Pesticides")
        {
            Debug.Log("나 닿았어");
            GameManager.instance.BugDieItemOn();// 텍스트에서 점점 뺴는 것
        }
        other.gameObject.SetActive(false);
    }
}
