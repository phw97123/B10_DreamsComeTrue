using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action onJumpEvent; 

    public static int Score = 0;
    public static bool IsDead = false;
    public float StunTime = 1;
    private bool _isStun = false;
    private float _time = 0;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallJumpEvent()
    {
        onJumpEvent?.Invoke(); 
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
        switch (other.gameObject.tag)
        {
            case "BadBug":
                GetComponent<PlayerInput>().enabled = false;
                _isStun = true;
                break;
            case "FixBug":
                Score++;
                break;
            case "Battery":
                break;
            case "ChatGpt":
                break;
            case "CPU":
                break;
            case "Insecticide":
                break;
            case "NullImage":
                break;
            case "KillObject":
                IsDead = true;
                break;
        }
        other.gameObject.SetActive(false);
    }

    private void OutStun()
    {
        GetComponent<PlayerInput>().enabled = true;
        _isStun = false;
    }
    //public void BugDieItemOn()//아이템 실행함수
    //{
        // PlayerController에서 BugDieItem가 활성화 되어있다면 마비 안하는걸로 조건문 걸기
    //    if (BugDie == 16)
    //    {
    //        BugDieItemCountTxt.text = BugDie.ToString();
    //        BugDieItem.SetActive(true);
    //    }
    //    else
    //    {
    //        BugDie = 16;
    //        BugDieItemCountTxt.text = BugDie.ToString();
    //        Debug.Log(BugDie + "임");
    //    }


    //}
    //public void BugDieItemCount()
    //{
    //    BugDie -= 1;
    //    BugDieItemCountTxt.text = BugDie.ToString();
    //    Debug.Log(BugDie + "남음");
    //    if (BugDie == 0)
    //    {
    //        Debug.Log("함수 실행이 끝났습니다");
    //        BugDie = 16;
    //        BugDieItem.SetActive(false);
    //    }
    //}
}
