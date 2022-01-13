using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirHockeyTableManager : MonoBehaviour
{

    public static AirHockeyTableManager hockeyTableM;
    

    
    public GameObject score; //점수판
    //public Button HockeyReset;

    public GameObject ballFactory;
    public GameObject ballObj;

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


    public void OnClickHockeyReset() //리셋버튼
    {
        rightScore = 0;
        leftScore = 0;
        txtRightScore.text = " " +rightScore;
        txtLeftScore.text = " " + leftScore;
        stickObj.transform.position = stickPos.position;
        stickObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        stick2Obj.transform.position = stick2Pos.position;
        stick2Obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        ballObj.transform.position = leftBallPos.position;
    }

    public GameObject effectFactory;
    public Transform rightGoal;
    public Transform leftGoal;


    public void MakeRightBall() //오른쪽 득점
    {
        print("오른쪽 리스폰 호출");
        rightScore += 1; 
        txtRightScore.text = " " +rightScore;
        print("왼쪽플레이어  1점 Get");
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = leftGoal.position; //왼쪽골대에 공이 들어갔다는 것을 알려줌
        Destroy(effect.gameObject, 2);

     
        StartCoroutine(BallInit(leftBallPos));
    
    }


    public void MakeLeftBall() //왼쪽 득점
    {
        print("왼쪽 리스폰 호출");
        leftScore += 1; 
        txtLeftScore.text = " " + leftScore;
        print("오른쪽플레이어  1점 Get");

        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = rightGoal.position; //오른쪽 골대에 공이 들어갔다는 것을 알려줌
        Destroy(effect.gameObject, 2);


        StartCoroutine(BallInit(rightBallPos));
   
    }

    IEnumerator BallInit(Transform pos)
    {
        yield return new WaitForSeconds(1f);
        //리스폰위치
        ballObj = Instantiate(ballFactory);
        ballObj.transform.position = pos.position;
    }
    

}
