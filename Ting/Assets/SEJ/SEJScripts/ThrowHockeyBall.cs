using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThrowHockeyBall : MonoBehaviour
{
    //플레이어 위치
    public Transform myPlayer;
    //오른손
    public Transform trRight;
    public GameObject grabObject;

    public GameObject mallet; //스틱

    public GameObject cameraRig;

    Vector3 playerPos;
    Vector3 trRightPos;
    Quaternion receiveRot;


    //IK 이용해 우리가 보는 캐릭터의 손의 위치를 고정시켜둬서 Mallet이 테이블 밑으로 떨어지지 않게끔 보이게 한다

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if(stream.IsWriting) //데이터 전송하는 상황
    //    {
    //        stream.SendNext(transform.position);
    //        stream.SendNext(trRight.position);
    //        stream.SendNext(transform.rotation);
    //    }
    //    if(stream.IsReading) //읽을 수 있는 상태라면
    //    {
    //        playerPos = (Vector3)stream.ReceiveNext();
    //        trRightPos = (Vector3)stream.ReceiveNext(); 
    //        receiveRot = (Quaternion)stream.ReceiveNext();

    //    }
    //}
    void Start()
    {
        //cameraRig.SetActive(photonView.IsMine);
        //Instantiate(mallet); // mallet생성&위치는 테이블 생성될 때 같이 나오도록 테이블에 삽입하자
        //mallet.transform.position = new Vector3(0.47f, 1.23f, -1.153f);
    }

    //Input에 &&연산자로 같이 연결하면 동시에 잘 안먹히는 경우가 많으니까 두가지 경우를 bool변수로 따로 써줘야 확실해짐
    bool isTriggerDown;
    bool isHandDown;
    private bool tryGrab;
    public float grabRadius = 0.5f;

    void Update()
    {
        //if (photonView.IsMine == false) return;
        //왼손도 넣어주면 4개가 더 생기니까 아예 오른손, 왼손 컨트롤러스크립트를 따로 만들어서 넣어주는게 깔끔함

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isTriggerDown = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            isTriggerDown = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            isHandDown = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            isHandDown = false;
        }

        if (isHandDown && isTriggerDown) //잡기버튼을 눌렀을 때
        {
            
            if (false == tryGrab) //안잡혔다면
            {
                // 잡는 순간
                tryGrab = true;
                // trRight를 중심으로 반경 0.1M 안의 Mallet레이어 충돌체를 모두 검사하고싶다.
                int layerMask = 1 << LayerMask.NameToLayer("Mallet");
                Collider[] cols = Physics.OverlapSphere(trRight.position, grabRadius, layerMask);
                if (cols.Length > 0)
                {
                    grabObject = cols[0].gameObject;
                    // 나의 부모 = 너
                    grabObject.transform.parent = trRight;
                    grabObject.transform.position = trRight.position;
                }
            }
        }
        else
        {
            // 놓음
            if (true == tryGrab)
            {   //놓는순간
                tryGrab = false;
                if (grabObject != null)
                {
                    grabObject.transform.parent = null;
                    grabObject.transform.position = new Vector3(0.2f, 1.87f, -1.35f);
                    grabObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    grabObject = null;
                }
            }
        }

    }
}
