using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class UIStartHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private Button helpExitBtn;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Text nameText;
    [SerializeField] private Text abilityText;
    [SerializeField] private Text explanationText;

    // Start��ư �����̴� ȿ��
    [SerializeField] private TMP_Text startText;
    private float blinkInterval = 0.5f; // ������ ���� 
    private float timer;

    public const string UIHANDLER_NAME = "uiStartHandler"; 

    private void Awake()
    {
        //Debug.Log("����");
        //UIManager�� Dictionary�� �߰� 
        UIManager.Instance.AddUIScript(UIHANDLER_NAME, this);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.StartScene);
    }

    void Start()
    {
        //ĳ���� ���� �ʱ�ȭ 
        nameText.text = "PHW";
        abilityText.text = "����ð� 1��, �ӵ� 1";
        explanationText.text = "PlayStation5�� �����մϴ�.";

        if (startButton != null)
        {
            //Button�� Ŭ���Ǿ��� �� ȣ��Ǵ� �ڵ鷯 
            startButton.onClick.AddListener(StartSceneManager.Instance.StartGame);
        }

        if (helpButton != null)
        {
            helpButton.onClick.AddListener(OpenHelp);
        }

        if (helpExitBtn != null)
        {
            helpExitBtn.onClick.AddListener(CloseHelp);
        }

        if (leftButton != null)
        {
            leftButton.onClick.AddListener(() => StartSceneManager.Instance.ShowCharacter(true));
        }

        if (rightButton != null)
        {
            rightButton.onClick.AddListener(() => StartSceneManager.Instance.ShowCharacter(false));
        }

  
    }

    void Update()
    {
        timer += Time.deltaTime;

        //�ð��� �帧�� ���� �ؽ�Ʈ�� ���������� 
        if (timer < blinkInterval)
            startText.color = new Color(1, 1, 1, 1 - timer);
        else //�ؽ�Ʈ�� ����� �Ŀ� alpha���� �ð��� ���� �����ϸ鼭 �ؽ�Ʈ�� ������ ��Ÿ���� ȿ��
        {
            startText.color = new Color(1, 1, 1, timer);
            if (timer > 1f) // 1���� ũ�� 0���� �ʱ�ȭ�Ͽ� ������ �ֱ� ����
                timer = 0;
        }
    }
    private void OpenHelp()
    {
        helpPanel.SetActive(true);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);

    }

    private void CloseHelp()
    {
        helpPanel.SetActive(false);
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);

    }

    public void SetCharacterInfo(string characterName, string characterAbility, string characterExplanation)
    {
        if (nameText != null)
        {
            nameText.text = characterName;
        }
        else
        {
            Debug.LogWarning("nameText�� �Ҵ���� �ʾҽ��ϴ�.");
        }

        if (abilityText != null)
        {
            abilityText.text = characterAbility;
        }
        else
        {
            Debug.LogWarning("abilityText�� �Ҵ���� �ʾҽ��ϴ�.");
        }

        if (explanationText != null)
        {
            explanationText.text = characterExplanation;
        }
        else
        {
            Debug.LogWarning("explanationText�� �Ҵ���� �ʾҽ��ϴ�.");
        }
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);
    }
}
