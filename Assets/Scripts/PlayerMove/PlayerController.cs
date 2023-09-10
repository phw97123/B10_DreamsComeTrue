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
            Debug.Log("³ª»Û¹ú·¹");
        }
        else if(other.gameObject.tag == "FixBug")
        {
            Debug.Log("ÁÁÀº¹ú·¹");
        }
        else if (other.gameObject.tag == "RecoveryItem")
        {
            Debug.Log("È¸º¹");
        }
        other.gameObject.SetActive(false);
    }
}
