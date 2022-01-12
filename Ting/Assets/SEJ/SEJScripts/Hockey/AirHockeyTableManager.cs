using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class AirHockeyTableManager : MonoBehaviour
{

    public static AirHockeyTableManager hockeyTableM;
    
    //시작하기, 나가기 버튼 삭제 (1.11)

    //public GameObject hockeyBtnObj;
    //public Button hockeyBtn; 

    //public GameObject hockeyExitBtnObj;
    //public Button hockeyExitBtn; 

    
    public GameObject score; //점수판
    //public Button HockeyReset;

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
        score.SetActive(true);

        stickObj.SetActive(true);
        stick2Obj.SetActive(true);
        ballObj.SetActive(true);

        txtLeftScore.text = " " + leftScore;
        txtRightScore.text = " " + rightScore;
    }


    #region 버튼 함수들
    //public void OnClickHockeyBtn()
    //{
    //    //시작하기 버튼을 누르면
    //    GameOnOff_SEJ.onoff.isHockey = true;
    //    //시작버튼 사라지고
    //    //hockeyBtnObj.SetActive(false);
    //    //점수판, 공, 스틱 생성
    //    score.SetActive(true);
    //    ballObj.SetActive(true);
    //    stickObj.SetActive(true);
    //    stick2Obj.SetActive(true);

    //}
    //bool isOnClickExit; //나가기 버튼 클릭 여부
    //public void OnClickExitHockeyBtn()
    //{
    //    //나가기 버튼 누르면
    //    GameOnOff_SEJ.onoff.isHockey = false;
    //    //스코어 리셋, 점수판 사라짐 , 시작하기 버튼 다시 생성
    //    leftScore = 0;
    //    txtLeftScore.text = " " + leftScore;
    //    rightScore = 0;
    //    txtRightScore.text = " " + rightScore;
    //    score.SetActive(false);
    //    ballObj.SetActive(false);
    //    //hockeyBtnObj.SetActive(true);
    //    stickObj.SetActive(false);
    //    stick2Obj.SetActive(false);

    //    isOnClickExit = true;


    //}
    #endregion
   
    
    public void OnClickHockeyReset() //리셋버튼
    {
        rightScore = 0;
        leftScore = 0;
        txtRightScore.text = " " +rightScore;
        txtLeftScore.text = " " + leftScore;
        stickObj.transform.position = stickPos.position;
        stick2Obj.transform.position = stick2Pos.position;
        ballObj.transform.position = leftBallPos.position;
    }


    public void MakeRightBall() //오른쪽 득점
    {
        print("오른쪽 리스폰 호출");
        rightScore += 1; 
        txtRightScore.text = " " +rightScore;
        print("왼쪽플레이어  1점 Get");
        //GameObject effect = Instantiate(effectFactory);
        //effect.transform.position = leftGoal.position; //왼쪽골대에 공이 들어갔다는 것을 알려줌
        //Destroy(effect.gameObject, 2);

        //리스폰위치
        //ballObj = Instantiate(ballFactory);
        //ballObj.transform.position = leftBallPos.position;
        //ballObj.SetActive(true);
        StartCoroutine(BallInit(leftBallPos));
        //계속 공이 생성되면 안되니까
        //isRightGoal = false;
    }

    public GameObject effectFactory;
    public Transform rightGoal;
    public Transform leftGoal;


    public void MakeLeftBall() //왼쪽 득점
    {
        print("왼쪽 리스폰 호출");
        leftScore += 1; 
        txtLeftScore.text = " " + leftScore;
        print("오른쪽플레이어  1점 Get");
      
        //GameObject effect = Instantiate(effectFactory);
        //effect.transform.position = rightGoal.position; //오른쪽 골대에 공이 들어갔다는 것을 알려줌
        //Destroy(effect.gameObject, 2);

        //리스폰위치
        //ballObj = Instantiate(ballFactory);
        //ballObj.transform.position = rightBallPos.position;
        //ballObj.SetActive(true);
        StartCoroutine(BallInit(rightBallPos));
        //계속 공이 생성되면 안되니까
        //isLeftGoal = false;
    }

    IEnumerator BallInit(Transform pos)
    {
        yield return new WaitForSeconds(1f);
        //리스폰위치
        ballObj = Instantiate(ballFactory);
        ballObj.transform.position = pos.position;
        //ballObj.SetActive(true);
    }
    

}
