using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//������Ű�� ����� ����
//�����ϱ⸦ ������ 
//�������� �����ȴ�
//���� ���̺� ������ �����Ѵ�
//��ƽ(����)�� �����Ѵ�

public class AirHockeyTableManager : MonoBehaviour
{

    public static AirHockeyTableManager hockeyTableM;

    public GameObject hockeyBtnObj;
    public Button hockeyBtn; 

    public GameObject hockeyExitBtnObj;
    public Button hockeyExitBtn; 

    public GameObject score; //������


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
        //ó���� ���̺� ���� �ƹ��͵� ���� �����ϱ� ��ư�� ����
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
        //�����ϱ� ��ư�� ������
     
        //���۹�ư �������
        hockeyBtnObj.SetActive(false);
        //������, ��, ��ƽ ����
        score.SetActive(true);
        ballObj.SetActive(true);
        stickObj.SetActive(true);
        stick2Obj.SetActive(true);

    }
    bool isOnClickExit; //������ ��ư Ŭ�� ����
    public void OnClickExitHockeyBtn()
    {
        //������ ��ư ������
        //���ھ� ����, ������ ����� , �����ϱ� ��ư �ٽ� ����
        leftScore = 0; 
        rightScore = 0;
        score.SetActive(false);
        hockeyBtnObj.SetActive(true);
        stickObj.SetActive(false);
        stick2Obj.SetActive(false);
        ballObj.SetActive(false);
        
        isOnClickExit = true;
        
        // �̹� ������ ����Ǿ��ٸ�
        if(isOnClickExit)
        {
            //ī�޶� 3��Ī���� ��ȯ
            
        }

    }

  
    public void MakeRightBall() //������ ����
    {
        print("������ ������ ȣ��");
        rightScore += 1; 
        txtRightScore.text = " " +rightScore;
        print("�����÷��̾�  1�� Get");
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = leftGoal.position; //���ʰ�뿡 ���� ���ٴ� ���� �˷���
        Destroy(effect.gameObject, 2);

        //��������ġ
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = leftBallPos.position;
        ballObj.SetActive(true);

        //��� ���� �����Ǹ� �ȵǴϱ�
        isRightGoal = false;
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
      
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = rightGoal.position; //������ ��뿡 ���� ���ٴ� ���� �˷���
        Destroy(effect.gameObject, 2);

        //��������ġ
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = rightBallPos.position;
        ballObj.SetActive(true);
        //��� ���� �����Ǹ� �ȵǴϱ�
        isLeftGoal = false;
    }

}
