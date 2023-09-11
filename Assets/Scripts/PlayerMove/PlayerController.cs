using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public static int Score = 0;
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BadBug")
        {

        }
        else if(other.gameObject.tag == "FixBug")
        {
            Score++;
        }
        else if (other.gameObject.tag == "RecoveryItem")
        {

        }
        other.gameObject.SetActive(false);
    }
}
