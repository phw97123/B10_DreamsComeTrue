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
