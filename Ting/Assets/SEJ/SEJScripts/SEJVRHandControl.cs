using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//하키
//소개팅

public class SEJVRHandControl : MonoBehaviour
{
    public static SEJVRHandControl vrhandcontrol;


    //오른손 Transform
    public Transform trRight;
    //왼손 Transform
    public Transform trLeft;

    public LineRenderer line;

    public GameObject grabObject;
    bool isTriggerDown;
    bool isHandDown;
    private bool tryGrab;
    public float grabRadius = 0.5f;

    bool gameScene;
    bool cafeScene;



    private void Awake()
    {
        if (vrhandcontrol == null)
            vrhandcontrol = this;
    }
    void Update()
    {
        ClickRay();
    }
    private void ClickRay()
    {
        //오른손 위치,오른손 앞방향으로 나가는 Ray를 만든다
        Ray ray = new Ray(trRight.position, trRight.forward);
        //맞은위치
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) //Ray발사 후 어딘가에 부딪힌다면
        {
            line.gameObject.SetActive(true);
            line.SetPosition(0, trRight.position);
            line.SetPosition(1, hit.point);

            print(hit.transform.name);
            if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                line.transform.parent = trRight;

                if (hit.transform.name.Contains("QButton"))
                {
                    SEJButton.btn.OnClickQ();
                }
               else if (hit.transform.name.Contains("XButton"))
                {
                    SEJButton.btn.OnClickX();
                }
                else if (hit.transform.name.Contains("ContentsButton"))
                {
                    SEJButton.btn.OnClickContents();
                }
                else if (hit.transform.name.Contains("Balance"))
                {
                    SEJButton.btn.OnClickBalance();

                }
                else if (hit.transform.name.Contains("Question"))
                {
                    SEJButton.btn.OnClickQuestion();
                }
                else if (hit.transform.name.Contains("BMenuBtn"))
                {
                    SEJButton.btn.BalanceMenuBtn();
                }
                else if (hit.transform.name.Contains("QMenuBtn"))
                {
                    SEJButton.btn.QuestionMenuBtn();
                }
                else if (hit.transform.name.Contains("RightBtn"))
                {
                    SEJButton.btn.OnClickRight();
                }
                else if (hit.transform.name.Contains("AirHockeyBtn")) //하키
                {
                    AirHockeyTableManager.hockeyTableM.OnClickHockeyBtn();
                    //하키 스크립트 켜기
                    GetComponent<ThrowHockeyBall>().enabled=true;
                }
                else if (hit.transform.name.Contains("AirHockeyOutBtn")) //하키
                {
                    AirHockeyTableManager.hockeyTableM.OnClickExitHockeyBtn();
                    GetComponent<ThrowHockeyBall>().enabled = false;
                }
                else if (hit.transform.name.Contains("StartDartBtn")) //다트
                {
                    SEJDartBoard.db.OnStartDart();
                }
                else if (hit.transform.name.Contains("ExitDartBtn")) //다트
                {
                    SEJDartBoard.db.OnExitDart();
                }
                else if (hit.transform.name.Contains("StartGunBtn")) //총
                {
                    GunTableManager.gunTableM.OnClickStartGun();
                }
                else if (hit.transform.name.Contains("ExitGunBtn")) //총
                {
                    GunTableManager.gunTableM.OnClickExitGun();
                }


                else
                {
                    line.enabled=false;
                }

            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                line.gameObject.SetActive(false);
                line.transform.parent = null;
                line.enabled = true;
            }

            ////아웃라인

            //if (hit.transform.name.Contains("Balance"))
            //{
            //    UnityEngine.UI.Outline outline = SEJMeetingGM.gm.balanceBtn.GetComponent<UnityEngine.UI.Outline>();
            //    outline.enabled = true;
            //}
            //else
            //{
            //    UnityEngine.UI.Outline outline = SEJMeetingGM.gm.balanceBtn.GetComponent<UnityEngine.UI.Outline>();
            //    outline.enabled = false;

            //}

            //if (hit.transform.name.Contains("Question"))
            //{
            //    UnityEngine.UI.Outline outline = SEJMeetingGM.gm.questionBtn.GetComponent<UnityEngine.UI.Outline>();
            //    outline.enabled = true;
              
            //}
            //else
            //{
            //    UnityEngine.UI.Outline outline = SEJMeetingGM.gm.questionBtn.GetComponent<UnityEngine.UI.Outline>();
            //    outline.enabled = false;

            //}

            //// 버튼 크기 증가

            //Vector3 btnScale = new Vector3(0.307f, 1, 1);

            //if(hit.transform.name.Contains("QButton"))
            //{
            //    SEJButton.btn.btnQ.transform.localScale = btnScale * 1.4f;
            //}
            //else
            //{
            //    SEJButton.btn.btnQ.transform.localScale = btnScale;
            //}

            //if(hit.transform.name.Contains("XButton"))
            //{
            //    SEJButton.btn.btnX.transform.localScale = btnScale * 1.4f;
            //}
            //else
            //{
            //    SEJButton.btn.btnX.transform.localScale = btnScale;
            //}

            //if(hit.transform.name.Contains("ContentsButton"))
            //{
            //    SEJButton.btn.btnC.transform.localScale = btnScale * 1.4f;

            //}
            //else
            //{
            //    SEJButton.btn.btnC.transform.localScale = btnScale;

            //}
        }
    }


}
