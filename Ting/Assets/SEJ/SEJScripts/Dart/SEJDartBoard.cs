using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//type 1: 칸 점수
//     2: 더블
//     3: 트리플
public class SEJDartBoard : MonoBehaviour
{
    public static SEJDartBoard db;

    SEJBoardPiece boardPiece;
    public TextMeshProUGUI scoreText;
    int score; //현 점수
    public int SCORE
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = score + "";
        }
    }
   
    private void Awake()
    {
        if(db==null)
        {
            db = this;
        }
    }
    void Start()
    {
        SCORE = 0; //현 점수 초기화
     
    }

    SEJDarts currentDart;
    
    internal void AddScore(SEJDarts dart, int type, int scoreNum)
    {
        //string key = type + "," + scoreNum;
        //print(key + "," + "점수 : " + score[key]);
        if (currentDart == dart)
            return;
        currentDart = dart;
        // 점수계산
        SCORE += type * scoreNum;
        print(SCORE); 
        print("맞은 점수 : " + type * scoreNum);
    }

    public GameObject DartObjectsFac;
    public Transform dartRespawnPos;
    public GameObject dartObjects;
    public void OnClickResetDart()
    {
        SCORE = 0; //현 점수 초기화

        DartObjs dartObjs = dartObjects.GetComponent<DartObjs>();
        dartObjs.ResetDart();
        
        dartObjects = Instantiate(DartObjectsFac);
        dartObjects.transform.position = dartRespawnPos.position;
    }

}
