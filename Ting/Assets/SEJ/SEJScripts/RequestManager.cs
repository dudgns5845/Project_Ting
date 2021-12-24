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
        //��ûUIâ ����
        requestBtn.SetActive(true);
    }
    public void OnClickRqButton()
    {
        //��û��û
        //���â�� ���濡�Է� �Ѿ���� 
        //�Ѿ���� ��ûâ ���������
        requestBtn.SetActive(false);

    }
    public void OnClickX()
    {
        //��û���
        requestBtn.SetActive(false);
    }
    //���UI
    public void OnClickAnswerBtn()
    {
        //�� ����â �߱�
        answerBtn.SetActive(true);

    }
    public void OnClickYesBtn()
    {
        //����
        

    }
    public void OnClickNoBtn()
    {
        //����
        answerBtn.SetActive(false);

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
