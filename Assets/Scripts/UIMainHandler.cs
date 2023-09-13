using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainHandler : MonoBehaviour
{
    private bool pauseOn = false;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Text pauseText;
    [SerializeField] private Text resultText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Text finalScore;
    [SerializeField] private GameObject pauseButton;

    public const string UIMAINHANDLER_NANE = "uiMainHandler";

    private void Awake()
    {
        UIManager.Instance.AddUIScript(UIMAINHANDLER_NANE, this);
        pausePanel.SetActive(false);
        AudioManager.Instance.PlayBgm(true);
        pauseButton.SetActive(true);
        
    }

    void Start()
    {

        if (retryButton != null)
        {
            retryButton.onClick.AddListener(GameManager.Instance.RetryButton);
        }
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(GameManager.Instance.QuitButton);
        }

    }


    public void ActivePauseButton()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.button);
        
        if (!pauseOn)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
        }
        pauseOn = !pauseOn;
        
    }

    public void ActiveResult()
    {
        pausePanel.SetActive(true);
        pauseText.gameObject.SetActive(false);
        resultText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        finalScore.gameObject.SetActive(true);
    }

}
