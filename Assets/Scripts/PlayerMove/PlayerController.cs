using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public int Score = 0;
    public int Health = 5;
    public bool IsDeath = true;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BadBug")
        {
            if(Health == 1)
            {
                IsDeath = false;
            }
            else
            {
                Health -= 1;
            }
        }
        else if(other.gameObject.tag == "FixBug")
        {
            Score += 1;
        }
        else if (other.gameObject.tag == "RecoveryItem")
        {
            if (Health < 5)
            {
                Health += 1;
            }
        }
    }
}
