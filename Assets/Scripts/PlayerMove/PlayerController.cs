using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BadBug")
        {
            Debug.Log("���۹���");
        }
        else if(other.gameObject.tag == "FixBug")
        {
            Debug.Log("��������");
            GameManager.instance.addFixBug(1);
            Debug.Log(GameManager.instance.totalFixBug);
        }
        else if (other.gameObject.tag == "RecoveryItem")
        {
            Debug.Log("ȸ��");
        }
        other.gameObject.SetActive(false);
    }
    
}
