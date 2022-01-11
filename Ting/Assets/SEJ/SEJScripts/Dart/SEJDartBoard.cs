using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SEJDartBoard : MonoBehaviour
{
    public static SEJDartBoard db;

    public GameObject dartStartBtnObj;
    public GameObject dartExitBtnObj;


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
    private void Awake()
    {
        if(db==null)
        {
            db = this;
        }
    }
    void Start()
    {
        dartStartBtnObj.transform.localPosition = new Vector3(-1.54f, -5.57f, -23.89f);
        dartExitBtnObj.transform.localPosition = new Vector3(-0.03999996f, -5.570004f, -23.89f);
        SCORE = 0; //현 점수 초기화
        dartStartBtnObj.SetActive(true);
        dartExitBtnObj.SetActive(true);
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

   public  void OnStartDart() //다트에서 시작하기 버튼 누르면
    {
        GameOnOff_SEJ.onoff.isDart = true;
        dartStartBtnObj.SetActive(false);
        dartExitBtnObj.transform.localPosition = new Vector3(3.75f, -8.08f, -23.89f);
        GameOnOff_SEJ.onoff.PlayDart();
    }
   public void OnExitDart() //다트에서 나가기 버튼 누르면
    {
        GameOnOff_SEJ.onoff.isDart = false;
        GameOnOff_SEJ.onoff.Start();
        dartStartBtnObj.SetActive(true);
        dartExitBtnObj.transform.localPosition = new Vector3(-0.03999996f, -5.570004f, -23.89f);
        SCORE = 0;

        //GameOnOff_SEJ.onoff.PlayDart();

    }

}
