using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ĳ����Animator
    public RuntimeAnimatorController[] characterAnimController;
    private GameObject player;
    //private PlayerMoveMent playerMovement; 
    private Animator playerAnimator;

    private void Awake()
    {
        player = GameObject.Find("Player");
        //playerMovement = player.GetComponent<PlayerMoveMent>(); 

        //ĳ���� ����
        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();
            //���� �����߿� �ִϸ����� ��Ʈ�ѷ��� �������� �����ϰ� �����ϴµ� ���
            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];

            //ĳ���� �ɷ�ġ ����
            //switch(PlayerPrefs.GetInt("CharacterNumber"))
            //{
            //    case 0:
            //        playerMovement.StunTime = 1.0f;
            //        playerMovement.Speed = 1;
            //        break; 
            //    case 1:
            //        playerMovement.StunTime = 1.25f; 
            //        break;
            //    case 2:
            //        playerMovement.StunTime = 0.75f;
            //        break;
            //    case 3:
            //        playerMovement.Speed = 1.25f; 
            //        break;
            //    default:
            //        Debug.Log("ĳ���Ͱ� �����ϴ�."); 
            //        break; 
            //}
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
