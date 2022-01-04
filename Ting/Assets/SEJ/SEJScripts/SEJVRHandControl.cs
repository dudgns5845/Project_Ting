using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//��Ű
//�Ұ���

public class SEJVRHandControl : MonoBehaviour
{
    public static SEJVRHandControl vrhandcontrol;


    //������ Transform
    public Transform trRight;
    //�޼� Transform
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


    //void GrabHockeyStick()
    //{
    //    if (isHandDown && isTriggerDown) //����ư�� ������ ��
    //    {

    //        if (false == tryGrab) //�������ٸ�
    //        {
    //            // ��� ����
    //            tryGrab = true;
    //            // trRight�� �߽����� �ݰ� 0.1M ���� Mallet���̾� �浹ü�� ��� �˻��ϰ�ʹ�.
    //            int layerMask = 1 << LayerMask.NameToLayer("Stick");
    //            Collider[] cols = Physics.OverlapSphere(trRight.position, grabRadius, layerMask);
    //            if (cols.Length > 0)
    //            {
    //                grabObject = cols[0].gameObject;
    //                // ���� �θ� = ��
    //                grabObject.transform.parent = trRight;
    //                grabObject.transform.position = trRight.position;
    //            }
    //        }
    //    }

    //}

    //void MeetingRoomHand()
    //{
    //    if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
    //    {
    //        ClickRay();
    //    }
    //}

    private void ClickRay()
    {
        //������ ��ġ,������ �չ������� ������ Ray�� �����
        Ray ray = new Ray(trRight.position, trRight.forward);
        //������ġ
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) //Ray�߻� �� ��򰡿� �ε����ٸ�
        {
            line.gameObject.SetActive(true);
            line.SetPosition(0, trRight.position);
            line.SetPosition(1, hit.point);

            //if(OVRInput.GetDown(OVRInput.Button.Two))
            if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                print(hit.transform.name);
                //int layerMask = 1 << LayerMask.NameToLayer("Q");
          
                line.transform.parent = trRight;

                if (hit.transform.name.Contains("QButton"))
                {
                    SEJButton.btn.OnClickQ();
                }
                if (hit.transform.name.Contains("XButton"))
                {
                    SEJButton.btn.OnClickX();
                }
                if (hit.transform.name.Contains("ContentsButton"))
                {
                    SEJButton.btn.OnClickContents();
                }
                if (hit.transform.name.Contains("Balance"))
                {
                    SEJButton.btn.OnClickBalance();

                }
                if (hit.transform.name.Contains("Question"))
                {
                    SEJButton.btn.OnClickQuestion();
                }
                if (hit.transform.name.Contains("BMenuBtn"))
                {
                    SEJButton.btn.BalanceMenuBtn();
                }
                if (hit.transform.name.Contains("QMenuBtn"))
                {
                    SEJButton.btn.QuestionMenuBtn();
                }
                if (hit.transform.name.Contains("RightBtn"))
                {
                    SEJButton.btn.OnClickRight();
                }
                if(hit.transform.name.Contains("AirHockeyBtn")) //��Ű
                {
                    AirHockeyTableManager.hockeyTableM.OnClickHockeyBtn();
                    //��Ű ��ũ��Ʈ �ѱ�
                    GetComponent<ThrowHockeyBall>().enabled=true;
                }
                if(hit.transform.name.Contains("AirHockeyOutBtn")) //��Ű
                {
                    AirHockeyTableManager.hockeyTableM.OnClickExitHockeyBtn();
                    GetComponent<ThrowHockeyBall>().enabled = false;
                }
                if (hit.transform.name.Contains("StartDartBtn")) //��Ʈ
                {
                    SEJDartBoard.db.OnStartDart();
                    //GetComponent<ThrowDart>().enabled = true;
                }
                if (hit.transform.name.Contains("ExitDartBtn")) //��Ʈ
                {
                    SEJDartBoard.db.OnExitDart();
                    //GetComponent<ThrowDart>().enabled = false;
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

            ////�ƿ�����

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

            //// ��ư ũ�� ����

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

    void Update()
    {
        ClickRay();
    }
}
