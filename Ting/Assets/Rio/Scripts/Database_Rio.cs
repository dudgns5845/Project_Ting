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
    public string nickname;
    public string gender;
    public int age;
    public CharacterCustomizationSetup characterCustomizationSetup;
}

public class Database_Rio : MonoBehaviour
{
    public static Database_Rio instance;
    public CharacterCustomization UserSetting;

    public UserInfo myInfo;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        myInfo = new UserInfo();
    }

    FirebaseDatabase database;
    public FirebaseAuth auth;


    private void Start()
    {
        database = FirebaseDatabase.DefaultInstance;
        auth = FirebaseAuth.DefaultInstance;
    }

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
    public void SaveCCData()
    {
        StartCoroutine(ISaveCCData());
    }

    IEnumerator ISaveCCData()
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
        }
        else
        {
            print("ĳ���� ���� ���� ���� : " + task.Exception);
        }
    }


    //���� �ҷ����� �Լ�
    public void LoadUserInfo()
    {
        StartCoroutine(ILoadUserInfo());
    }

    IEnumerator ILoadUserInfo()
    {
       
        //���� ���
        string path = "USER_INFO/" + auth.CurrentUser.UserId;
        //�ش� ��ο� �� ��������
        var task = database.GetReference(path).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception == null)
        {
            myInfo = JsonUtility.FromJson<UserInfo>(task.Result.GetRawJsonValue());
            
            //UserSetting.SetCharacterSetup(myInfo.characterCustomizationSetup);
            print("���� ���� �б� ����");
        }
        else
        {
            print("���� ���� �б� ���� : " + task.Exception);
        }
    }


}


