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

    public GameObject ball;
    public GameObject stick;

    public Transform[] spawnPos; //stick ������ ��ġ


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
        ball.SetActive(false);
        stick.SetActive(false);
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
        ball.SetActive(true);
        stick.SetActive(true);
    }



}
