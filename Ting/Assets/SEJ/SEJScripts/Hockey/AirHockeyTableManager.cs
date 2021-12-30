using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//에어하키의 포톤뷰 관리
//시작하기를 누르면 
//점수판이 생성된다
//공이 테이블 위에서 생성한다
//스틱(말렛)도 생성한다

public class AirHockeyTableManager : MonoBehaviour
{

    public static AirHockeyTableManager hockeyTableM;

    public GameObject hockeyBtnObj;
    public Button hockeyBtn; 

    public GameObject hockeyExitBtnObj;
    public Button hockeyExitBtn; 

    public GameObject score; //점수판


    public GameObject ballFactory;
    public GameObject ballObj;
    //public GameObject stickFactory;
    public GameObject stickObj;
    public GameObject stick2Obj;

    //리스폰 될 위치들
    public Transform ballStartPos;
    public Transform stickPos;
    public Transform stick2Pos;


    //public Transform[] spawnStickPos; //stick 생성할 위치
    ////public Transform[] spawnBallPos; //stick 생성할 위치


    private void Awake()
    {
        if(hockeyTableM==null)
        {
            hockeyTableM = this;
        }
    }
    void Start()
    {
        //처음에 테이블 위에 아무것도 없이 시작하기 버튼만 있음
        hockeyBtnObj.SetActive(true);
        score.SetActive(false);

        stickObj.SetActive(false);
        stick2Obj.SetActive(false);
        ballObj.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OnClickHockeyBtn()
    {
        //시작하기 버튼을 누르면
        //시작버튼 사라지고
        hockeyBtnObj.SetActive(false);
        //점수판, 공, 스틱 생성
        score.SetActive(true);
        ballObj.SetActive(true);
        stickObj.SetActive(true);
        stick2Obj.SetActive(true);

    }

    public void OnClickExitHockeyBtn()
    {
        //나가기 버튼 누르면
        //스코어 리셋, 점수판 사라짐 , 시작하기 버튼 다시 생성
        HockeyBall.instance.txtLeftScore.text = "" + 0;
        HockeyBall.instance.txtRightScore.text = "" + 0;
        score.SetActive(false);
        hockeyBtnObj.SetActive(true);
        stickObj.SetActive(false);
        stick2Obj.SetActive(false);
        ballObj.SetActive(false);


    }


}
