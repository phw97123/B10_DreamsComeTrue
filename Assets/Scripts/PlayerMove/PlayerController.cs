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
    //public void BugDieItemOn()//������ �����Լ�
    //{
        // PlayerController���� BugDieItem�� Ȱ��ȭ �Ǿ��ִٸ� ���� ���ϴ°ɷ� ���ǹ� �ɱ�
    //    if (BugDie == 16)
    //    {
    //        BugDieItemCountTxt.text = BugDie.ToString();
    //        BugDieItem.SetActive(true);
    //    }
    //    else
    //    {
    //        BugDie = 16;
    //        BugDieItemCountTxt.text = BugDie.ToString();
    //        Debug.Log(BugDie + "��");
    //    }


    //}
    //public void BugDieItemCount()
    //{
    //    BugDie -= 1;
    //    BugDieItemCountTxt.text = BugDie.ToString();
    //    Debug.Log(BugDie + "����");
    //    if (BugDie == 0)
    //    {
    //        Debug.Log("�Լ� ������ �������ϴ�");
    //        BugDie = 16;
    //        BugDieItem.SetActive(false);
    //    }
    //}
}
