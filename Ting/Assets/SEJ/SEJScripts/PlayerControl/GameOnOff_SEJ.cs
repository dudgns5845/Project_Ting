using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ó���� ���� ��ũ��Ʈ �� ���ְ� �̵��ϴ� ��ũ��Ʈ�� �����
//�������ٰ� ���ӱ⿡ ��������� UI�� �߸鼭 ī�޶� (1��Ī����) ��ȯ��Ű��
//�������� ���� UI�ߵ���
//�����Ѵٸ� �� ���ӿ� �´� ��ũ��Ʈ�� ���ְ� �ٸ� ���� ��ũ��Ʈ�� ���ش�

public class GameOnOff_SEJ : MonoBehaviour
{
    public static GameOnOff_SEJ onoff;


    private void Awake()
    {
        if (onoff == null)
            onoff = this;
    }
    void Start()
    {
       //ó���� ���ӿ� ���õ� ��ũ��Ʈ�� �� ���ش�
        GetComponent<ThrowHockeyBall>().enabled = false;
        GetComponent<ThrowDart>().enabled = false;
        GetComponent<GunControl>().enabled = false;
    }

    void Update()
    {
    }

    public bool isHockey;
    public bool isDart;
    public bool isGun;
    public void PlayHockey()
    {
        //GetComponent<ThrowHockeyBall>().enabled = true;
        if (isHockey)
        {
            GetComponent<ThrowHockeyBall>().enabled = true;
        }
        if (isHockey == false)
        {
            GetComponent<ThrowHockeyBall>().enabled = false;
        }

    }
    public void PlayDart()
    {
        GetComponent<ThrowDart>().enabled = true;


    }
    public void PlayGun()
    {
        GetComponent<GunControl>().enabled = true;
    }



}