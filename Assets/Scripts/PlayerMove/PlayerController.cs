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
            if (GameManager.instance.BugDieItem.activeSelf == true)//���� Ȱ��ȭ �Ǿ��ִٸ�.
            {
                GameManager.instance.BugDieItemCount();  //��׵鵵 �Լ��� �����
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
            Debug.Log("�� ��Ҿ�");
            GameManager.instance.BugDieItemOn();// �ؽ�Ʈ���� ���� ���� ��
        }
        other.gameObject.SetActive(false);
    }
}
