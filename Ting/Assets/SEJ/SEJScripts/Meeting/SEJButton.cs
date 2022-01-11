using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SEJButton : MonoBehaviour
{
    public static SEJButton btn;

    public Button btnQ;
    public Button btnX; //닫기버튼
    public Button btnC; //컨텐츠상자
    
    
    private void Awake()
    {
        if(btn==null)
        {
            btn = this;
        }
    }
    public void OnClickQ()
    {
        //if (MeetingGM.gm.startUI_ing) return;
        if (SEJMeetingGM.gm.contUI_ing)
        {
            SEJMeetingGM.gm.contentsTextBox.SetActive(false);
            SEJMeetingGM.gm.button.SetActive(false);
        }
        SEJMeetingGM.gm.startUI.SetActive(true);
    }
    public void OnClickX()
    {
        SEJMeetingGM.gm.startUI.SetActive(false);
        SEJMeetingGM.gm.contentsTextBox.SetActive(false);
        SEJMeetingGM.gm.contBox.SetActive(false);
        
    }
    public void OnClickContents()
    {
        SEJMeetingGM.gm.contUI_ing = true;
        SEJMeetingGM.gm.contBox.SetActive(true);
        SEJMeetingGM.gm.contentsTextBox.SetActive(true);
        SEJMeetingGM.gm.button.SetActive(true);
        SEJMeetingGM.gm.contentsTextBox.SetActive(false);

        //우선은 밸런스게임으로 잡고가기
        //나오면 왼쪽 오른쪽 버튼으로 페이지 넘길 수 있도록
        if (SEJMeetingGM.gm.startUI_ing)
        {
            SEJMeetingGM.gm.startUI.SetActive(false);
        }

    }
    public void QuestionMenuBtn()
    {

        SEJMeetingGM.gm.QmenuBtn.SetActive(false);
        SEJMeetingGM.gm.contentsTextBox.SetActive(false);
        SEJMeetingGM.gm.button.SetActive(true);
        SEJMeetingGM.gm.contBox.SetActive(true);

        // MeetingGM.gm.QuationList();

    }
    public void BalanceMenuBtn()
    {

        print("버튼 호출~~~");
        SEJMeetingGM.gm.BmenuBtn.SetActive(false);
        SEJMeetingGM.gm.button.SetActive(true);
        SEJMeetingGM.gm.contentsTextBox.SetActive(false);
       // MeetingGM.gm.BalanceList();


    }
    public void OnClickBalance()
    {
        SEJMeetingGM.gm.bbb = true;
        SEJMeetingGM.gm.button.SetActive(false);
        SEJMeetingGM.gm.contentsTextBox.SetActive(true);
        SEJMeetingGM.gm.rightBtn.SetActive(true);
        SEJMeetingGM.gm.BalanceList();
        SEJMeetingGM.gm.contentMSG.text = SEJMeetingGM.gm.balanceList[0];

    }
    public void OnClickQuestion()
    {
        SEJMeetingGM.gm.qqq = true;
        SEJMeetingGM.gm.button.SetActive(false);
        SEJMeetingGM.gm.contentsTextBox.SetActive(true);
        SEJMeetingGM.gm.rightBtn.SetActive(true);
        SEJMeetingGM.gm.QuationList();
        SEJMeetingGM.gm.contentMSG.text = SEJMeetingGM.gm.Quation[0];
    }

    //랜덤으로 받을 변수
    public int num;
    
    public void OnClickRight()
    {
        if(SEJMeetingGM.gm.bbb)
        {
            num = Random.Range(0, SEJMeetingGM.gm.balanceList.Count-1);
            SEJMeetingGM.gm.contentMSG.text = SEJMeetingGM.gm.balanceList[num];

            SEJMeetingGM.gm.balanceList.RemoveAt(num);
            
            if (SEJMeetingGM.gm.balanceList.Count == 0)
            {
                SEJMeetingGM.gm.contentMSG.text = "밸런스게임이 끝났습니다." + '\n' + "메뉴로 돌아가시겠습니까?";
                SEJMeetingGM.gm.rightBtn.SetActive(false);
                SEJMeetingGM.gm.BmenuBtn.SetActive(true);
                SEJMeetingGM.gm.bbb = false;
                print("호출~~~");
            }
        }
        if(SEJMeetingGM.gm.qqq)
        {
            num = Random.Range(0, SEJMeetingGM.gm.Quation.Count-1);
            SEJMeetingGM.gm.contentMSG.text = SEJMeetingGM.gm.Quation[num];
            SEJMeetingGM.gm.Quation.RemoveAt(num);
            if (SEJMeetingGM.gm.Quation.Count == 0)
            {
                SEJMeetingGM.gm.contentMSG.text = "질문이 끝났습니다." + '\n' + "메뉴로 돌아가시겠습니까?";
                SEJMeetingGM.gm.rightBtn.SetActive(false);
                SEJMeetingGM.gm.QmenuBtn.SetActive(true);
                SEJMeetingGM.gm.qqq = false;
            }
        }
    }

    public void CheckFinish()
    {

    }


}
