using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;

//광장에 접속하면 생성되는 플레이어 셋팅 스크립트
public class Player_Pun_Setting_Rio : MonoBehaviour
{
    PhotonView pv;
    PhotonVoiceView pv_voice;
    public GameObject Cam;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            //플레이어 카메라 활성화
            Cam.SetActive(true);
            //플레이어 조작 활성화
            GetComponent<PlayerMove_Rio>().enabled = true;
        }
        else
        {
            //플레이어 카메라 비활성화
            Cam.SetActive(false);
            //플레이어 조작 활성화
            GetComponent<PlayerMove_Rio>().enabled = false;
        }
    }


    //캐릭터가 생성되면 자신의 모습을 CC 데이터로 업데이트 하는 함수
    void CCSetting()
    {
        Database_Rio.instance.LoadUserInfo("",null);
    }
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
















    //private void Start()
    //{
    //    pv = GetComponent<PhotonView>();
    //    pv_voice = GetComponent<PhotonVoiceView>();
    //    if (pv.IsMine)
    //    {
    //        pv_voice.enabled = true;
    //        GetComponent<PlayerMove_Rio>().enabled = true;
    //        Cam.SetActive(true);
    //        AudioListener.volume = 1;
    //    }
    //    else
    //    {
    //        pv_voice.enabled = false;
    //        GetComponent<AudioListener>().enabled = false;
    //        GetComponent<PlayerMove_Rio>().enabled = false;
    //        Cam.SetActive(false);
    //    }
    //}
}
