using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCKrequestM : MonoBehaviour
{
    public GameObject requestCanvas;
    public GameObject requestBtn;
    public GameObject requestLoading;
    public GameObject reject;
    // Start is called before the first frame update

    public void OnclickrequestBtn()
    {
        requestBtn.SetActive(false);
        requestLoading.SetActive(true);
    }

    public void OnclickReject_Acceptbtn()
    {
        requestCanvas.SetActive(false);
        requestBtn.SetActive(false);
        requestLoading.SetActive(false);
        reject.SetActive(false);


    }
}
