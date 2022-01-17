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


    //신규 회원 정보 저장 함수
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
        //저장 경로
        string path = "USER_INFO/"+auth.CurrentUser.UserId;
        //해당 경로에 값 저장
        var task = database.GetReference(path).SetRawJsonValueAsync(JsonUtility.ToJson(myInfo));

        yield return new WaitUntil(() => task.IsCompleted);

        if(task.Exception == null)
        {
            print("유저 정보 저장 성공");
        }
        else
        {
            print("유저 정보 저장 실패 : " + task.Exception);
        }
    }


    //캐릭터 커스텀 정보만 업데이트하는 함수
    public void SaveCCData(string NextPage)
    {
        StartCoroutine(ISaveCCData(NextPage));
    }

    IEnumerator ISaveCCData(string NextPage)
    {
        myInfo.characterCustomizationSetup = UserSetting.GetSetup();
        //저장 경로
        string path = "USER_INFO/" + auth.CurrentUser.UserId+ "/characterCustomizationSetup";
        //해당 경로에 값 저장
        var task = database.GetReference(path).SetRawJsonValueAsync(JsonUtility.ToJson(myInfo.characterCustomizationSetup));

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception == null)
        {
            print("캐릭터 정보 저장 성공");
            SceneManager.LoadScene(NextPage);
        }
        else
        {
            print("캐릭터 정보 저장 실패 : " + task.Exception);
        }
    }

    //값을 불러오는 함수
    public void LoadUserInfo(string userid_, Action NextWork)
    {
        StartCoroutine(ILoadUserInfo(userid_, NextWork));
    }

    IEnumerator ILoadUserInfo(string userid_, Action NextWork)
    {
       
        //저장 경로
        //string path = "USER_INFO/" + auth.CurrentUser.UserId;
        string path = "USER_INFO/" + userid_;
        //해당 경로에 값 가져오기
        var task = database.GetReference(path).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception == null)
        {
            myInfo = JsonUtility.FromJson<UserInfo>(task.Result.GetRawJsonValue());
            print("유저 정보 읽기 성공");
        }
        else
        {
            print("유저 정보 읽기 실패 : " + task.Exception);
        }
        NextWork();
    }
}


