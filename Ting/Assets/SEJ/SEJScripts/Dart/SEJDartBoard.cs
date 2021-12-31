using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SEJDartBoard : MonoBehaviour
{
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

    SEJBoardPiece boardPiece;
    //type 1: 칸 점수
    //     2: 더블
    //     3: 트리플


    void Start()
    {
        //score = new Dictionary<string, int>();
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

    

}
