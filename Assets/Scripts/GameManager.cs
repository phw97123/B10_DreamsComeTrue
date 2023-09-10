using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RuntimeAnimatorController[] characterAnimController;
    private GameObject player;
    Animator playerAnimator;

    private void Awake()
    {
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
}
