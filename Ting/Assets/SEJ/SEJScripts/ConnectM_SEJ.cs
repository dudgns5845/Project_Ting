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
   

    //버튼이 클릭 되었을 때
    public void OnClickConnect()
    {
        //1.만약에 ID에 값이 있으면
        if (inputID.text.Length == 0)
        {
            print("ID가 없습니다.");
            return;
        }
        //2.포톤 기본 셋팅하고
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.AutomaticallySyncScene = true;
        //3.접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected(); //부모 호출
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);  // OnConnected() 함수를 호출한다.

    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //닉네임 설정
        PhotonNetwork.NickName = inputID.text;
        //로비 진입
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.JoinLobby(new TypedLobby("Ting",LobbyType.Default)); //특정 로비("Ting")에 진입
    }
    //로비 접속이 성공하면 호출 되는 함수

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //로비씬 이동
        PhotonNetwork.LoadLevel("SceneLobby");

    }

}
