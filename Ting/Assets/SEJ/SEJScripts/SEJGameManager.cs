using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

//�� ���� �� ����� ���� ����
public class SEJGameManager : MonoBehaviourPunCallbacks
{
    public static SEJGameManager instance;
    
    public PhotonView myPhotonView;
    public Transform[] playerPos;
    //���� ��ġ�� indexv
    int playerPosIndex;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
       if(PhotonNetwork.IsConnected)
        {
            CreatePlayer();
        }
       else
        {
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    private void CreatePlayer()
    {
        PhotonNetwork.SendRate = 50;
        PhotonNetwork.SerializationRate = 50;
        //�� �÷��̾� ����
        //Vector3 playerPos = new Vector3(0, 1.93f, -2.01f);
        //PhotonNetwork.Instantiate("HockeyPlayer", playerPos, Quaternion.identity);
       //���� �ڽ��� ������ ���ڶ�� 
        Vector3 playerPos = new Vector3(-24.9f, 16, 0);
        PhotonNetwork.Instantiate("PlayerM", playerPos, Quaternion.identity);
       //���� �ڽ��� ������ ���ڶ�� 
        Vector3 playerPos2 = new Vector3(22.7f, 0, 5.4f);
        PhotonNetwork.Instantiate("PlayerW", playerPos2, Quaternion.identity);
       

        throw new NotImplementedException();
    }

    void Update()
    {
        
    }

    public void SetPlayerPos(PhotonView pv)
    {
        pv.RPC("RpcSetPlayerPos", RpcTarget.AllBuffered, playerPos[playerPosIndex].position);
        playerPosIndex++;
    }
    
}
