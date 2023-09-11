using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public static int Score = 0;
    public static bool IsDead = false;
    public float StunTime = 1;
    private bool _isStun = false;
    private float _time = 0;
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    void Update()
    {
        if (_isStun)
        {
            _time += Time.deltaTime;
            if(_time > StunTime)
            {
                OutStun();
                _time = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BadBug")
        {
            GetComponent<PlayerInput>().enabled = false;
            _isStun = true;
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
            IsDead = true;
        }
        other.gameObject.SetActive(false);
    }

    private void OutStun()
    {
        GetComponent<PlayerInput>().enabled = true;
        _isStun = false;
    }
}
