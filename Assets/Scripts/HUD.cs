using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Health, Score }
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Health:
                //float curHealth = GameManager.instance.hp;
                //float maxHealth = GameManager.instance.maxHp;
                //mySlider.value = curHealth / maxHealth;
                break;
            case InfoType.Score:
                //myText.text = string.Format("Score: {0:F0}", GameManager.instance.score);
                break;
        }
    }
}
