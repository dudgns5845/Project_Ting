using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//type 1: ĭ ����
//     2: ����
//     3: Ʈ����
public class SEJDartBoard : MonoBehaviour
{
    public static SEJDartBoard db;

    SEJBoardPiece boardPiece;
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

    public GameObject DartObjectsFac;
    public Transform dartRespawnPos;
    public GameObject dartObjects;
    public void OnClickResetDart()
    {
        SCORE = 0; //�� ���� �ʱ�ȭ

        DartObjs dartObjs = dartObjects.GetComponent<DartObjs>();
        dartObjs.ResetDart();
        
        dartObjects = Instantiate(DartObjectsFac);
        dartObjects.transform.position = dartRespawnPos.position;
    }

}
