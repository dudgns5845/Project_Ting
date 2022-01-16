using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThrowHockeyBall : MonoBehaviour
{
    public static ThrowHockeyBall instance;


    //�÷��̾� ��ġ
    public Transform myPlayer;
    //������
    public Transform trRight;
    public GameObject grabObject;

    public Transform stickPos;
    public Transform stick2Pos;



    private void Awake()
    {
        if (instance == null)
            instance = this;
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

        if (isHandDown && isTriggerDown) //����ư�� ������ �� �⵵�� �Ѵ�
        {
            
            if (false == tryGrab) //�������ٸ�
            {
                // ��� ����
                tryGrab = true;
                // trRight�� �߽����� �ݰ� 0.1M ���� Mallet���̾� �浹ü�� ��� �˻��ϰ�ʹ�.
                int layerMask = 1 << LayerMask.NameToLayer("Stick");
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
                if (grabObject != null) //�ȳ������ٸ�
                {
                    grabObject.transform.parent = null;

                    if (grabObject.name == "Stick")
                        grabObject.transform.position = stickPos.position; //���� ���� ��ƽ�� Stick1 �� �� ������ �� �� ��ġ��

                    if (grabObject.name == "Stick2")
                        grabObject.transform.position = stick2Pos.position; //���� ���� ��ƽ�� Stick2 �� �� ������ �� �� ��ġ��

                    grabObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    grabObject = null;
                }
            }
        }

    }
}
