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
    public GameObject playerController;

    public Database_Rio db;

    private void Start()
    {

        db = GetComponent<Database_Rio>();
        pv = GetComponent<PhotonView>();
        auth = FirebaseAuth.DefaultInstance;

        if (pv.IsMine)
        {
            //플레이어 카메라 활성화
            Cam.SetActive(true);
            //플레이어 조작 활성화
            //GetComponent<PlayerMove_Rio>().enabled = true;
            playerController.SetActive(true);
            //자신의 서버상의 캐릭터 id가 뭔지 알려준다
            pv.RPC("userIdSetting", RpcTarget.AllBuffered, auth.CurrentUser.UserId);

        }
        else
        {
            //플레이어 카메라 비활성화
            Cam.SetActive(false);
            //플레이어 조작 활성화
            GetComponent<PlayerMove_Rio>().enabled = false;
        }

        db.LoadUserInfo(userid, check);

        //데이터 베이스에서 CC데이터를 읽어온다
        //읽고 난 다음에야 셋팅을 시작한다 ==> 콜백
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




    //캐릭터가 생성되면 자신의 모습을 CC 데이터로 업데이트 하는 함수
    [PunRPC]
    void CCSetting()
    {
        //성별에 따라 케릭터 활성화한다
        //그리고 케릭터 업댓하는 속성을 등록해주고
        if(db == null)
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


    //[PunRPC]
    //void UpdateCharacter()
    //{
    //    if (pv.IsMine)
    //    {
    //        //cc정보를 가지고 활성화한다
    //        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
    //    }  
    //    else
    //    {
    //        db.LoadUserInfo(CCSetting);
    //        //cc정보를 가지고 활성화한다
    //        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
    //    }

    //}

    //[PunRPC]
    //public void initCharacter(string userid)
    //{
    //    //StartCoroutine(UserInit(userid));
    //    //일단 서버에서 값을 읽어온다
    //    Database_Rio.instance.LoadUserInfo(userid, ttt);
    //}


    //public IEnumerator UserInit(string userid)
    //{

    //    yield return new WaitForSeconds(0.5f);

    //    //일단 서버에서 값을 읽어온다
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
