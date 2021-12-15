using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager_Rio : MonoBehaviour
{
    public void onClickSave()
    {
        Database_Rio.instance.SaveUserInfo();
    }

    public void onClickLoad()
    {

    }
}
