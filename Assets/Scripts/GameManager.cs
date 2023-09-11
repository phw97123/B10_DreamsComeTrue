using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RuntimeAnimatorController[] characterAnimController;
    private GameObject player;
    Animator playerAnimator;
    public static GameManager instance;
    public GameObject BugDieItem;
    public int BugDie;
    public TMP_Text BugDieItemCountTxt;
    private void Awake()
    {
        BugDie = 16;
       
        if (null == instance)
        {
            // �� ���۵ɶ� �ν��Ͻ� �ʱ�ȭ, ���� �Ѿ���� �����Ǳ����� ó��
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // instance��, GameManager�� �����Ѵٸ� GameObject ���� 
            Destroy(this.gameObject);
        }

        player = GameObject.Find("Player");

        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();
            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];
        }
    }
    public void BugDieItemOn()//������ �����Լ�
    {
        // PlayerController���� BugDieItem�� Ȱ��ȭ �Ǿ��ִٸ� ���� ���ϴ°ɷ� ���ǹ� �ɱ�
        if (BugDie == 16)
        {
            BugDieItemCountTxt.text = BugDie.ToString();
            BugDieItem.SetActive(true);
        }
        else
        {
            BugDie = 16;
            BugDieItemCountTxt.text = BugDie.ToString();
            Debug.Log(BugDie + "��");
        }


    }
    public void BugDieItemCount()
    {
        BugDie -= 1;
        BugDieItemCountTxt.text = BugDie.ToString();
        Debug.Log(BugDie + "����");
        if (BugDie == 0)
        {
            Debug.Log("�Լ� ������ �������ϴ�");
            BugDie = 16;
            BugDieItem.SetActive(false);       
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
