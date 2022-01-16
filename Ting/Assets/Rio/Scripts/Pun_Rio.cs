using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using AdvancedPeopleSystem;
public class Pun_Rio : MonoBehaviourPunCallbacks
{
    //게임버전
    private readonly string version = "1.0";
    //유저닉네임
    private string userId = "Rio";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = userId;

        //포톤 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    //접속 후 호출되는 콜백함수
    public override void OnConnectedToMaster()
    {
        print("마스터 서버 접속");
        //로비로 접속
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print("로비 접속");

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;
        ro.IsVisible = true;

        //방접속 //Start씬 접속 시도 없으면 Start씬이름으로 방생성후 입성
        PhotonNetwork.JoinOrCreateRoom("Start", ro, TypedLobby.Default);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("메롱~ 방입장실패!");
    }

   

    public override void OnJoinedRoom()
    {
        print("방입장 성공!");
        print($"방이름 = {PhotonNetwork.CurrentRoom.Name}");
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            print($"{player.Value.NickName},{player.Value.ActorNumber}");
        }

        Transform spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        
        //플레이어 생성
        PhotonNetwork.Instantiate("Player_0114", spawnPoint.position, spawnPoint.rotation, 0);
    }

}
