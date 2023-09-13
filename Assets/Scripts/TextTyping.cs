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

    void Update()
    {
        if (count < inputStr.Length && PlayerController.IsDead)
        {
            time += Time.unscaledDeltaTime;
        }
        else if (isStartTyping)
        {
            OnDeadAudio(PlayerPrefs.GetInt("CharacterNumber"));
            isStartTyping = false;
        }
        if (time > 1.4f && PlayerController.IsDead)
        {
            isStartTyping = true;
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Typing);
        }
        if (time > 0.1f && PlayerController.IsDead && isStartTyping)
        {
            textPrint();
            time = 0;
        }
    }

    private void OnDeadAudio(int num)
    {
        switch (num)
        {
            case 0:
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.PS5);
                break;
            case 1:
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.FIFA);
                break;
            case 2:
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.Wine);
                break;
            case 3:
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.SleepSound);
                break;
        }
    }

    void textPrint()
    {
        typingText.text += inputStr[count];
        count++;
    }
}
