using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public RuntimeAnimatorController[] characterAnimController;
    public GameObject[] playerKillObjectPrefab; 
    [SerializeField] public GameObject player;
    private PlayerMoveMent playerMovement;
    private PlayerController playerController; 
    private Animator playerAnimator;
    public static GameManager Instance;
    private UIMainHandler uiMainHandler;

    public const string UIMAINHANDLER_NAME = "uiMainHandler";
    public const string SAMPLESCENE = "SampleScene";
    

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMoveMent>();
        playerController = player.GetComponent<PlayerController>(); 

        
        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();
            
            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];

            
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
                    
                    break;
            }
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {
        uiMainHandler = UIManager.Instance.GetUIScript<UIMainHandler>(UIMAINHANDLER_NAME);
    }

    void Update()
    {
        if (PlayerController.IsDead == true)
        {
            Time.timeScale = 0;
            uiMainHandler.ActiveResult();
            AudioManager.Instance.PlayBgm(false);
        }
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        PlayerController.IsDead = false;

        UIManager.Instance.RemoveUIScript(UIMAINHANDLER_NAME); 
        SceneManager.LoadScene("SampleScene");
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);
    }

    public void QuitButton()
    {
        PlayerController.IsDead = false;
        Time.timeScale = 1;
        UIManager.Instance.RemoveUIScript(UIMAINHANDLER_NAME);
        SceneManager.LoadScene("StartScene");
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);
    }
}
