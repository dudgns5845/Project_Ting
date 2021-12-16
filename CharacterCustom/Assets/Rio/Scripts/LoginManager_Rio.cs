using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager_Rio : MonoBehaviour
{
    public GameObject SignInUI;
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

        Database_Rio.instance.SaveUserInfo(Name.text,NickName.text,AgeName.text,Gender);
    }


    
   
}
