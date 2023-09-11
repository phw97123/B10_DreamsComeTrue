using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class StartSceneController : MonoBehaviour
{
    private Transform canvasTransform; 
    private Button startButton;
    private Button helpButton;
    private GameObject helpPanel;
    private Button helpExitBtn;
    private Button leftBtn; 
    private Button rightBtn;
    private GameObject selectCharacter;
    private SpriteRenderer spriteRenderer;

    private Text nameText;
    private Text abilityText;
    private Text explanationText; 

    public Sprite[] characterSprite;

    int spriteCount = 0;


    private void Awake()
    {
        canvasTransform = GameObject.Find("Canvas").transform;

        //start 버튼
        startButton = canvasTransform.Find("StartBtn").GetComponent<Button>();

        //도움말
        helpButton = canvasTransform.Find("HelpBtn").GetComponent<Button>();
        helpPanel = canvasTransform.Find("HelpPanel").gameObject;
        helpExitBtn = helpPanel.transform.Find("HelpExit").GetComponent<Button>();

        //캐릭터 선택 
        leftBtn = canvasTransform.transform.Find("LeftBtn").GetComponent<Button>();
        rightBtn = canvasTransform.transform.Find("RightBtn").GetComponent<Button>();
        selectCharacter = GameObject.Find("SelectCharacter").gameObject;
        spriteRenderer = selectCharacter.GetComponent<SpriteRenderer>();
      

        //캐릭터 설명 
        nameText = canvasTransform.transform.Find("NameTxt").GetComponent<Text>();
        abilityText = canvasTransform.transform.Find("AbilityTxt").GetComponent<Text>();
        explanationText = canvasTransform.transform.Find("ExplanationTxt").GetComponent<Text>();
    }
    void Start()
    {
        //스프라이트 초기화 
        spriteRenderer.sprite = characterSprite[0];

        //캐릭터 설명 초기화 
        nameText.text = "PHW";
        abilityText.text = "마비시간 1초, 속도 1";
        explanationText.text = "PlayStation5를 좋아합니다."; 


        //버튼 이벤트
        if (startButton != null)
        {
            //Button이 클릭되었을 때 호출되는 핸들러 
            startButton.onClick.AddListener(StartGame);

        }

        if(helpButton != null)
        {
            helpButton.onClick.AddListener(OpenHelp);
            
        }

        if(helpExitBtn != null)
        {
            helpExitBtn.onClick.AddListener(CloseHelp);
            
        }

        if(leftBtn != null)
        {
            leftBtn.onClick.AddListener(() => ShowCharacter(true)); 
        }

        if(rightBtn != null)
        {
            rightBtn.onClick.AddListener(() => ShowCharacter(false));
        }


    }

    void Update()
    {
    }

    private void StartGame()
    {
        PlayerPrefs.SetInt("CharacterNumber", spriteCount);
        SceneManager.LoadScene("SampleScene"); 
    }

    private void OpenHelp()
    {
        helpPanel.SetActive(true);
        leftBtn.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
    }

    private void CloseHelp()
    {
        helpPanel.SetActive(false);
        leftBtn.gameObject.SetActive(true);
        rightBtn.gameObject.SetActive(true);
    }

    private void ShowCharacter(bool moveLeft)
    {
        //캐릭터 스프라이트가 배열에 없다면 아무 작업도 하지 않고 종료 
        if (characterSprite.Length == 0)
            return;

        //왼쪽 버튼
        if (moveLeft)
        {
            // 이전 캐릭터의 인덱스를 구하고 음수가 되지 않기 위해 배열의 길이를 더하고 배열의 길이를 초과하지 않게 처리 
          
            spriteCount = (spriteCount - 1 + characterSprite.Length) % characterSprite.Length;
        }
        else //오른쪽 버튼
        {
            //배열의 길이를 나눈 나머지를 사용함으로써 배열의 길이르 초과하지 않게 처리 
            spriteCount = (spriteCount + 1) % characterSprite.Length;
        }

        Vector3 currentPosition = selectCharacter.transform.position;

        //Sprite 크기가 달라서 위치 조정 및 캐릭터 설명
        if (spriteCount == 0) //PHW
        {
            currentPosition.y = -1.5f;

            nameText.text = "PHW";
            abilityText.text = "마비시간 1, 속도 1";
            explanationText.text = "PlayStation5를 좋아합니다.";
        }
        else if(spriteCount == 1) //JBJ
        {
            currentPosition.y = -2.4f;

            nameText.text = "JBJ";
            abilityText.text = "크기 Down, 마비시간 1.25";
            explanationText.text = "FIFA를 좋아합니다.";
        }
        else if(spriteCount == 2)//KEJ
        {
            currentPosition.y = -2f;

            nameText.text = "KEJ";
            abilityText.text = "마비시간 0.75";
            explanationText.text = "와인을 좋아합니다.";
        }
        else //JJH
        {
            currentPosition.y = -1.9f;

            nameText.text = "JJH";
            abilityText.text = "속도 1.25";
            explanationText.text = "자는 것을 좋아합니다";
        }

        selectCharacter.transform.position = currentPosition;
        spriteRenderer.sprite = characterSprite[spriteCount];
    }
}
