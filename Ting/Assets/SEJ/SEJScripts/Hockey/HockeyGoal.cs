//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Photon.Pun;
//using TMPro;

////���������� ���� �������� ����ȹ�� ��ġ�� �������ش�

//public class HockeyGoal : MonoBehaviourPun
//{
//    public GameObject ballFactory;

//    bool isGoal;

//    public Transform pos1; //�� ������ ��ġ1
//    public Transform pos2; //�� ������ ��ġ2

//    public TextMeshProUGUI txtLeftScore; //���� ������
//    public TextMeshProUGUI txtRightScore; //������ ������

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
//        print("���� ����");
//        myScore += 1;
//        txtLeftScore.text = myScore + "";
//    }

//    public void GetRightScore()
//    {
//        print("������ ����");
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
//    //������ Ball�����ǵ���
//    [PunRPC]
//    void MakeYourBall(Vector3 position)
//    {
//        GameObject ballObj = Instantiate(ballFactory);
//        ballObj.transform.position = yours.position;
//        ballObj.SetActive(true);
//        //��� ���� �����Ǹ� �ȵǴϱ�
//        isGoal = false;
//    }
//}
