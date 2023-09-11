using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //캐릭터Animator
    public RuntimeAnimatorController[] characterAnimController;
    private GameObject player;
    private PlayerMoveMent playerMovement; 
    private Animator playerAnimator;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMoveMent>(); 

        //캐릭터 정보
        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();
            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];

            //캐릭터 능력치 조정
            switch(PlayerPrefs.GetInt("CharacterNumber"))
            {
                case 0:
                    playerMovement.StunTime = 1.0f;
                    playerMovement.Speed = 1;
                    break; 
                case 1:
                    playerMovement.StunTime = 1.25f; 
                    break;
                case 2:
                    playerMovement.StunTime = 0.75f;
                    break;
                case 3:
                    playerMovement.Speed = 1.25f; 
                    break;
                default:
                    Debug.Log("캐릭터가 없습니다."); 
                    break; 
            }
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
