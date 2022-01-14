using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyM_SEJ : MonoBehaviourPunCallbacks
{
    public InputField inputRoomName; //���̸�
    public InputField inputMaxPlayer; //�ִ��ο�

    public Button btnCreateRoom; //�� ����
    public Button btnJoinRoom; //�� �����ϱ�



    void Start()
    {
        //inputRoomName.onValueChanged.AddListener(OnChangedRoomName);
        //���ٽ�
        inputRoomName.onValueChanged.AddListener((string text) => {
            btnJoinRoom.interactable = text.Length > 0;
            OnChangedMaxPlayer(inputMaxPlayer.text);
        });
        inputMaxPlayer.onValueChanged.AddListener(OnChangedMaxPlayer);
    }

    void Update()
    {
        //1.InputRoomName�� ���� ������ JoinRoom��ư Ȱ��ȭ
        btnJoinRoom.interactable = inputRoomName.text.Length > 0;
        #region ���ǽ����� Ǯ���
        //�ؿ� ���ǽ��� ���� ���ٷ� �ٲ� �� ���� if�� �ȿ� �ִ°� ��ü�� �̹� bool������ �Ǵϱ�
        //if(inputRoomName.text.Length >0)
        //{
        //    btnJoinRoom.interactable = true;

        //}
        //else
        //{
        //    btnJoinRoom.interactable = false;
        //}
        #endregion
        //2. InputRoomName�� InputMaxPlayer�� ���� ������ CreateRoom��ư Ȱ��ȭ
        btnCreateRoom.interactable = inputRoomName.text.Length > 0 && inputMaxPlayer.text.Length > 0;


    }
        
    //*****�Լ� ����ϸ� ȿ�����̰� Update�� �ٷ� �ڵ� ���ָ� ������ �ڵ�� ����
    //*****���ٽ����� ����ص� ���� �ƹ��ų� �����ؼ� ����

    void OnChangedRoomName(string text)
    {
        //1.InputRoomName�� ���� ������ JoinRoom��ư Ȱ��ȭ
        btnJoinRoom.interactable =text.Length > 0;
        OnChangedMaxPlayer(inputMaxPlayer.text);
    }
    void OnChangedMaxPlayer(string text)
    {
        //2. InputRoomName�� InputMaxPlayer�� ���� ������ CreateRoom��ư Ȱ��ȭ
        btnCreateRoom.interactable = btnJoinRoom.interactable && text.Length > 0;
    }

    public void OnClickCreateRoom()
    {
        //�� �ɼ�
        RoomOptions roomOptions = new RoomOptions();
        //�⺻������ true�� �Ǿ�����(�Ƚ��൵ ��)
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        //�� ����
        PhotonNetwork.CreateRoom(inputRoomName.text);
        
    }

    //�� ���� �Ϸ�
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("������Ϸ�");
        //SceneManager.LoadScene("AirHockey");
        //SceneManager.LoadScene("MeetingScene");
        //print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    //�� ���� ����
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(inputRoomName.text);

    }
    //�� ����
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom(); //������
        PhotonNetwork.LoadLevel("MeetingScene"); //���̵�
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    //�� ���� ����
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    Dictionary<string, RoomInfo> cacheRoom = new Dictionary<string, RoomInfo>();
    //�ش� �κ� �� ����� ���� ������ ������ ȣ��(�߰�,����,����)
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
        //1.�븮��ƮUI����
        //2.��Cache�� ����

        UpdateCacheRoom(roomList);
        //3.�ٽ� ��Cache�� �̿��ؼ� �븮��Ʈ UI ����

        foreach (RoomInfo info in cacheRoom.Values)
        {
            print(info.Name + ", " + info.PlayerCount + " / " + info.MaxPlayers);
        }
    }
    void UpdateCacheRoom(List<RoomInfo> roomList)
    {
            // 1. roomList�� ���������� ���鼭
        for(int i =0; i< roomList.Count; i++)
        {
            // 2. �ش��̸��� cacheRoom�� key������ ������ �Ǿ��ٸ�
            if (cacheRoom.ContainsKey(roomList[i].Name))
            {
                // 3. �ش�roomInfo ����(����,����)
                // ���࿡ �����Ǿ��ٸ�
                if (roomList[i].RemovedFromList)
                {
                    cacheRoom.Remove(roomList[i].Name);
                    continue;
                }
            }
            else
            {
                // 4. �׷��� ������ roomInfo�� cacheRoom �߰� �Ǵ� �����Ѵ�
                cacheRoom[roomList[i].Name] = roomList[i];
            }
        }
    }

}
