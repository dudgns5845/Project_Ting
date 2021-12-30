using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager_Rio : MonoBehaviour
{
    public GameObject SignInUI;

    Database_Rio db;

    private void Start()
    {
        db = FindObjectOfType<Database_Rio>();
    }
    public void onClickSignIn()
    {
        SignInUI.SetActive(true);
    }


    public void onClickBack()
    {
        SignInUI.SetActive(false);
    }

    public InputField Name;
    public InputField NickName;
    public InputField AgeName;
    public Toggle Toggle_M;
    public Toggle Toggle_W;

    public void onClickSave()
    {
        string Gender = Toggle_M.isOn ? "남성" : "여성";

        db.SaveUserInfo(Name.text,NickName.text,AgeName.text,Gender);
    }


    
   
}
