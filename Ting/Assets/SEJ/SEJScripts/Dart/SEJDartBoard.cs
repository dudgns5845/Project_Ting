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
    int score; //�� ����
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
    //type 1: ĭ ����
    //     2: ����
    //     3: Ʈ����
    private void Awake()
    {
        if(db==null)
        {
            db = this;
        }
    }
    void Start()
    {
        SCORE = 0; //�� ���� �ʱ�ȭ
        dartStartBtnObj.SetActive(true);
        dartExitBtnObj.SetActive(true);
    }

    SEJDarts currentDart;
    
    internal void AddScore(SEJDarts dart, int type, int scoreNum)
    {
        //string key = type + "," + scoreNum;
        //print(key + "," + "���� : " + score[key]);
        if (currentDart == dart)
            return;
        currentDart = dart;
        // �������
        SCORE += type * scoreNum;
        print(SCORE); 
        print("���� ���� : " + type * scoreNum);
    }

   public  void OnStartDart() //��Ʈ���� �����ϱ� ��ư ������
    {
        dartStartBtnObj.SetActive(false); 
 
        GameOnOff_SEJ.onoff.PlayDart();
    }
   public void OnExitDart() //��Ʈ���� ������ ��ư ������
    {
        dartStartBtnObj.SetActive(true);
        //GameOnOff_SEJ.onoff.PlayDart();
        //�ι� ������ 3��Ī ī�޶�� ��ȯ



    }




}
