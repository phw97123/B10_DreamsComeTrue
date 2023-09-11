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
            // 씬 시작될때 인스턴스 초기화, 씬을 넘어갈때도 유지되기위한 처리
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // instance가, GameManager가 존재한다면 GameObject 제거 
            Destroy(this.gameObject);
        }

        player = GameObject.Find("Player");

        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();
            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];
        }
    }
    public void BugDieItemOn()//아이템 실행함수
    {
        // PlayerController에서 BugDieItem가 활성화 되어있다면 마비 안하는걸로 조건문 걸기
        if (BugDie == 16)
        {
            BugDieItemCountTxt.text = BugDie.ToString();
            BugDieItem.SetActive(true);
        }
        else
        {
            BugDie = 16;
            BugDieItemCountTxt.text = BugDie.ToString();
            Debug.Log(BugDie + "임");
        }


    }
    public void BugDieItemCount()
    {
        BugDie -= 1;
        BugDieItemCountTxt.text = BugDie.ToString();
        Debug.Log(BugDie + "남음");
        if (BugDie == 0)
        {
            Debug.Log("함수 실행이 끝났습니다");
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
