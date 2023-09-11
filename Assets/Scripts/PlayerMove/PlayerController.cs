using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public static int Score = 0;
    public static bool IsDead = false;
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BadBug")
        {
            IsDead = true;
        }
        else if(other.gameObject.tag == "FixBug")
        {
            Score++;
        }
        else if(other.gameObject.tag == "Battery")
        {
            Debug.Log("Battery");
        }
        else if (other.gameObject.tag == "ChatGpt")
        {
            Debug.Log("ChatGpt");
        }
        else if (other.gameObject.tag == "CPU")
        {
            Debug.Log("CPU");
        }
        else if (other.gameObject.tag == "Insecticide")
        {
            Debug.Log("Insecticide");
        }
        else if (other.gameObject.tag == "NullImage")
        {
            Debug.Log("NullImage");
        }
        else if(other.gameObject.tag == "KillObject")
        {
            Debug.Log("KillObject");
        }
        other.gameObject.SetActive(false);
    }
}
