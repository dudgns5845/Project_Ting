using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool tryGrab;
    public float grabRadius = 0.5f;



    private void Awake()
    {
        if (vrhandcontrol == null)
            vrhandcontrol = this;
    }
    void Update()
    {
        ClickRay();
    }

    public RaycastHit hit;
    private void ClickRay()
    {
        //������ ��ġ,������ �չ������� ������ Ray�� �����
        Ray ray_R = new Ray(trRight.position, trRight.forward);
        Ray ray_L = new Ray(trLeft.position, trLeft.forward);
        //������ġ
       
        int UilayerMask = 1 << LayerMask.NameToLayer("UI");
        int GriplayerMask = 1 << LayerMask.NameToLayer("gripObjectLayer");


        if (Physics.Raycast(ray_R, out hit,100, UilayerMask)) //Ray�߻� �� ��򰡿� �ε����ٸ�
        {
            LineDraw(trRight.position);
        }
        else if(Physics.Raycast(ray_L, out hit, 100, UilayerMask))
        {
            LineDraw(trLeft.position);
        }
       else if (Physics.Raycast(ray_R, out hit, 100, GriplayerMask)) 
        {
            LineDraw(trRight.position);
        }
        else if(Physics.Raycast(ray_L, out hit, 100, GriplayerMask))
        {
            LineDraw(trLeft.position);
        }
        else
        {
            //line.enabled = false;
            line.gameObject.SetActive(false);
        }
    }


    void LineDraw(Vector3 Pos)
    {
        line.gameObject.SetActive(true);
        line.SetPosition(0, Pos);
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
            //else if (hit.transform.name.Contains("AirHockeyBtn")) //��Ű
            //{
            //    AirHockeyTableManager.hockeyTableM.OnClickHockeyBtn();
            //    //��Ű ��ũ��Ʈ �ѱ�
            //    GetComponent<ThrowHockeyBall>().enabled = true;
            //}
            //else if (hit.transform.name.Contains("AirHockeyOutBtn")) //��Ű
            //{
            //    AirHockeyTableManager.hockeyTableM.OnClickExitHockeyBtn();
            //    GetComponent<ThrowHockeyBall>().enabled = false;
            //}
            //else if (hit.transform.name.Contains("StartDartBtn")) //��Ʈ
            //{
            //    SEJDartBoard.db.OnStartDart();
            //}
            //else if (hit.transform.name.Contains("ExitDartBtn")) //��Ʈ
            //{
            //    SEJDartBoard.db.OnExitDart();
            //}
            //else if (hit.transform.name.Contains("StartGunBtn")) //��
            //{
            //    GunTableManager.gunTableM.OnClickStartGun();
            //}
            //else if (hit.transform.name.Contains("ExitGunBtn")) //��
            //{
            //    GunTableManager.gunTableM.OnClickExitGun();
            //}


        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            line.gameObject.SetActive(false);
            line.transform.parent = null;
            line.enabled = true;
        }

        #region outline
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
        #endregion
    }

}
