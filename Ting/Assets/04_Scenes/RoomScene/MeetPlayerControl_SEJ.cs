using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetPlayerControl_SEJ : MonoBehaviour
{
    //��� ����ġ, ����
    public Transform trRight;
    public Transform trLeft;
    public LineRenderer line;
    public LayerMask layer;
    //public Button btn;
    void Update()
    {
        ClickRay();
    }

    private void ClickRay()
    {

        //������ ��ġ,������ �չ������� ������ Ray�� �����
        Ray ray = new Ray(trRight.position, trRight.forward);
        //������ġ
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layer)) //Ray�߻� �� ��򰡿� �ε����ٸ�
        {
            line.gameObject.SetActive(true);
            line.SetPosition(0, trRight.position);
            line.SetPosition(1, hit.point);


            //if(OVRInput.GetDown(OVRInput.Button.Two))
            if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                print(hit.transform.name);
                line.transform.parent = trRight;

                //Button btn = hit.transform.GetComponent<Button>();
                //if (btn != null)
                //{
                //    btn.onClick.Invoke();
                //}

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
                else
                {
                    line.gameObject.SetActive(false);
                }
            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                line.gameObject.SetActive(false);
                line.transform.parent = null;
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
}

