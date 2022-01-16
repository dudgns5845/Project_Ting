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
 

    public Database_Rio db;

    private void Start()
    {
        db = GetComponent<Database_Rio>();
        pv = GetComponent<PhotonView>();
        auth = FirebaseAuth.DefaultInstance;

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
            //�÷��̾� ���� Ȱ��ȭ
            GetComponent<PlayerMove_Rio>().enabled = false;
        }

        db.LoadUserInfo(userid, check);

    }



    void check()
    {
        print("�ɸ��� Ŀ���� ������ ������Ʈ �Ǿ����ϴ�.");
        pv.RPC("CCSetting", RpcTarget.AllBuffered);
    }


    [PunRPC]
    void userIdSetting(string id)
    {
        userid = id;
        print("���̵� ���� �Ǿ����ϴ�.");
    }




    //ĳ���Ͱ� �����Ǹ� �ڽ��� ����� CC �����ͷ� ������Ʈ �ϴ� �Լ�
    [PunRPC]
    void CCSetting()
    {
        //������ ���� �ɸ��� Ȱ��ȭ�Ѵ�
        //�׸��� �ɸ��� �����ϴ� �Ӽ��� ������ְ�
        if(db == null)
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
        if (pv.IsMine)
        {
            db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
        }
    }
}

