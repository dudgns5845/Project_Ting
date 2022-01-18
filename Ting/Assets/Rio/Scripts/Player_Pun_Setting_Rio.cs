using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;
using AdvancedPeopleSystem;
using Firebase.Auth;

//���忡 �����ϸ� �����Ǵ� �÷��̾� ���� ��ũ��Ʈ
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
            //�÷��̾� ī�޶� Ȱ��ȭ
            Cam.SetActive(true);
            //�÷��̾� ���� Ȱ��ȭ
            //GetComponent<PlayerMove_Rio>().enabled = true;

            //�ڽ��� �������� ĳ���� id�� ���� �˷��ش�
            pv.RPC("userIdSetting", RpcTarget.AllBuffered, auth.CurrentUser.UserId);

        }
        else
        {
            //�÷��̾� ī�޶� ��Ȱ��ȭ
            Cam.SetActive(false);
            RPCIK.SetActive(true);
            //�÷��̾� ���� Ȱ��ȭ
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

        print("���̵� ���� �Ǿ����ϴ�." + userid);
        db.LoadUserInfo(userid, CCSetting);
    }

    //ĳ���Ͱ� �����Ǹ� �ڽ��� ����� CC �����ͷ� ������Ʈ �ϴ� �Լ�
    //[PunRPC]
    void CCSetting()
    {
        //������ ���� �ɸ��� Ȱ��ȭ�Ѵ�
        //�׸��� �ɸ��� �����ϴ� �Ӽ��� ������ְ�
        if (db == null)
        {
            print("����ֽ��ϴ�");
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

