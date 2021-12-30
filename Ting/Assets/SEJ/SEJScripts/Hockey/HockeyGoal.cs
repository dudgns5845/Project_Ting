//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Photon.Pun;
//using TMPro;

////골인지점에 따라 점수판의 점수획득 위치를 지정해준다

//public class HockeyGoal : MonoBehaviourPun
//{
//    public GameObject ballFactory;

//    bool isGoal;

//    public Transform pos1; //공 나오는 위치1
//    public Transform pos2; //공 나오는 위치2

//    public TextMeshProUGUI txtLeftScore; //왼쪽 점수판
//    public TextMeshProUGUI txtRightScore; //오른쪽 점수판

//    public int leftScore;
//    public int rightScore;

//    private void Start()
//    {
//        txtLeftScore.text = leftScore + "";
//        txtRightScore.text = rightScore + "";
//    }

//    void Update()
//    {

//    }

//    //[PunRPC] 
//    public void GetLeftScore()
//    {
//        print("왼쪽 득점");
//        myScore += 1;
//        txtLeftScore.text = myScore + "";
//    }

//    public void GetRightScore()
//    {
//        print("오른쪽 득점");
//        myScore += 1;
//        txtRightScore.text = myScore + "";
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Ball"))
//        {
//            //    PhotonView pv = other.GetComponent<PhotonView>();
//            //    pv.RPC("GetMyScore", RpcTarget.AllBuffered);
//            //myScore += 1;
//            //txtMyScore.text = myScore + "";

//            other.gameObject.SetActive(false);
//            isGoal = true;
//        }
//    }
//    //포톤뷰로 Ball생성되도록
//    [PunRPC]
//    void MakeYourBall(Vector3 position)
//    {
//        GameObject ballObj = Instantiate(ballFactory);
//        ballObj.transform.position = yours.position;
//        ballObj.SetActive(true);
//        //계속 공이 생성되면 안되니까
//        isGoal = false;
//    }
//}
