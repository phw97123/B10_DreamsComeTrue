using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyping : MonoBehaviour
{
    public List<string> str;
    private Text typingText;
    private float time;
    private int num;
    private int count;
    private string inputStr;
    private bool isStartTyping;

    public void Awake()
    {
        time = 0;
        typingText = GetComponent<Text>();
        isStartTyping = false;
        num = PlayerPrefs.GetInt("CharacterNumber");
        inputStr = str[num];
        count = 0;
    }
    public void Start()
    {
        
    }

    void Update()
    {
        if (count < inputStr.Length && PlayerController.IsDead)
        {
            time += Time.unscaledDeltaTime;
        }
        if (time > 1.4f && PlayerController.IsDead)
        {
            isStartTyping = true;
        }
        if (time > 0.1f && PlayerController.IsDead && isStartTyping)
        {
            textPrint();
            time = 0;
        }
    }

    void textPrint()
    {
        typingText.text += inputStr[count];
        count++;
    }
}
