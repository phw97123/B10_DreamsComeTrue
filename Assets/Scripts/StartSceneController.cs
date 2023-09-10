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

        //��ư
        if (startButton != null)
        {
            //Button�� Ŭ���Ǿ��� �� ȣ��Ǵ� �ڵ鷯 
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
        //ĳ���� ��������Ʈ�� �迭�� ���ٸ� �ƹ� �۾��� ���� �ʰ� ���� 
        if (characterSprite.Length == 0)
            return;

        //���� ��ư
        if (moveLeft)
        {
            // ���� ĳ������ �ε����� ���ϰ� ������ ���� �ʱ� ���� �迭�� ���̸� ���ϰ� �迭�� ���̸� �ʰ����� �ʰ� ó�� 
          
            spriteCount = (spriteCount - 1 + characterSprite.Length) % characterSprite.Length;
        }
        else //������ ��ư
        {
            //�迭�� ���̸� ���� �������� ��������ν� �迭�� ���̸� �ʰ����� �ʰ� ó�� 
            spriteCount = (spriteCount + 1) % characterSprite.Length;
        }

        Vector3 currentPosition = selectCharacter.transform.position;

        //Sprite ũ�Ⱑ �޶� ��ġ ���� 
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
