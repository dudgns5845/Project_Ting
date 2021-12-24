using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{

    public static PointManager pm;
    public Text currScoreText;
    public Text bestScoreText;
    public int currScore;
    string sCurrScore;
    string sBestScore;
    public int bestScore;

    float currTime;
    public Text startCount;
    public int state;
    public GameObject TargetPattern;



    public GameObject[] pattern;

    public int objCount;

    int Pstate;

    void Awake()
    {
      if(pm == null)
        {
            pm = this;
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {

        state = 0;
        TargetPattern.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        Gamestart();

    }

    public void AddScore(int addValue)
    {
        currScore += addValue;

    }

    void UpdateScore()
    {
        sCurrScore = currScore.ToString();
        sBestScore = bestScore.ToString();
        currScoreText.text = sCurrScore;

        if(currScore > bestScore)
        {
            bestScore = currScore;
            bestScoreText.text = sBestScore;

        }

    }

    public void Gamestart()
    {
        if(state == 0)
        {
            currTime += Time.deltaTime;

            if(currTime > 3)
            {
                state = 1;
                startCount.text =  "Start!";

                currTime = 0;
            }
        }
        else if(state == 1)
        {
            currTime += Time.deltaTime;

            if(currTime > 1)
            {
                state = 2;
                startCount.gameObject.SetActive(false);

            }
        }
        else  if(state == 2)
        {
           
            patternManager();

            currTime = 0;
        }
        
    }
    float PcurrTime;
    void patternManager()
    {
        
        
        TargetPattern.SetActive(true);

        if (Pstate == 0)
        {
            PcurrTime += Time.deltaTime;
            pattern[0].SetActive(true);

            if(PcurrTime > 8 || pattern[0].activeSelf == false)
            {
                Pstate = 1;
                pattern[0].SetActive(false);
                PcurrTime = 0;
            }

        }
        else if(Pstate == 1)
        {
            PcurrTime += Time.deltaTime;
            pattern[1].SetActive(true);
            if (PcurrTime > 7 || pattern[1].activeSelf == false)
            {
                Pstate = 2;
                pattern[1].SetActive(false);
                PcurrTime = 0;
            }
        }
        else if(Pstate == 2)
        {
            PcurrTime += Time.deltaTime;
            pattern[2].SetActive(true);

            if (PcurrTime > 13 || pattern[2].activeSelf == false)
            {
                Pstate = 3;
                pattern[2].SetActive(false);
                PcurrTime = 0;
            }

        }

        else if(Pstate == 3)
        {
            PcurrTime += Time.deltaTime;
            pattern[3].SetActive(true);
            if (PcurrTime > 11 || pattern[3].activeSelf == false)
            {
                Pstate = 4;
                pattern[3].SetActive(false);
                PcurrTime = 0;
            }
        }

        else if (Pstate == 4)
        {
            PcurrTime += Time.deltaTime;
            pattern[4].SetActive(true);
            if (PcurrTime > 10 || pattern[4].activeSelf == false)
            {
                pattern[4].SetActive(false);
                PcurrTime = 0;
            }
        }



    }
    

}
