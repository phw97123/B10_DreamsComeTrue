using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ĳ����Animator
    public RuntimeAnimatorController[] characterAnimController;
    public GameObject[] playerKillObjectPrefab; 
    [SerializeField] public GameObject player;
    private PlayerMoveMent playerMovement;
    private PlayerController playerController; 
    private Animator playerAnimator;
    

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMoveMent>();
        playerController = player.GetComponent<PlayerController>(); 

        //ĳ���� ����
        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();
            //���� �����߿� �ִϸ����� ��Ʈ�ѷ��� �������� �����ϰ� �����ϴµ� ���
            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];

            //ĳ���� �ɷ�ġ ����
            switch (PlayerPrefs.GetInt("CharacterNumber"))
            {
                case 0:
                    playerController.StunTime = 1.0f;
                    playerMovement.Speed = 1;
                    Instantiate(playerKillObjectPrefab[0]); 
                    break;
                case 1:
                    playerController.StunTime = 1.25f;
                    Instantiate(playerKillObjectPrefab[1]);
                    break;
                case 2:
                    playerController.StunTime = 0.75f;
                    Instantiate(playerKillObjectPrefab[2]);
                    break;
                case 3:
                    playerMovement.Speed = 1.25f;
                    Instantiate(playerKillObjectPrefab[3]);
                    break;
                default:
                    Debug.Log("ĳ���Ͱ� �����ϴ�.");
                    break;
            }
        }

    }
}
