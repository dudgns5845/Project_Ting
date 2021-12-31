using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SEJDartBoard : MonoBehaviour
{
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


    void Start()
    {
        //score = new Dictionary<string, int>();
        SCORE = 0; //�� ���� �ʱ�ȭ
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

    

}
