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
    public float time;
    int i;
    public const string UIMAINHANDLER_NAME = "uiMainHandler";
    public const string SAMPLESCENE = "SampleScene";
    

    private void Awake()
    {
        i = 1;
        SpawnPrefabs.leveltime = 2;
        SpawnPrefabs._spawnNum = 3;
        ObjectsFall.speed = 2;
        PlayerKillObjectMove.stageSpeed = 1;
        time = 0;
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
        //Stage();
        LevelUp();
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
    public void Stage()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if (time < 15)
        {
            Debug.Log("Stage 1");
            ObjectsFall.speed = Random.Range(2, 8);
            PlayerKillObjectMove.stageSpeed = 2;
        }
        else if (15 < time && time < 30)
        {
            Debug.Log("Stage 2");
            ObjectsFall.speed = Random.Range(4, 10);
            PlayerKillObjectMove.stageSpeed = 4;
        }
        else if (30 < time && time < 45)
        {
            Debug.Log("Stage 3");
            ObjectsFall.speed = Random.Range(6, 12);
            PlayerKillObjectMove.stageSpeed = 6;
        }
        else
        {
            Debug.Log("Stage 4");
            ObjectsFall.speed = Random.Range(11, 15);
            PlayerKillObjectMove.stageSpeed = 8;
        }
    }

    public void LevelUp()
    {
        //int levelTime = 0;
        time += Time.deltaTime;
        ObjectsFall.speed = Random.Range(2, 8);
        if (time > 4)
        {
            SpawnPrefabs._spawnNum += 1;
            i += 1;
            PlayerKillObjectMove.stageSpeed += 1;
            Debug.Log("나 실행했음!");
            time = 0;

        }
        // ObjectsFall.speed = (Random.Range(1, 4));
        // 시간에따라 난이도 증가
        // 시간에 따라 벌레의 종류가 증가 
    }
}
