using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action onJumpEvent;

    public static int Score;
    public static bool IsDead = false;
    public float StunTime = 1;
    private bool _isStun = false;
    private float _time = 0;

    public GameObject BugDieItem;
    public int BugDie;
    public TMP_Text BugDieItemCountTxt;
    public GameObject SpeedItem;
    public float Speedtime;
    public TMP_Text SpeedItimeTxt;
    public GameObject JumpItem;
    public float Jumptime;
    public TMP_Text JumpItimeTxt;

    public GameObject NotDeadItem;
    public float NotDeadtime;
    public TMP_Text NotDeadItimeTxt;

    public List<GameObject> Items = new List<GameObject>();
    [SerializeField] public GameObject player;
    private PlayerMoveMent playerMovement;

    private void Awake()
    {
        Score = 0;
        playerMovement = player.GetComponent<PlayerMoveMent>();
        BugDie = 16;
        Speedtime = 5f;
        Jumptime = 5;
        Items.Add(BugDieItem);
        //  Items.Add(JumpItem);
        Items.Add(SpeedItem);
        //  Items.Add(NotDeadItem);
    }
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
            if (_time > StunTime)
            {
                OutStun();
                _time = 0;
            }
        }
        if (SpeedItem.activeSelf)
        {
            SpeedItemOn();
        }
        if (NotDeadItem.activeSelf)
        {
            NotDeadItemOn();
        }
        if (JumpItem.activeSelf)
        {
            JumpItemOn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool isInvincibility = true;
        switch (other.gameObject.tag)
        {
            case "BadBug":
                BugDieItemCount();

                break;
            case "FixBug":
                Score++;
                break;
            case "Battery":
                AgainGetJumpItem();
                break;
            case "ChatGpt":
                AgainGetNotDeadItem();
                break;
            case "CPU":
                AgainGetSpeed();
                break;
            case "Insecticide":
                BugDieItemOn();
                Debug.Log("나 실행했어");
                break;
            case "NullImage":
                BadItem();
                Debug.Log("아이템 다 사라졌으...");
                break;
            case "KillObject":
                if (NotDeadItem.activeSelf)
                {
                    NotDeadtime = 5;
                    NotDeadItem.SetActive(false);
                    isInvincibility = false;
                }
                else
                {
                    IsDead = true;
                }
                break;
        }
        if (isInvincibility)
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OutStun()
    {
        GetComponent<PlayerInput>().enabled = true;
        _isStun = false;
    }

    public void BugDieItemOn()  // 살충제 아이템실행메서드
    {



        if (BugDie == 16)   //처음 시작하는 거라면
        {
            BugDieItemCountTxt.text = BugDie.ToString();
            BugDieItem.SetActive(true);  //활성화 시켜주기
                                         //  ItemsPosition(BugDieItem);   //위치 선정
        }
        else  // 아이템 실행중 또 먹었다면
        {
            BugDie = 16;
            BugDieItemCountTxt.text = BugDie.ToString();

        }


    }
    public void BugDieItemCount()
    {
        if (BugDieItem.activeSelf == true)
        {
            BugDie -= 1;
            BugDieItemCountTxt.text = BugDie.ToString();
            Debug.Log(BugDie + "남음");
            if (BugDie == 0)
            {
                Debug.Log("함수 실행이 끝났습니다");    //-> 이것을 메서드로 만들기
                BugDie = 16;
                BugDieItem.SetActive(false);
            }
        }
        else
        {
            GetComponent<PlayerInput>().enabled = false;
            _isStun = true;
        }
    }

    public void SpeedItemOn()
    {//지속적으로 할 수 있는 메서드 찾아보기
        SpeedItem.SetActive(true);
        playerMovement.Speed = 2.5f;
        Speedtime -= Time.deltaTime;
        // Debug.Log(Speedtime);
        SpeedItimeTxt.text = Speedtime.ToString("N2");


        //플레이어의 스피드 증가시키기 메서드만 추가하면 굿굿
        if (Speedtime <= 0)
        {
            //스피드 감소
            Speedtime = 5;
            playerMovement.Speed = 1f;
            SpeedItem.SetActive(false);
            
        }
    }
    public void AgainGetSpeed() //먹었는데 또 먹었다면
    {
        if (Speedtime == 5)  //처음이라면
        {
            // ItemsPosition(SpeedItem);
            Debug.Log("스피드 씨피유");
            SpeedItemOn();
        }
        else
        {
            Speedtime = 5;
            SpeedItemOn();
        }
    }

    public void JumpItemOn()
    {//지속적으로 할 수 있는 메서드 찾아보기
        JumpItem.SetActive(true);
        playerMovement.JumpForce = 10;
        Jumptime -= Time.deltaTime;
        //Debug.Log(Jumptime);
        JumpItimeTxt.text = Jumptime.ToString("N2");


        //플레이어의 점프 증가시키기 메서드만 추가하면 굿굿
        if (Jumptime <= 0)
        {
            //점프 감소
            Jumptime = 5;
            playerMovement.JumpForce = 7;
            JumpItem.SetActive(false);
        }
    }
    public void AgainGetJumpItem() //먹었는데 또 먹었다면
    {
        if (Jumptime == 5)
        {
            Debug.Log("점프 배터리");
            JumpItemOn();
        }
        else
        {
            Jumptime = 5;
            JumpItemOn();
        }
    }


    public void NotDeadItemOn()
    {
        NotDeadItem.SetActive(true);
        NotDeadtime -= Time.deltaTime;
        // Debug.Log(NotDeadtime);
        NotDeadItimeTxt.text = NotDeadtime.ToString("N2");


        //플레이어의 점프 증가시키기 메서드만 추가하면 굿굿
        if (NotDeadtime <= 0)
        {
            //점프 감소
            NotDeadtime = 5;
            NotDeadItem.SetActive(false);
        }
    }
    public void AgainGetNotDeadItem() //먹었는데 또 먹었다면
    {
        if (NotDeadtime == 5)
        {
            Debug.Log("챗 지피티 무적");
            NotDeadItemOn();
        }
        else
        {
            NotDeadtime = 5;
            NotDeadItemOn();
        }
    }

    public void BadItem()
    {
        Debug.Log("다 초기화");
        if (BugDieItem.activeSelf)
        {
            BugDieItem.SetActive(false);
            BugDie = 16;
        }
        if (SpeedItem.activeSelf)
        {
            SpeedItem.SetActive(false);
            Speedtime = 5;
            playerMovement.Speed = 1f;
        }
        if (JumpItem.activeSelf)
        {
            JumpItem.SetActive(false);
            Jumptime = 5;
            playerMovement.JumpForce = 7;
        }
        if (NotDeadItem.activeSelf)
        {
            NotDeadItem.SetActive(false);
            NotDeadtime = 5;
        }
    }

    //public void ItemsPosition(GameObject _Item)
    //{
    //    //리스트를 만들고 담고 셋엑티브가 true인지 알아야한다. 몇개인지 알고 그 위치에 맞게 포지션을 부여한다.
    //    //실행시킬 때마다 하기
    //    int count = 0;
    //    for (int i = 0; i < Items.Count; i++)
    //    {
    //        if (Items[i].activeSelf)
    //        {
    //            count++;

    //        }
    //        //포지션 위치 리스트 만들어서 정렬하기

    //    }
    //    if (count == 1)
    //        _Item.transform.localPosition = new Vector3(-20, 0, 0);
    //    else if (count == 2)
    //        _Item.transform.localPosition = new Vector3(-18, 0, 0);
    //  //  Debug.Log(_Item.transform.localPosition);
    //}
    //IEnumerator enumerator()
    //{
    //    float time = 0;
    //    //Debug.Log("1초마다 된다고?");
    //    while (time < 5)
    //    {

    //        time +=1;
    //        Debug.Log(time);
    //        yield return new WaitForSeconds(1.0f);

    //    }

    //}
}