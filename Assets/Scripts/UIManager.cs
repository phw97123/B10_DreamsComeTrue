using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool pauseOn = false;
    public GameObject canvas;
    public GameObject pausePanel;
    private GameObject pauseText;
    private GameObject resultText;
    private GameObject continueButton;
    private GameObject finalScole;
    
    void Awake()
    {
        pausePanel = canvas.transform.Find("PausePanel").gameObject;
        pauseText = pausePanel.transform.Find("PauseText").gameObject;
        resultText = pausePanel.transform.Find("ResultText").gameObject;
        continueButton = pausePanel.transform.Find("ContinueButton").gameObject;
        finalScole = pausePanel.transform.Find("FinalScore").gameObject;
        pausePanel.SetActive(false);
    }
    public void ActivePauseButton()
    {
        if (!pauseOn) // 일시 중지 아니면
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }
        pauseOn = !pauseOn; // 불 값 반전
    }

    public void ActiveResult()
    {
        if(PlayerController.IsDead == true)
        {
            pausePanel.SetActive(true);
            pauseText.SetActive(false);
            resultText.SetActive(true);
            continueButton.SetActive(false);
            finalScole.SetActive(true);
        }
    }

    public void RetryButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene"); // 현재 씬 다시 로드
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
