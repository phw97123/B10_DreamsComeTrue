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

        //start ��ư
        startButton = canvasTransform.Find("StartBtn").GetComponent<Button>();

        //����
        helpButton = canvasTransform.Find("HelpBtn").GetComponent<Button>();
        helpPanel = canvasTransform.Find("HelpPanel").gameObject;
        helpExitBtn = helpPanel.transform.Find("HelpExit").GetComponent<Button>();

        //ĳ���� ���� 
        leftBtn = canvasTransform.transform.Find("LeftBtn").GetComponent<Button>();
        rightBtn = canvasTransform.transform.Find("RightBtn").GetComponent<Button>();
        selectCharacter = GameObject.Find("SelectCharacter").gameObject;
        spriteRenderer = selectCharacter.GetComponent<SpriteRenderer>();
      

        //ĳ���� ���� 
        nameText = canvasTransform.transform.Find("NameTxt").GetComponent<Text>();
        abilityText = canvasTransform.transform.Find("AbilityTxt").GetComponent<Text>();
        explanationText = canvasTransform.transform.Find("ExplanationTxt").GetComponent<Text>();
    }
    void Start()
    {
        //��������Ʈ �ʱ�ȭ 
        spriteRenderer.sprite = characterSprite[0];

        //ĳ���� ���� �ʱ�ȭ 
        nameText.text = "PHW";
        abilityText.text = "����ð� 1��, �ӵ� 1";
        explanationText.text = "PlayStation5�� �����մϴ�."; 


        //��ư �̺�Ʈ
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

        //Sprite ũ�Ⱑ �޶� ��ġ ���� �� ĳ���� ����
        if (spriteCount == 0) //PHW
        {
            currentPosition.y = -1.5f;

            nameText.text = "PHW";
            abilityText.text = "����ð� 1, �ӵ� 1";
            explanationText.text = "PlayStation5�� �����մϴ�.";
        }
        else if(spriteCount == 1) //JBJ
        {
            currentPosition.y = -2.4f;

            nameText.text = "JBJ";
            abilityText.text = "ũ�� Down, ����ð� 1.25";
            explanationText.text = "FIFA�� �����մϴ�.";
        }
        else if(spriteCount == 2)//KEJ
        {
            currentPosition.y = -2f;

            nameText.text = "KEJ";
            abilityText.text = "����ð� 0.75";
            explanationText.text = "������ �����մϴ�.";
        }
        else //JJH
        {
            currentPosition.y = -1.9f;

            nameText.text = "JJH";
            abilityText.text = "�ӵ� 1.25";
            explanationText.text = "�ڴ� ���� �����մϴ�";
        }

        selectCharacter.transform.position = currentPosition;
        spriteRenderer.sprite = characterSprite[spriteCount];
    }
}
