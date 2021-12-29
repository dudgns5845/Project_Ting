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

    public GameObject cameraRig;

    void Start()
    {
   
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
                int layerMask = 1 << LayerMask.NameToLayer("Stick");
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
                    grabObject.transform.position = new Vector3(-1, 0.82f, -0.2f); //내가 잡은 스틱이 Stick 일 때 놓았다면 이 위치로

                    //grabObject.transform.position = new Vector3(1, 0.82f, 0.2f); //내가 잡은 스틱이 Stick2 일 때 놓았다면 이 위치로

                    grabObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    grabObject = null;
                }
            }
        }

    }
}
