using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

//플레이어 닉네임
//에어하키 포톤 사용
//VR소개팅룸 포톤 사용

//남,여 캐릭터 오브젝트 on/off나누기
//카메라도 나누기 -> 카메라이 부모가 ~인 오브젝트를 켜고끄기 
//왼손,오른손 -> 부모가 ~인 오브젝트를 켜고끄기
//모델의 머리가 카메라Center를 따라오도록
public class PlayerMove_SEJ : MonoBehaviourPunCallbacks
{

    public static PlayerMove_SEJ pm;

    public Transform trLeft; //왼손 Transform
    public Transform trRight; //오른손 Transform

    public GameObject grabObject; //잡은물체
    public GameObject mallet;  //스틱
    public GameObject camRig;

    //public TextMeshProUGUI nickName; //닉네임UI

    Vector3 playerPos; //플레이어 위치
    Vector3 trRightPos; //플레이어 오른손 위치
    Quaternion receiveRot; //플레이어 회전


    private void Awake()
    {
        if (pm == null)
            pm = this;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) //데이터 전송하는 상황
        {
            stream.SendNext(transform.position);
            stream.SendNext(trRight.position);
            stream.SendNext(transform.rotation);
        }
        if (stream.IsReading) //읽을 수 있는 상태라면
        {
            playerPos = (Vector3)stream.ReceiveNext();
            trRightPos = (Vector3)stream.ReceiveNext();
            receiveRot = (Quaternion)stream.ReceiveNext();
        }
    }
    void Start()
    {
        //내가 생성한 player가 아니라면
        if (photonView.IsMine == false)
        {
            //카메라 비활성화
            camRig.SetActive(false);
        }

         camRig.SetActive(photonView.IsMine); // 내 카메라만 킨다 

    }
    void Update()
    {
        
    }
}
