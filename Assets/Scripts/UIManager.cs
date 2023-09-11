using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool pauseOn = false;
    private GameObject backGround;
    private GameObject pausePanel;
    private GameObject resultPanel; 

    void Awake()
    {
        backGround = GameObject.Find("Canvas").transform.Find("BackGround").gameObject; 
        pausePanel = GameObject.Find("Canvas").transform.Find("PausePanel").gameObject;
      //  resultPanel = GameObject.Find("Canvas").transform.Find("ResultPanel").gameObject; 
    }
    public void ActivePauseButton()
    {
        if (!pauseOn) // 일시 중지 아니면
        {
            Time.timeScale = 0;
            backGround.SetActive(false);
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            backGround.SetActive(true);
            pausePanel.SetActive(false);
        }
        pauseOn = !pauseOn; // 불 값 반전
    }

    public void ActiveResult()
    {
        // 죽는 함수
        // 이기는 함수 
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
