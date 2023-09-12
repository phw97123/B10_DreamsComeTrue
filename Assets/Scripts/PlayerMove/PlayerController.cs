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
                Debug.Log("�� �����߾�");
                break;
            case "NullImage":
                BadItem();
                Debug.Log("������ �� �������...");
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

    public void BugDieItemOn()  // ������ �����۽���޼���
    {



        if (BugDie == 16)   //ó�� �����ϴ� �Ŷ��
        {
            BugDieItemCountTxt.text = BugDie.ToString();
            BugDieItem.SetActive(true);  //Ȱ��ȭ �����ֱ�
                                         //  ItemsPosition(BugDieItem);   //��ġ ����
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
            Debug.Log(BugDie + "����");
            if (BugDie == 0)
            {
                Debug.Log("�Լ� ������ �������ϴ�");    //-> �̰��� �޼���� �����
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
    {//���������� �� �� �ִ� �޼��� ã�ƺ���
        SpeedItem.SetActive(true);
        playerMovement.Speed = 2.5f;
        Speedtime -= Time.deltaTime;
        // Debug.Log(Speedtime);
        SpeedItimeTxt.text = Speedtime.ToString("N2");


        //�÷��̾��� ���ǵ� ������Ű�� �޼��常 �߰��ϸ� �±�
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
            // ItemsPosition(SpeedItem);
            Debug.Log("���ǵ� ������");
            SpeedItemOn();
        }
        else
        {
            Speedtime = 5;
            SpeedItemOn();
        }
    }

    public void JumpItemOn()
    {//���������� �� �� �ִ� �޼��� ã�ƺ���
        JumpItem.SetActive(true);
        playerMovement.JumpForce = 10;
        Jumptime -= Time.deltaTime;
        //Debug.Log(Jumptime);
        JumpItimeTxt.text = Jumptime.ToString("N2");


        //�÷��̾��� ���� ������Ű�� �޼��常 �߰��ϸ� �±�
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
            Debug.Log("���� ���͸�");
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


        //�÷��̾��� ���� ������Ű�� �޼��常 �߰��ϸ� �±�
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
            Debug.Log("ê ����Ƽ ����");
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
        Debug.Log("�� �ʱ�ȭ");
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
    //    //����Ʈ�� ����� ��� �¿�Ƽ�갡 true���� �˾ƾ��Ѵ�. ����� �˰� �� ��ġ�� �°� �������� �ο��Ѵ�.
    //    //�����ų ������ �ϱ�
    //    int count = 0;
    //    for (int i = 0; i < Items.Count; i++)
    //    {
    //        if (Items[i].activeSelf)
    //        {
    //            count++;

    //        }
    //        //������ ��ġ ����Ʈ ���� �����ϱ�

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
    //    //Debug.Log("1�ʸ��� �ȴٰ�?");
    //    while (time < 5)
    //    {

    //        time +=1;
    //        Debug.Log(time);
    //        yield return new WaitForSeconds(1.0f);

    //    }

    //}
}