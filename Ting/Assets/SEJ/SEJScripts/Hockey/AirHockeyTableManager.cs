using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//������Ű�� ����� ����
//�����ϱ⸦ ������ 
//�������� �����ȴ�
//���� ���̺� ������ �����Ѵ�
//��ƽ(����)�� �����Ѵ�

public class AirHockeyTableManager : MonoBehaviourPun
{

    public static AirHockeyTableManager hockeyTableM;

    //public PhotonView hockeyPv;
    public GameObject hockeyBtnObj;
    public Button hockeyBtn;

    public GameObject score; 
     
    public GameObject ballFactory;
    public Transform ballStartPos;
    public Transform ballPos1;
    public Transform ballPos2;

    public GameObject stickFactory;

    public Transform[] spawnStickPos; //stick ������ ��ġ
    //public Transform[] spawnBallPos; //stick ������ ��ġ


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
        GameObject ball = Instantiate(ballFactory);
        ball.transform.position = ballStartPos.position;
        GameObject stick = Instantiate(stickFactory);
    }



}
