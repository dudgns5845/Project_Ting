using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectM_SEJ : MonoBehaviourPunCallbacks
{

    //Input Field
    public InputField inputID;
    //GameVersion
    public string gameVersion = "1";
   

    //��ư�� Ŭ�� �Ǿ��� ��
    public void OnClickConnect()
    {
        //1.���࿡ ID�� ���� ������
        if (inputID.text.Length == 0)
        {
            print("ID�� �����ϴ�.");
            return;
        }
        //2.���� �⺻ �����ϰ�
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.AutomaticallySyncScene = true;
        //3.���� �õ�
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected(); //�θ� ȣ��
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);  // OnConnected() �Լ��� ȣ���Ѵ�.

    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //�г��� ����
        PhotonNetwork.NickName = inputID.text;
        //�κ� ����
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.JoinLobby(new TypedLobby("Ting",LobbyType.Default)); //Ư�� �κ�("Ting")�� ����
    }
    //�κ� ������ �����ϸ� ȣ�� �Ǵ� �Լ�

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //�κ�� �̵�
        PhotonNetwork.LoadLevel("SceneLobby");

    }

}
