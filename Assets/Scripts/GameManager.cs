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
    private BoxCollider2D playerCollider;
    private bool isRunOnce;
    public float killTime; //자동차 난이도 주시시간
    public float fallTime; // 떨어지는 오브젝트 주기시간
    public float numberTime;//떨어지는 오브젝트 수 주기시간
    public float spawnTime; // 스폰하는 주기
    public int fallMaxSpeed;//주기 최대스피드
    public int fallMiniSpeed;//주기 최소스피드

    public const string UIMAINHANDLER_NAME = "uiMainHandler";
    public const string SAMPLESCENE = "SampleScene";
    

    private void Awake()
    {
        fallMaxSpeed = 1;
        fallMiniSpeed = 1;
        
        SpawnPrefabs._spawnNum = 3;
        //ObjectsFall.speed = 2;
        PlayerKillObjectMove.stageSpeed = 1;
        isRunOnce = true;
        playerMovement = player.GetComponent<PlayerMoveMent>();
        playerController = player.GetComponent<PlayerController>();
        playerCollider = player.GetComponent<BoxCollider2D>();

        

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


        if (PlayerPrefs.HasKey("CharacterNumber"))
        {
            playerAnimator = player.GetComponent<Animator>();

            playerAnimator.runtimeAnimatorController = characterAnimController[PlayerPrefs.GetInt("CharacterNumber")];


            switch (PlayerPrefs.GetInt("CharacterNumber"))
            {
                case 0:
                    playerCollider.size = new Vector2(2.3f, 2.7f);
                    playerController.StunTime = 1.0f;
                    playerMovement.Speed = 1;
                    Instantiate(playerKillObjectPrefab[0]);
                    break;
                case 1:
                    playerCollider.size = new Vector2(1.3f, 2.3f);
                    playerController.StunTime = 1.25f;
                    Instantiate(playerKillObjectPrefab[1]);
                    break;
                case 2:
                    playerCollider.size = new Vector2(3f, 2.5f);
                    playerController.StunTime = 0.75f;
                    Instantiate(playerKillObjectPrefab[2]);
                    break;
                case 3:
                    playerCollider.offset = new Vector2(playerCollider.offset.x, 0.8f);
                    playerCollider.size = new Vector2(1.7f, 2.3f);
                    playerMovement.Speed = 1.25f;
                    Instantiate(playerKillObjectPrefab[3]);
                    break;
                default:

                    break;
            }
        }

    }

    void Update()
    {
        if (PlayerController.IsDead == true && isRunOnce)
        {
            Time.timeScale = 0;
            uiMainHandler.ActiveResult();
            AudioManager.Instance.PlayBgm(false);
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.gameover);
            isRunOnce = false;
        }
        LevelUp();
       // Stage();
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
        AudioManager.Instance.PlayBgm(false);
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
           // Debug.Log("Stage 1");
            ObjectsFall.speed = Random.Range(2, 8);
            PlayerKillObjectMove.stageSpeed = 2;
        }
        else if (15 < time && time < 30)
        {
           // Debug.Log("Stage 2");
            ObjectsFall.speed = Random.Range(4, 10);
            PlayerKillObjectMove.stageSpeed = 4;
        }
        else if (30 < time && time < 45)
        {
            //Debug.Log("Stage 3");
            ObjectsFall.speed = Random.Range(6, 12);
            PlayerKillObjectMove.stageSpeed = 6;
        }
        else
        {
           // Debug.Log("Stage 4");
            ObjectsFall.speed = Random.Range(11, 15);
            PlayerKillObjectMove.stageSpeed = 8;
        }
    }
   

    public void LevelUp()
    {
        //int levelTime = 0;
        time += Time.deltaTime;
        killTime += Time.deltaTime; //자동차 난이도 주시시간
        fallTime += Time.deltaTime; // 떨어지는 오브젝트 주기시간
        numberTime += Time.deltaTime;//
        spawnTime += Time.deltaTime;
        

        if (killTime > 6)   //플레이어 킬 오브젝트 속도주기
        {
           
            PlayerKillObjectMove.stageSpeed += 1;
            Debug.Log("나 실행했음!");
            killTime = 0;

        }
        if (numberTime > 8)   //생성숫자 늘리는 주기
        {
            SpawnPrefabs._spawnNum += 1;
            numberTime = 0;
        }
        if (fallTime > 5)  //떨어지는 속도 높이는 주기
        {
            fallMaxSpeed += 1;
            fallTime = 0;
        }
      
    }
}
