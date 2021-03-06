using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;
using AdvancedPeopleSystem;
using Firebase.Auth;

//광장에 접속하면 생성되는 플레이어 셋팅 스크립트
public class Player_Pun_Setting_Rio : MonoBehaviourPunCallbacks
{
    PhotonView pv;
    PhotonVoiceView pv_voice;
    FirebaseAuth auth;
    public GameObject Cam;
    public GameObject Man;
    public GameObject Woman;
    public string userid;

    public GameObject RPCIK;

    public Database_Rio db;

    public Transform vrLeft;
    public Transform vrRight;
    public Transform vrlook;

    public Transform ikLeft;
    public Transform ikRight;
    public Transform iklook;


    private void Awake()
    {
        db = GetComponent<Database_Rio>();
        pv = GetComponent<PhotonView>();
        auth = FirebaseAuth.DefaultInstance;
    }

    private void Start()
    {
        if (pv.IsMine)
        {
            //플레이어 카메라 활성화
            Cam.SetActive(true);
            //플레이어 조작 활성화
            //GetComponent<PlayerMove_Rio>().enabled = true;

            //자신의 서버상의 캐릭터 id가 뭔지 알려준다
            pv.RPC("userIdSetting", RpcTarget.AllBuffered, auth.CurrentUser.UserId);

        }
        else
        {
            //플레이어 카메라 비활성화
            Cam.SetActive(false);
            RPCIK.SetActive(true);
            //플레이어 조작 활성화
            GetComponent<PlayerMove_Rio>().enabled = false;
        }

        SetIkInfo();
    }

    private void Update()
    {
        if(pv.IsMine == true)
        {
            pv.RPC("SendIKInfo", RpcTarget.All, 0, vrLeft.position, vrLeft.eulerAngles);
            pv.RPC("SendIKInfo", RpcTarget.All, 1, vrRight.position, vrRight.eulerAngles);
            pv.RPC("SendIKInfo", RpcTarget.All, 2, vrlook.position, vrlook.eulerAngles);
        }
    }

    [PunRPC]
    void SendIKInfo(int index, Vector3 pos, Vector3 rot)
    {
        if(pv.IsMine == false)
        {
            if(index == 0)
            {
                ikLeft.transform.position = pos;
                ikLeft.transform.eulerAngles = rot;
            }
            if (index == 1)
            {
                ikRight.transform.position = pos;
                ikRight.transform.eulerAngles = rot;
            }
            if (index == 2)
            {
                iklook.transform.position = pos;
            }
        }
    }


    [PunRPC]
    void userIdSetting(string id)
    {
        userid = id;

        print("아이디가 셋팅 되었습니다." + userid);
        db.LoadUserInfo(userid, CCSetting);
    }

    //캐릭터가 생성되면 자신의 모습을 CC 데이터로 업데이트 하는 함수
    //[PunRPC]
    void CCSetting()
    {
        //성별에 따라 케릭터 활성화한다
        //그리고 케릭터 업댓하는 속성을 등록해주고
        if (db == null)
        {
            print("비어있습니다");
        }
        if (db.myInfo.characterCustomizationSetup.settingsName == "MaleSettings")
        {
            Man.SetActive(true);
            db.UserSetting = Man.GetComponent<CharacterCustomization>();
            //GetComponent<PlayerMove_Rio>().anim = Man.GetComponent<Animator>();
        }
        else if (db.myInfo.characterCustomizationSetup.settingsName == "FemaleSettings")
        {
            Woman.SetActive(true);
            db.UserSetting = Woman.GetComponent<CharacterCustomization>();
            //GetComponent<PlayerMove_Rio>().anim = Woman.GetComponent<Animator>();
        }

        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);

    }

    void SetIkInfo()
    {
        IKManager_SEJ iKManagerMan = Man.GetComponent<IKManager_SEJ>();
        IKManager_SEJ iKManagerWoman = Woman.GetComponent<IKManager_SEJ>();
        if(pv.IsMine)
        {
            iKManagerMan.Init(vrLeft, vrRight, vrlook);
            iKManagerWoman.Init(vrLeft, vrRight, vrlook);
        }
        else
        {
            iKManagerMan.Init(ikLeft, ikRight, iklook);
            iKManagerWoman.Init(ikLeft, ikRight, iklook);
        }
    }
}

