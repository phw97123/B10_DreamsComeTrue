using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage : MonoBehaviour
{
    float time;
    public float _fadeTime = 1f;
    public TextMeshProUGUI StageTxt;
    // GameManager
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.time > 5 && GameManager.Instance.time < 7)
        {
            
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / _fadeTime);
            transform.localScale = Vector3.one * (1 + time);
                
        }
        else if (GameManager.Instance.time > 10 && GameManager.Instance.time < 12)
        {

            
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / _fadeTime);
        }
        else
        {
            resetAnim();
            resetAnimSize();
            //this.gameObject.SetActive(false);        
        }
        time += Time.deltaTime;
    }

    public void resetAnim()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        this.gameObject.SetActive(true);
    }
    public void resetAnimSize()
    {
        time = 0;
        transform.localScale = Vector3.one;
    }

    //float time;

    //// Update is called once per frame
    //void Update()
    //{

    //    transform.localScale = Vector3.one * (1 + time);
    //    time += Time.deltaTime;
    //    if (time > 1f)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}

    //public void resetAnim()
    //{
    //    time = 0;
    //    transform.localScale = Vector3.one;
    //}
}
