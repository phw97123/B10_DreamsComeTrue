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
                myText.text = string.Format("Score: {0:F0}", PlayerController.Score);
                break;
        }
    }
}
