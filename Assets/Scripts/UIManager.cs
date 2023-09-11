using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool pauseOn = false;
    public GameObject canvas;
    private GameObject backGround;
    private GameObject pausePanel;
    private GameObject resultPanel; 
    
    void Awake()
    {
        backGround = canvas.transform.Find("BackGround").gameObject; 
        
        resultPanel = canvas.transform.Find("ResultPanel").gameObject;
        pausePanel = canvas.transform.Find("PausePanel").gameObject;
        pausePanel.SetActive(false);
        resultPanel.SetActive(false);
    }
    public void ActivePauseButton()
    {
        if (!pauseOn) // 일시 중지 아니면
        {
            Time.timeScale = 0;
            //backGround.SetActive(false);
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            //backGround.SetActive(true);
            pausePanel.SetActive(false);
        }
        pauseOn = !pauseOn; // 불 값 반전
    }

    public void ActiveResult()
    {
        if(PlayerController.IsDead == true)
        {
            resultPanel.SetActive(true);
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
