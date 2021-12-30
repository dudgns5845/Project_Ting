using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

//���� ������ �� ������ ���� ��Ÿ����

public class HockeyFail : MonoBehaviourPun
{
    public GameObject ballFactory;
    bool isFail;
    public Transform mine; //�� ������ ��ġ�� ���� ����

    public TextMeshProUGUI txtYourScore;
    public int yourScore;

    private void Start()
    {
        txtYourScore.text = " " + yourScore;
    }
    void Update()
    {
        if (isFail == true)
        {
            MakeMyBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            yourScore += 1;
            txtYourScore.text = "" + yourScore;
            print("����� ����");
            other.gameObject.SetActive(false);
            isFail = true;
        }
    }
    void MakeMyBall()
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = mine.position;
        ballObj.SetActive(true);

        //��� ���� �����Ǹ� �ȵǴϱ�
        isFail = false;
    }
}