using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThrowHockeyBall : MonoBehaviour
{
    //�÷��̾� ��ġ
    public Transform myPlayer;
    //������
    public Transform trRight;
    public GameObject grabObject;

    public GameObject mallet; //��ƽ

    public GameObject cameraRig;

    Vector3 playerPos;
    Vector3 trRightPos;
    Quaternion receiveRot;


    //IK �̿��� �츮�� ���� ĳ������ ���� ��ġ�� �������ѵּ� Mallet�� ���̺� ������ �������� �ʰԲ� ���̰� �Ѵ�

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if(stream.IsWriting) //������ �����ϴ� ��Ȳ
    //    {
    //        stream.SendNext(transform.position);
    //        stream.SendNext(trRight.position);
    //        stream.SendNext(transform.rotation);
    //    }
    //    if(stream.IsReading) //���� �� �ִ� ���¶��
    //    {
    //        playerPos = (Vector3)stream.ReceiveNext();
    //        trRightPos = (Vector3)stream.ReceiveNext(); 
    //        receiveRot = (Quaternion)stream.ReceiveNext();

    //    }
    //}
    void Start()
    {
        //cameraRig.SetActive(photonView.IsMine);
        //Instantiate(mallet); // mallet����&��ġ�� ���̺� ������ �� ���� �������� ���̺� ��������
        //mallet.transform.position = new Vector3(0.47f, 1.23f, -1.153f);
    }

    //Input�� &&�����ڷ� ���� �����ϸ� ���ÿ� �� �ȸ����� ��찡 �����ϱ� �ΰ��� ��츦 bool������ ���� ����� Ȯ������
    bool isTriggerDown;
    bool isHandDown;
    private bool tryGrab;
    public float grabRadius = 0.5f;

    void Update()
    {
        //if (photonView.IsMine == false) return;
        //�޼յ� �־��ָ� 4���� �� ����ϱ� �ƿ� ������, �޼� ��Ʈ�ѷ���ũ��Ʈ�� ���� ���� �־��ִ°� �����

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

        if (isHandDown && isTriggerDown) //����ư�� ������ ��
        {
            
            if (false == tryGrab) //�������ٸ�
            {
                // ��� ����
                tryGrab = true;
                // trRight�� �߽����� �ݰ� 0.1M ���� Mallet���̾� �浹ü�� ��� �˻��ϰ�ʹ�.
                int layerMask = 1 << LayerMask.NameToLayer("Mallet");
                Collider[] cols = Physics.OverlapSphere(trRight.position, grabRadius, layerMask);
                if (cols.Length > 0)
                {
                    grabObject = cols[0].gameObject;
                    // ���� �θ� = ��
                    grabObject.transform.parent = trRight;
                    grabObject.transform.position = trRight.position;
                }
            }
        }
        else
        {
            // ����
            if (true == tryGrab)
            {   //���¼���
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
