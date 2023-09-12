using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager Instance;
    private UIMainHandler uiMainHandler;

    public const string UIMAINHANDLER_NANE = "uiMainHandler";
    public const string SAMPLESCENE = "SampleScene";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        uiMainHandler = UIManager.Instance.GetUIScript<UIMainHandler>(UIMAINHANDLER_NANE);
    }
}

