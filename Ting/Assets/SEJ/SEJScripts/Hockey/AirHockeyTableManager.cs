using System.Collections;
using System.Collections.Generic;
//using Photon.Pun;
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
    //public PhotonView hockeyPv;
    public GameObject hockeyBtnObj;
    public Button hockeyBtn;
    public GameObject score; 
    public GameObject ball;
    public GameObject stick;
    public GameObject stick2;


    void Start()
    {
        //ó���� ���̺� ���� �ƹ��͵� ���� �����ϱ� ��ư�� ����
        hockeyBtnObj.SetActive(true);
        score.SetActive(false);
        ball.SetActive(false);
        stick.SetActive(false);
        stick2.SetActive(false);
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
        stick2.SetActive(true);
    }



}
