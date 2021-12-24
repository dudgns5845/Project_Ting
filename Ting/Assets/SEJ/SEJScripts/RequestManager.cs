using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RequestManager : MonoBehaviour
{

    public static RequestManager RM;

    public GameObject requestBtn;
    public GameObject answerBtn;

    public Button rqButton;
    public Button Xbtn;

    public Button yesBtn;
    public Button noBtn;

    private void Awake()
    {
        if(RM == null)
        {
            RM = this;
        }
    }
    public void OnClickRequestBtn()
    {
        //요청UI창 열기
        requestBtn.SetActive(true);
    }
    public void OnClickRqButton()
    {
        //요청신청
        //대답창이 상대방에게로 넘어가도록 
        //넘어가고나면 요청창 사라지도록
        requestBtn.SetActive(false);

    }
    public void OnClickX()
    {
        //요청취소
        requestBtn.SetActive(false);
    }
    //대답UI
    public void OnClickAnswerBtn()
    {
        //팅 수락창 뜨기
        answerBtn.SetActive(true);

    }
    public void OnClickYesBtn()
    {
        //수락
        

    }
    public void OnClickNoBtn()
    {
        //거절
        answerBtn.SetActive(false);

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
