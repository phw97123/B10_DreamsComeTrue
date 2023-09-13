using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
    public float killTime; //�ڵ��� ���̵� �ֽýð�
    public float fallTime; // �������� ������Ʈ �ֱ�ð�
    public float numberTime;//�������� ������Ʈ �� �ֱ�ð�
    public float spawnTime; // �����ϴ� �ֱ�
    public int fallMaxSpeed;//�ֱ� �ִ뽺�ǵ�
    public int fallMiniSpeed;//�ֱ� �ּҽ��ǵ�
    public const string UIMAINHANDLER_NAME = "uiMainHandler";
    public const string SAMPLESCENE = "SampleScene";
    int a = 0;
    int b = 0;
    int c = 0;
    bool isDanger = false;

    private void Awake()
    {
        fallMaxSpeed = 1;
        fallMiniSpeed = 1;
        SpawnPrefabs.spawntime = 0.5f;
        SpawnPrefabs._spawnNum = 3;
        //ObjectsFall.speed = 2;
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
        //if(isDanger=true)
        //{
        //    reSetting();
        //}
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
        //time += Time.deltaTime;
        ////Debug.Log(time);
        //if (time < 15)
        //{
        //    Debug.Log("Stage 1");
        //    ObjectsFall.speed = Random.Range(2, 8);
        //    PlayerKillObjectMove.stageSpeed = 2;
        //}
        //else if (15 < time && time < 30)
        //{
        //    Debug.Log("Stage 2");
        //    ObjectsFall.speed = Random.Range(4, 10);
        //    PlayerKillObjectMove.stageSpeed = 4;
        //}
        //else if (30 < time && time < 45)
        //{
        //    Debug.Log("Stage 3");
        //    ObjectsFall.speed = Random.Range(6, 12);
        //    PlayerKillObjectMove.stageSpeed = 6;
        //}
        //else
        //{
        //    Debug.Log("Stage 4");
        //    ObjectsFall.speed = Random.Range(11, 15);
        //    PlayerKillObjectMove.stageSpeed = 8;
        //}
    }

    IEnumerator HpAttack()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnPrefabs._spawnNum = a;
        fallMaxSpeed = b;
        fallMiniSpeed = c;

    }
    public void reSetting()
    {
        SpawnPrefabs._spawnNum = a;
        fallMaxSpeed = b;
        fallMiniSpeed = c;
        //�Ұ��� �޾Ƽ� �ȴٸ� �� ����� �����϶�
    }

    public void LevelUp()
    {

        //int levelTime = 0;
        time += Time.deltaTime;
        killTime += Time.deltaTime; //�ڵ��� ���̵� �ֽýð�
        fallTime += Time.deltaTime; // �������� ������Ʈ �ֱ�ð�
        numberTime += Time.deltaTime;//
        spawnTime += Time.deltaTime;
        //SpawnPrefabs.spawntime = 4;

        if (killTime > 6)   //�÷��̾� ų ������Ʈ �ӵ��ֱ�
        {
            SpawnPrefabs.spawntime -= 1; //�����ֱ�         
            PlayerKillObjectMove.stageSpeed += 1;
            Debug.Log("�� ��������!");
            killTime = 0;

        }
        if (numberTime > 6)   //�������� �ø��� �ֱ�
        {
            SpawnPrefabs._spawnNum += 1;
            numberTime = 0;
          //  a = SpawnPrefabs._spawnNum;
        }
        if (fallTime > 5)  //�������� �ӵ� ���̴� �ֱ�
        {
            fallMaxSpeed += 1;
            fallTime = 0;
         //   b = fallMaxSpeed;
          //  c = fallMiniSpeed;
        }
        //if (time > 10 && time < 11)
        //{//����� �Ұ��Ѱ��ֱ� �Ѱ��ְ� �ð��� 11�� ������ �ٷ� �� �Ѱ��ֱ�
        //    isDanger = true;
        //    Debug.Log("�����");
        //    SpawnPrefabs._spawnNum = 10;
        //    fallMaxSpeed = 0;
        //    fallMiniSpeed = 5;
        //    //������ Ȯ���� �����
        //    //��� ����鼭 
        //}
        //else
        //{
        //    isDanger = false;
        //}

    }

}
    





