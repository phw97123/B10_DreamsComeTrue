using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Score }
    public InfoType type;

    Text myText;
    

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    void LateUpdate()
    {
        switch (type)
        { 
            case InfoType.Score:
                myText.text = string.Format("{0:F0} 개의 버그 해결!", PlayerController.Score);
                break;
        }
    }
}
