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
    public GameObject playerController;

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
            playerController.SetActive(true);
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

        //������ ���̽����� CC�����͸� �о�´�
        //�а� �� �������� ������ �����Ѵ� ==> �ݹ�
        //db.LoadUserInfo(CCSetting);
        //pv.RPC("UpdateUserCharacter", RpcTarget.AllBuffered, userid);

    }



    void check()
    {
        pv.RPC("CCSetting", RpcTarget.AllBuffered);
    }


    [PunRPC]
    void userIdSetting(string id)
    {
        userid = id;
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

        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
    }


    //[PunRPC]
    //void UpdateCharacter()
    //{
    //    if (pv.IsMine)
    //    {
    //        //cc������ ������ Ȱ��ȭ�Ѵ�
    //        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
    //    }  
    //    else
    //    {
    //        db.LoadUserInfo(CCSetting);
    //        //cc������ ������ Ȱ��ȭ�Ѵ�
    //        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
    //    }

    //}

    //[PunRPC]
    //public void initCharacter(string userid)
    //{
    //    //StartCoroutine(UserInit(userid));
    //    //�ϴ� �������� ���� �о�´�
    //    Database_Rio.instance.LoadUserInfo(userid, ttt);
    //}


    //public IEnumerator UserInit(string userid)
    //{

    //    yield return new WaitForSeconds(0.5f);

    //    //�ϴ� �������� ���� �о�´�
    //    Database_Rio.instance.LoadUserInfo(userid, ttt);

    //    yield return new WaitForSeconds(3f);


    //}

    //public void ttt()
    //{
    //    if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "MaleSettings")
    //    {
    //        Player = PhotonNetwork.Instantiate("Man", spawnPoint.position, spawnPoint.rotation, 0);
    //    }
    //    else if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "FemaleSettings")
    //    {
    //        Player = PhotonNetwork.Instantiate("Wamen", spawnPoint.position, spawnPoint.rotation, 0);
    //    }

    //    Database_Rio.instance.UserSetting = Player.GetComponent<CharacterCustomization>();
    //    Database_Rio.instance.UserSetting.SetCharacterSetup(Database_Rio.instance.myInfo.characterCustomizationSetup);
    //}

}
