using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SEJTimer : MonoBehaviour
{
    public static SEJTimer instance;

    public TextMeshProUGUI timerTxt;

    float maxTime = 1800f; //30Ка=1800f
    int min;
    float sec; 
    public bool isEnded;

    private void Awake()
    {
       if(instance==null)
       {
           instance = this;
       }
    }
    void Update()
    {
      //if (isEnded) return;
      CheckTimer();
    }
    void CheckTimer()
    {
        maxTime -= Time.deltaTime;

        if (maxTime > 60f)
        {
            min = (int)maxTime / 60;
            sec = maxTime % 60;
            
            timerTxt.text = "" + min.ToString("00") + ":" + sec.ToString("00");

        }
      
        if (maxTime < 60f && maxTime >= 10f)
        {
            timerTxt.text = "" + (int)maxTime;
        }
        if (maxTime < 10f)
        {
            timerTxt.text = "0" + (int)maxTime;
        }
        if (maxTime <= 0)
        {
            timerTxt.text = "TimeOver";
        }
    }
}
