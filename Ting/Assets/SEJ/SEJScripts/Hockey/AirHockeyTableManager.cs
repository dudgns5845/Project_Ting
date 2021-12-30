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
    }

    void Update()
    {
        
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

    public void OnClickExitHockeyBtn()
    {
        //������ ��ư ������
        //���ھ� ����, ������ ����� , �����ϱ� ��ư �ٽ� ����
        HockeyBall.instance.txtLeftScore.text = "" + 0;
        HockeyBall.instance.txtRightScore.text = "" + 0;
        score.SetActive(false);
        hockeyBtnObj.SetActive(true);
        stickObj.SetActive(false);
        stick2Obj.SetActive(false);
        ballObj.SetActive(false);


    }


}
