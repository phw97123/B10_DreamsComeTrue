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

    public Sprite[] characterSprite;

    int spriteCount = 0;

    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform;

        startButton = canvasTransform.Find("StartBtn").GetComponent<Button>();

        helpButton = canvasTransform.Find("HelpBtn").GetComponent<Button>();
        helpPanel = canvasTransform.Find("HelpPanel").gameObject;
        helpExitBtn = helpPanel.transform.Find("HelpExit").GetComponent<Button>();

        leftBtn = canvasTransform.transform.Find("LeftBtn").GetComponent<Button>();
        rightBtn = canvasTransform.transform.Find("RightBtn").GetComponent<Button>();
        selectCharacter = GameObject.Find("SelectCharacter").gameObject; 

        spriteRenderer = selectCharacter.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = characterSprite[0]; 

        //버튼
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

        //Sprite 크기가 달라서 위치 조정 
        if (spriteCount == 0)
        {
            currentPosition.y = -1.5f;
        }
        else if(spriteCount == 1)
        {
            currentPosition.y = -2f;
        }
        else if(spriteCount == 2)
        {
            currentPosition.y = -2f; 
        }
        else
        {
            currentPosition.y = -2.2f; 
        }

        selectCharacter.transform.position = currentPosition;
        spriteRenderer.sprite = characterSprite[spriteCount];
    }
}
