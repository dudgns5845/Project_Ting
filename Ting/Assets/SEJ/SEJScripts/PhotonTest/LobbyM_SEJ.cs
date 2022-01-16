using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyM_SEJ : MonoBehaviourPunCallbacks
{
    public InputField inputRoomName; //방이름
    public InputField inputMaxPlayer; //최대인원

    public Button btnCreateRoom; //방 생성
    public Button btnJoinRoom; //방 입장하기



    void Start()
    {
        //inputRoomName.onValueChanged.AddListener(OnChangedRoomName);
        //람다식
        inputRoomName.onValueChanged.AddListener((string text) => {
            btnJoinRoom.interactable = text.Length > 0;
            OnChangedMaxPlayer(inputMaxPlayer.text);
        });
        inputMaxPlayer.onValueChanged.AddListener(OnChangedMaxPlayer);
    }

    void Update()
    {
        //1.InputRoomName에 값이 있으면 JoinRoom버튼 활성화
        btnJoinRoom.interactable = inputRoomName.text.Length > 0;
        #region 조건식으로 풀어쓰면
        //밑에 조건식을 위에 한줄로 바꿀 수 있음 if절 안에 있는거 자체가 이미 bool형식이 되니까
        //if(inputRoomName.text.Length >0)
        //{
        //    btnJoinRoom.interactable = true;

        //}
        //else
        //{
        //    btnJoinRoom.interactable = false;
        //}
        #endregion
        //2. InputRoomName과 InputMaxPlayer의 값이 있으면 CreateRoom버튼 활성화
        btnCreateRoom.interactable = inputRoomName.text.Length > 0 && inputMaxPlayer.text.Length > 0;


    }
        
    //*****함수 사용하면 효율적이고 Update에 바로 코드 써주면 간단한 코드로 가능
    //*****람다식으로 사용해도 가능 아무거나 선택해서 쓰기

    void OnChangedRoomName(string text)
    {
        //1.InputRoomName에 값이 있으면 JoinRoom버튼 활성화
        btnJoinRoom.interactable =text.Length > 0;
        OnChangedMaxPlayer(inputMaxPlayer.text);
    }
    void OnChangedMaxPlayer(string text)
    {
        //2. InputRoomName과 InputMaxPlayer의 값이 있으면 CreateRoom버튼 활성화
        btnCreateRoom.interactable = btnJoinRoom.interactable && text.Length > 0;
    }

    public void OnClickCreateRoom()
    {
        //방 옵션
        RoomOptions roomOptions = new RoomOptions();
        //기본값으로 true가 되어있음(안써줘도 됨)
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        //방 생성
        PhotonNetwork.CreateRoom(inputRoomName.text);
        
    }

    //방 생성 완료
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("방생성완료");
        //SceneManager.LoadScene("AirHockey");
        //SceneManager.LoadScene("MeetingScene");
        //print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    //방 생성 실패
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(inputRoomName.text);

    }
    //방 참가
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom(); //방입장
        PhotonNetwork.LoadLevel("MeetingScene"); //씬이동
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    //방 참가 실패
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    Dictionary<string, RoomInfo> cacheRoom = new Dictionary<string, RoomInfo>();
    //해당 로비에 방 목록의 변경 사항이 있으면 호출(추가,삭제,참가)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        //for (int i = 0; i < roomList.Count; i++)
        //{
        //    print(roomList[i].Name);
        //    print(roomList[i].MaxPlayers);
        //    print(roomList[i].PlayerCount);
        //}
        //1.룸리스트UI삭제
        //2.룸Cache를 삭제

        UpdateCacheRoom(roomList);
        //3.다시 룸Cache를 이용해서 룸리스트 UI 생성

        foreach (RoomInfo info in cacheRoom.Values)
        {
            print(info.Name + ", " + info.PlayerCount + " / " + info.MaxPlayers);
        }
    }
    void UpdateCacheRoom(List<RoomInfo> roomList)
    {
            // 1. roomList를 순차적으로 돌면서
        for(int i =0; i< roomList.Count; i++)
        {
            // 2. 해당이름이 cacheRoom에 key값으로 설정이 되었다면
            if (cacheRoom.ContainsKey(roomList[i].Name))
            {
                // 3. 해당roomInfo 갱신(변경,삭제)
                // 만약에 삭제되었다면
                if (roomList[i].RemovedFromList)
                {
                    cacheRoom.Remove(roomList[i].Name);
                    continue;
                }
            }
            else
            {
                // 4. 그렇지 않으면 roomInfo를 cacheRoom 추가 또는 변경한다
                cacheRoom[roomList[i].Name] = roomList[i];
            }
        }
    }

}
