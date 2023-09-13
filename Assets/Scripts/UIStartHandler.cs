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

    // Start버튼 깜빡이는 효과
    [SerializeField] private TMP_Text startText;
    private float blinkInterval = 0.5f; // 깜박임 제어 
    private float timer;

    public const string UIHANDLER_NAME = "uiStartHandler"; 

    private void Awake()
    {
        //Debug.Log("생성");
        //UIManager의 Dictionary에 추가 
        UIManager.Instance.AddUIScript(UIHANDLER_NAME, this);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.StartScene);
    }

    void Start()
    {
        //캐릭터 설명 초기화 
        nameText.text = "PHW";
        abilityText.text = "마비시간 1초, 속도 1";
        explanationText.text = "PlayStation5를 좋아합니다.";

        if (startButton != null)
        {
            //Button이 클릭되었을 때 호출되는 핸들러 
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

        //시간의 흐름에 따라 텍스트가 투명해진다 
        if (timer < blinkInterval)
            startText.color = new Color(1, 1, 1, 1 - timer);
        else //텍스트가 사라진 후에 alpha값을 시간이 점점 증가하면서 텍스트가 서서히 나타나는 효과
        {
            startText.color = new Color(1, 1, 1, timer);
            if (timer > 1f) // 1보다 크면 0으로 초기화하여 깜빡임 주기 제어
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
            Debug.LogWarning("nameText가 할당되지 않았습니다.");
        }

        if (abilityText != null)
        {
            abilityText.text = characterAbility;
        }
        else
        {
            Debug.LogWarning("abilityText가 할당되지 않았습니다.");
        }

        if (explanationText != null)
        {
            explanationText.text = characterExplanation;
        }
        else
        {
            Debug.LogWarning("explanationText가 할당되지 않았습니다.");
        }
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);
    }
}
