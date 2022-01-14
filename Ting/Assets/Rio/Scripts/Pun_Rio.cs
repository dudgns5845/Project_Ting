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

   

    public override void OnJoinedRoom()
    {
        print("������ ����!");
        print($"���̸� = {PhotonNetwork.CurrentRoom.Name}");
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            print($"{player.Value.NickName},{player.Value.ActorNumber}");
        }

        Transform spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        
        //�÷��̾� ����
        PhotonNetwork.Instantiate("Player_0114", spawnPoint.position, spawnPoint.rotation, 0);
    }

}
