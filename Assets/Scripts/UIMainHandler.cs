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

    public const string UIMAINHANDLER_NANE = "uiMainHandler";

    private void Awake()
    {
        UIManager.Instance.AddUIScript(UIMAINHANDLER_NANE, this);
        pausePanel.SetActive(false);
    }

    public void ActivePauseButton()
    {
        if (!pauseOn)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
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

    void Update()
    {
        if(PlayerController.IsDead == true)
        {
            Time.timeScale = 0;
            ActiveResult();
        }
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        PlayerController.IsDead = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        PlayerController.IsDead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
