using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;

//���忡 �����ϸ� �����Ǵ� �÷��̾� ���� ��ũ��Ʈ
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
            //�÷��̾� ī�޶� Ȱ��ȭ
            Cam.SetActive(true);
            //�÷��̾� ���� Ȱ��ȭ
            GetComponent<PlayerMove_Rio>().enabled = true;
        }
        else
        {
            //�÷��̾� ī�޶� ��Ȱ��ȭ
            Cam.SetActive(false);
            //�÷��̾� ���� Ȱ��ȭ
            GetComponent<PlayerMove_Rio>().enabled = false;
        }
    }


    //ĳ���Ͱ� �����Ǹ� �ڽ��� ����� CC �����ͷ� ������Ʈ �ϴ� �Լ�
    void CCSetting()
    {
        Database_Rio.instance.LoadUserInfo("",null);
    }
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
