using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class AirHockeyTableManager : MonoBehaviour
{

    public static AirHockeyTableManager hockeyTableM;
    
    //�����ϱ�, ������ ��ư ���� (1.11)

    //public GameObject hockeyBtnObj;
    //public Button hockeyBtn; 

    //public GameObject hockeyExitBtnObj;
    //public Button hockeyExitBtn; 

    
    public GameObject score; //������
    //public Button HockeyReset;

    public GameObject ballFactory;
    public GameObject ballObj;
    //public GameObject stickFactory;
    public GameObject stickObj;
    public GameObject stick2Obj;

    //������ �� ��ġ��
    public Transform ballStartPos;
    public Transform stickPos;
    public Transform stick2Pos;


    public TextMeshProUGUI txtLeftScore;
    public int leftScore;
    public TextMeshProUGUI txtRightScore;
    public int rightScore;

    public bool isLeftGoal; //���ʿ� �� �� 
    public bool isRightGoal; //�����ʿ� �� ��
    public Transform leftBallPos;  //�����ʿ� �� ���� �� ���� pos���� ������
    public Transform rightBallPos;  //���ʿ� �� ���� �� ������ pos���� ������



    //public Transform[] spawnStickPos; //stick ������ ��ġ
    ////public Transform[] spawnBallPos; //stick ������ ��ġ


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


    #region ��ư �Լ���
    //public void OnClickHockeyBtn()
    //{
    //    //�����ϱ� ��ư�� ������
    //    GameOnOff_SEJ.onoff.isHockey = true;
    //    //���۹�ư �������
    //    //hockeyBtnObj.SetActive(false);
    //    //������, ��, ��ƽ ����
    //    score.SetActive(true);
    //    ballObj.SetActive(true);
    //    stickObj.SetActive(true);
    //    stick2Obj.SetActive(true);

    //}
    //bool isOnClickExit; //������ ��ư Ŭ�� ����
    //public void OnClickExitHockeyBtn()
    //{
    //    //������ ��ư ������
    //    GameOnOff_SEJ.onoff.isHockey = false;
    //    //���ھ� ����, ������ ����� , �����ϱ� ��ư �ٽ� ����
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
   
    
    public void OnClickHockeyReset() //���¹�ư
    {
        rightScore = 0;
        leftScore = 0;
        txtRightScore.text = " " +rightScore;
        txtLeftScore.text = " " + leftScore;
        stickObj.transform.position = stickPos.position;
        stick2Obj.transform.position = stick2Pos.position;
        ballObj.transform.position = leftBallPos.position;
    }


    public void MakeRightBall() //������ ����
    {
        print("������ ������ ȣ��");
        rightScore += 1; 
        txtRightScore.text = " " +rightScore;
        print("�����÷��̾�  1�� Get");
        //GameObject effect = Instantiate(effectFactory);
        //effect.transform.position = leftGoal.position; //���ʰ�뿡 ���� ���ٴ� ���� �˷���
        //Destroy(effect.gameObject, 2);

        //��������ġ
        //ballObj = Instantiate(ballFactory);
        //ballObj.transform.position = leftBallPos.position;
        //ballObj.SetActive(true);
        StartCoroutine(BallInit(leftBallPos));
        //��� ���� �����Ǹ� �ȵǴϱ�
        //isRightGoal = false;
    }

    public GameObject effectFactory;
    public Transform rightGoal;
    public Transform leftGoal;


    public void MakeLeftBall() //���� ����
    {
        print("���� ������ ȣ��");
        leftScore += 1; 
        txtLeftScore.text = " " + leftScore;
        print("�������÷��̾�  1�� Get");
      
        //GameObject effect = Instantiate(effectFactory);
        //effect.transform.position = rightGoal.position; //������ ��뿡 ���� ���ٴ� ���� �˷���
        //Destroy(effect.gameObject, 2);

        //��������ġ
        //ballObj = Instantiate(ballFactory);
        //ballObj.transform.position = rightBallPos.position;
        //ballObj.SetActive(true);
        StartCoroutine(BallInit(rightBallPos));
        //��� ���� �����Ǹ� �ȵǴϱ�
        //isLeftGoal = false;
    }

    IEnumerator BallInit(Transform pos)
    {
        yield return new WaitForSeconds(1f);
        //��������ġ
        ballObj = Instantiate(ballFactory);
        ballObj.transform.position = pos.position;
        //ballObj.SetActive(true);
    }
    

}
