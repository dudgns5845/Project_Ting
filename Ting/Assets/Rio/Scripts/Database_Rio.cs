using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using AdvancedPeopleSystem;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UserInfo
{
    public string name;
    public string nickname;
    public string gender;
    public int age;
    public CharacterCustomizationSetup characterCustomizationSetup;
}

public class Database_Rio : MonoBehaviour
{
   
    public CharacterCustomization UserSetting;

    public UserInfo myInfo;
    FirebaseDatabase database;
    public FirebaseAuth auth;
    private void Awake()
    {
        myInfo = new UserInfo();
        database = FirebaseDatabase.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;
    }


    //�ű� ȸ�� ���� ���� �Լ�
    public void SaveUserInfo(string Name, string NickName, string Age, string Gender)
    {
        StartCoroutine(ISaveUserInfo(Name,NickName,Age,Gender));
    }

    IEnumerator ISaveUserInfo(string Name, string NickName, string Age, string Gender)
    {
        if(UserSetting != null)
        {
            myInfo.characterCustomizationSetup = UserSetting.GetSetup();
        }
        else
        {
            myInfo.characterCustomizationSetup = new CharacterCustomizationSetup();
        }

        myInfo.name = Name;
        myInfo.nickname = NickName;
        myInfo.age = int.Parse(Age);
        myInfo.gender = Gender;
        //���� ���
        string path = "USER_INFO/"+auth.CurrentUser.UserId;
        //�ش� ��ο� �� ����
        var task = database.GetReference(path).SetRawJsonValueAsync(JsonUtility.ToJson(myInfo));

        yield return new WaitUntil(() => task.IsCompleted);

        if(task.Exception == null)
        {
            print("���� ���� ���� ����");
        }
        else
        {
            print("���� ���� ���� ���� : " + task.Exception);
        }
    }


    //ĳ���� Ŀ���� ������ ������Ʈ�ϴ� �Լ�
    public void SaveCCData(string NextPage)
    {
        StartCoroutine(ISaveCCData(NextPage));
    }

    IEnumerator ISaveCCData(string NextPage)
    {
        myInfo.characterCustomizationSetup = UserSetting.GetSetup();
        //���� ���
        string path = "USER_INFO/" + auth.CurrentUser.UserId+ "/characterCustomizationSetup";
        //�ش� ��ο� �� ����
        var task = database.GetReference(path).SetRawJsonValueAsync(JsonUtility.ToJson(myInfo.characterCustomizationSetup));

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception == null)
        {
            print("ĳ���� ���� ���� ����");
            SceneManager.LoadScene(NextPage);
        }
        else
        {
            print("ĳ���� ���� ���� ���� : " + task.Exception);
        }
    }

    //���� �ҷ����� �Լ�
    public void LoadUserInfo(string userid_, Action NextWork)
    {
        StartCoroutine(ILoadUserInfo(userid_, NextWork));
    }

    IEnumerator ILoadUserInfo(string userid_, Action NextWork)
    {
       
        //���� ���
        //string path = "USER_INFO/" + auth.CurrentUser.UserId;
        string path = "USER_INFO/" + userid_;
        //�ش� ��ο� �� ��������
        var task = database.GetReference(path).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception == null)
        {
            myInfo = JsonUtility.FromJson<UserInfo>(task.Result.GetRawJsonValue());
            print("���� ���� �б� ����");
        }
        else
        {
            print("���� ���� �б� ���� : " + task.Exception);
        }
        NextWork();
    }
}


