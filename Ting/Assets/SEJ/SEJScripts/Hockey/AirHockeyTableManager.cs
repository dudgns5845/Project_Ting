using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirHockeyTableManager : MonoBehaviour
{

    public static AirHockeyTableManager hockeyTableM;
    

    
    public GameObject score; //������
    //public Button HockeyReset;

    public GameObject ballFactory;
    public GameObject ballObj;

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


    public void OnClickHockeyReset() //���¹�ư
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


    public void MakeRightBall() //������ ����
    {
        print("������ ������ ȣ��");
        rightScore += 1; 
        txtRightScore.text = " " +rightScore;
        print("�����÷��̾�  1�� Get");
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = leftGoal.position; //���ʰ�뿡 ���� ���ٴ� ���� �˷���
        Destroy(effect.gameObject, 2);

     
        StartCoroutine(BallInit(leftBallPos));
    
    }


    public void MakeLeftBall() //���� ����
    {
        print("���� ������ ȣ��");
        leftScore += 1; 
        txtLeftScore.text = " " + leftScore;
        print("�������÷��̾�  1�� Get");

        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = rightGoal.position; //������ ��뿡 ���� ���ٴ� ���� �˷���
        Destroy(effect.gameObject, 2);


        StartCoroutine(BallInit(rightBallPos));
   
    }

    IEnumerator BallInit(Transform pos)
    {
        yield return new WaitForSeconds(1f);
        //��������ġ
        ballObj = Instantiate(ballFactory);
        ballObj.transform.position = pos.position;
    }
    

}
