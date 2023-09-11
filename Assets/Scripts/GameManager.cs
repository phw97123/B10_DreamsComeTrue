using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RuntimeAnimatorController[] characterAnimController;
    private GameObject player;
    Animator playerAnimator;
    public int totalFixBug = 0;
    public static GameManager instance;

    
    
        
    
    private void Awake()
    {
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addFixBug(int fixBug)
    {
        totalFixBug += fixBug;
    }
}
