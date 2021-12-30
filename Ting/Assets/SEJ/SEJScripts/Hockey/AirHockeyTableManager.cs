using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//에어하키의 포톤뷰 관리
//시작하기를 누르면 
//점수판이 생성된다
//공이 테이블 위에서 생성한다
//스틱(말렛)도 생성한다

public class AirHockeyTableManager : MonoBehaviourPun
{

    public static AirHockeyTableManager hockeyTableM;

    //public PhotonView hockeyPv;
    public GameObject hockeyBtnObj;
    public Button hockeyBtn;

    public GameObject score; 

    public GameObject ball;
    public GameObject stick;

    public Transform[] spawnPos; //stick 생성할 위치


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
        ball.SetActive(false);
        stick.SetActive(false);
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
        ball.SetActive(true);
        stick.SetActive(true);
    }



}
