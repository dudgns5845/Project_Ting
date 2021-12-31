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


    public TextMeshProUGUI txtLeftScore;
    public int leftScore;
    public TextMeshProUGUI txtRightScore;
    public int rightScore;

    public bool isLeftGoal; //왼쪽에 골 들어감 
    public bool isRightGoal; //오른쪽에 골 들어감
    public Transform leftBallPos;  //오른쪽에 골 들어갔을 때 왼쪽 pos에서 리스폰
    public Transform rightBallPos;  //왼쪽에 골 들어갔을 때 오른쪽 pos에서 리스폰



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

        txtLeftScore.text = " " + leftScore;
        txtRightScore.text = " " + rightScore;
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
        leftScore = 0; 
        rightScore = 0;
        score.SetActive(false);
        hockeyBtnObj.SetActive(true);
        stickObj.SetActive(false);
        stick2Obj.SetActive(false);
        ballObj.SetActive(false);


    }

  
    public void MakeRightBall() //오른쪽 리스폰 
    {
        print("오른쪽 리스폰 호출");
        //isRightGoal = true;
        leftScore += 1;
        txtLeftScore.text = " " +leftScore;
        print("왼쪽플레이어  1점 Get");
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = leftGoal.position;
        Destroy(effect.gameObject, 2);

        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = rightBallPos.position;
        ballObj.SetActive(true);
        leftScore = 0;

        //계속 공이 생성되면 안되니까
        isRightGoal = false;
    }
    public GameObject effectFactory;
    public Transform rightGoal;
    public Transform leftGoal;


    public void MakeLeftBall() //왼쪽 리스폰
    {
        print("왼쪽 리스폰 호출");
        rightScore += 1;
        txtRightScore.text = " " + rightScore;
        print("오른쪽플레이어  1점 Get");
      
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = rightGoal.position;
        Destroy(effect.gameObject, 2);

        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = leftBallPos.position;
        ballObj.SetActive(true);
        rightScore = 0;
        //계속 공이 생성되면 안되니까
        isLeftGoal = false;
    }

}
