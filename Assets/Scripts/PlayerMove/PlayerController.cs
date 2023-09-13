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

    private SpriteRenderer playerSpriteRenderer; 

    private void Awake()
    {
        Score = 0;
        playerMovement = player.GetComponent<PlayerMoveMent>();
        playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>(); 
        BugDie = 16;
        Speedtime = 5f;
        Jumptime = 5;
        Items.Add(BugDieItem);
        Items.Add(SpeedItem);
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
                break;
            case "NullImage":
                BadItem();
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

    IEnumerator StunEffect()
    {
        // WaitForSeconds ��ü�� �̸� �����ϰ� ������ �Ҵ��Ͽ� ������ ������ �ּ�ȭ 
        WaitForSeconds waitTime = new WaitForSeconds(0.2f);
        for (int i = 0; i <= 2; i++)
        {
            playerSpriteRenderer.color = Color.gray;
            yield return waitTime;
            playerSpriteRenderer.color = Color.white;
            yield return waitTime;
        }
    }

    private void OutStun()
    {
        GetComponent<PlayerInput>().enabled = true;
        _isStun = false;
    }

    public void BugDieItemOn()  // ������ �����۽���޼���
    {



        if (BugDie == 16)   //ó�� �����ϴ� �Ŷ��
        {
            BugDieItemCountTxt.text = BugDie.ToString();
            BugDieItem.SetActive(true);  //Ȱ��ȭ �����ֱ�
                                   
        }
        else  // ������ ������ �� �Ծ��ٸ�
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
            if (BugDie == 0)
            {
                BugDie = 16;
                BugDieItem.SetActive(false);
            }
        }
        else
        {
            GetComponent<PlayerInput>().enabled = false;
            _isStun = true;

            StartCoroutine(StunEffect()); 
        }
    }

    public void SpeedItemOn()
    {
        SpeedItem.SetActive(true);
        playerMovement.Speed = 2.5f;
        Speedtime -= Time.deltaTime;
        SpeedItimeTxt.text = Speedtime.ToString("N2");

        if (Speedtime <= 0)
        {
            //���ǵ� ����
            Speedtime = 5;
            playerMovement.Speed = 1f;
            SpeedItem.SetActive(false);
            
        }
    }
    public void AgainGetSpeed() //�Ծ��µ� �� �Ծ��ٸ�
    {
        if (Speedtime == 5)  //ó���̶��
        {
            SpeedItemOn();
        }
        else
        {
            Speedtime = 5;
            SpeedItemOn();
        }
    }

    public void JumpItemOn()
    {
        JumpItem.SetActive(true);
        playerMovement.JumpForce = 10;
        Jumptime -= Time.deltaTime;
        JumpItimeTxt.text = Jumptime.ToString("N2");

        if (Jumptime <= 0)
        {
            //���� ����
            Jumptime = 5;
            playerMovement.JumpForce = 7;
            JumpItem.SetActive(false);
        }
    }
    public void AgainGetJumpItem() //�Ծ��µ� �� �Ծ��ٸ�
    {
        if (Jumptime == 5)
        {
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
        NotDeadItimeTxt.text = NotDeadtime.ToString("N2");

        if (NotDeadtime <= 0)
        {
            //���� ����
            NotDeadtime = 5;
            NotDeadItem.SetActive(false);
        }
    }
    public void AgainGetNotDeadItem() //�Ծ��µ� �� �Ծ��ٸ�
    {
        if (NotDeadtime == 5)
        {
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
}