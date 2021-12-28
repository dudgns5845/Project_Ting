using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;


public class HockeyGoal : MonoBehaviourPun
{
    public GameObject ballFactory;
    bool isGoal;
    public Transform yours;

    public TextMeshProUGUI txtMyScore;
    public int myScore;

    private void Start()
    {
        txtMyScore.text = myScore + "";
    }

    void Update()
    {
        if (isGoal == true)
        {
            MakeYourBall();
        }
    }

    //[PunRPC]
    public void GetMyScore()
    {
        print("���� ����");
        myScore += 1;
        txtMyScore.text = myScore + "";
    }
    private void OnTriggerEnter(Collider other)
    {
        //    if(photonView.IsMine && other.gameObject.CompareTag("Ball"))
        if (other.gameObject.CompareTag("Ball"))
        {
            //    PhotonView pv = other.GetComponent<PhotonView>();
            //    pv.RPC("GetMyScore", RpcTarget.AllBuffered);
            //myScore += 1;
            //txtMyScore.text = myScore + "";

            other.gameObject.SetActive(false);
            isGoal = true;
        }
    }
    //������ Ball�����ǵ���
    void MakeYourBall()
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = yours.position;
        ballObj.SetActive(true);
        //��� ���� �����Ǹ� �ȵǴϱ�
        isGoal = false;
    }
}
