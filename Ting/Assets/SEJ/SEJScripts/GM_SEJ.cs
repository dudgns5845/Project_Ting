using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GM_SEJ : MonoBehaviourPunCallbacks
{
    public PhotonView myPhotonView;
    public Transform[] playerPos;
    //현재 위치할 index
    int playerPosIndex;
    void Start()
    {
       if(PhotonNetwork.IsConnected)
        {
            CreatePlayer();
        }
        else
        {
            //게임 버전 설정
            PhotonNetwork.GameVersion = "1";
            //접속 시도 (name서버 -> master서버)
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreatePlayer()
    {
        PhotonNetwork.SendRate = 50;
        PhotonNetwork.SerializationRate = 50;
        //나의 플레이어를 생성
        Vector3 pos = new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f));
        //Vector3 pos = new Vector3(0,0,0);
        PhotonNetwork.Instantiate("LobbyPlayer", pos, Quaternion.identity);




    }
}
