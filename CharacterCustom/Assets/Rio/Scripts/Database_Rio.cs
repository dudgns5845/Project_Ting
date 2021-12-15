using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using AdvancedPeopleSystem;
using UnityEngine.UI;

[System.Serializable]
public class UserInfo
{
    public string name;
    public string gender;
    public string nickname;
    public CharacterCustomizationSetup characterCustomizationSetup;
}



public class Database_Rio : MonoBehaviour
{
    public InputField input_NickName;
    public static Database_Rio instance;
    public CharacterCustomization UserSetting;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    FirebaseDatabase database;
    FirebaseAuth auth;

   

    UserInfo myInfo = new UserInfo();
    private void Start()
    {
        database = FirebaseDatabase.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;
       
    }


    public void SaveUserInfo()
    {
        StartCoroutine(ISaveUserInfo());
    }

    IEnumerator ISaveUserInfo()
    {

        myInfo.characterCustomizationSetup = UserSetting.GetSetup();

        myInfo.name = "�̿���";
        myInfo.gender = "Man";
        myInfo.nickname = input_NickName.text;


        string path = "USER_INFO/"+auth.CurrentUser.UserId;
         

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
}


