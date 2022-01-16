using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

//�÷��̾� �г���
//������Ű ���� ���
//VR�Ұ��÷� ���� ���

//��,�� ĳ���� ������Ʈ on/off������
//ī�޶� ������ -> ī�޶��� �θ� ~�� ������Ʈ�� �Ѱ���� 
//�޼�,������ -> �θ� ~�� ������Ʈ�� �Ѱ����
//���� �Ӹ��� ī�޶�Center�� ���������
public class PlayerMove_SEJ : MonoBehaviourPunCallbacks
{

    public static PlayerMove_SEJ pm;

    public Transform trLeft; //�޼� Transform
    public Transform trRight; //������ Transform

    public GameObject grabObject; //������ü
    public GameObject mallet;  //��ƽ
    public GameObject camRig;

    //public TextMeshProUGUI nickName; //�г���UI

    Vector3 playerPos; //�÷��̾� ��ġ
    Vector3 trRightPos; //�÷��̾� ������ ��ġ
    Quaternion receiveRot; //�÷��̾� ȸ��


    private void Awake()
    {
        if (pm == null)
            pm = this;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //������ �����ϴ� ��Ȳ
        {
            stream.SendNext(transform.position);
            stream.SendNext(trRight.position);
            stream.SendNext(transform.rotation);
        }
        if (stream.IsReading) //���� �� �ִ� ���¶��
        {
            playerPos = (Vector3)stream.ReceiveNext();
            trRightPos = (Vector3)stream.ReceiveNext();
            receiveRot = (Quaternion)stream.ReceiveNext();
        }
    }
    void Start()
    {
        //���� ������ player�� �ƴ϶��
        if (photonView.IsMine == false)
        {
            //ī�޶� ��Ȱ��ȭ
            camRig.SetActive(false);
        }

         camRig.SetActive(photonView.IsMine); // �� ī�޶� Ų�� 

    }
    void Update()
    {
        
    }
}
