using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using AdvancedPeopleSystem;
public class Pun_Rio : MonoBehaviourPunCallbacks
{
    //���ӹ���
    private readonly string version = "1.0";
    //�����г���
    private string userId = "Rio";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userId;

        //���� ���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    //���� �� ȣ��Ǵ� �ݹ��Լ�
    public override void OnConnectedToMaster()
    {
        print("������ ���� ����");
        //�κ�� ����
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print("�κ� ����");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;
        ro.IsVisible = true;

        //������ //Start�� ���� �õ� ������ Start���̸����� ������� �Լ�
        PhotonNetwork.JoinOrCreateRoom("Start", ro, TypedLobby.Default);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("�޷�~ ���������!");
    }

    Transform spawnPoint; //������ ��ġ
    string userid;
    public override void OnJoinedRoom()
    {
        print("������ ����!");
        print($"���̸� = {PhotonNetwork.CurrentRoom.Name}");
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            print($"{player.Value.NickName},{player.Value.ActorNumber}");
        }

        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        userid = Database_Rio.instance.auth.CurrentUser.UserId;
        //PhotonNetwork.Instantiate("Man", spawnPoint.position, spawnPoint.rotation, 0);

        photonView.RPC("initCharacter", RpcTarget.All, userid);
    }

    GameObject Player;

    [PunRPC]
    public void initCharacter(string userid)
    {
        //StartCoroutine(UserInit(userid));
        //�ϴ� �������� ���� �о�´�
        Database_Rio.instance.LoadUserInfo(userid, ttt);
    }

    
    public IEnumerator UserInit(string userid)
    {

        yield return new WaitForSeconds(0.5f);

        //�ϴ� �������� ���� �о�´�
        Database_Rio.instance.LoadUserInfo(userid, ttt);

        yield return new WaitForSeconds(3f);

        
    }

    public void ttt()
    {
        if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "MaleSettings")
        {
            Player = PhotonNetwork.Instantiate("Man", spawnPoint.position, spawnPoint.rotation, 0);
        }
        else if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "FemaleSettings")
        {
            Player = PhotonNetwork.Instantiate("Wamen", spawnPoint.position, spawnPoint.rotation, 0);
        }

        Database_Rio.instance.UserSetting = Player.GetComponent<CharacterCustomization>();
        Database_Rio.instance.UserSetting.SetCharacterSetup(Database_Rio.instance.myInfo.characterCustomizationSetup);
    }

}
