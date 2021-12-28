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
        print("나의 득점");
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
    //포톤뷰로 Ball생성되도록
    void MakeYourBall()
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = yours.position;
        ballObj.SetActive(true);
        //계속 공이 생성되면 안되니까
        isGoal = false;
    }
}
