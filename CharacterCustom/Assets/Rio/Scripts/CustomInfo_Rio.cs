using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInfo_Rio : MonoBehaviour
{
    public static CustomInfo_Rio instance;

    private void Awake()
    {
       DontDestroyOnLoad(gameObject);
    }

    public bool isMan = true;

    public void ChoiceMan()
    {
        isMan = true;
    }
    public void ChoiceWoman()
    {
        isMan = false;
    }
}
