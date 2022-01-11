using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerController_SEJ : MonoBehaviour
{
    //���� �÷��̾��� ���� -- � ������ �ϴ�������
    //�� ������ ���� true�� ������ش�
    //�������� false
    public bool isAirHokey = false;
    public bool isDart = false;
    public bool isGun = false;

    //��Ʈ�� ��Ҵ��� Ȯ�ο�
    public bool isTouch;



    public LayerMask gripObjectLayer;

    public LineRenderer line;

    //��ü ������ ��
    public float throwPower;

    public GameObject grabObject;

   
    private bool tryGrab;
    public float grabRadius = 0.5f;
    //��� ����ġ
    public Transform trRight;
    public Transform trLeft;
    //���� ��ü�� ���� ��ġ
    Transform grabObj;


    private void Start()
    {
    
    }


    private void Update()
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
   


        //uiŬ��
        if (Physics.Raycast(ray_R, out hit, 100, UilayerMask)) //Ray�߻� �� ��򰡿� �ε����ٸ�
        {
            LineDraw(trRight.position);


        }
        else if (Physics.Raycast(ray_L, out hit, 100, UilayerMask))
        {
            LineDraw(trLeft.position);
        }

        //��ü ���
        else if (Physics.Raycast(ray_R, out hit, 100, GriplayerMask))
        {
            LineDraw(trRight.position);
            GripObject(trRight);

        }
        else if (Physics.Raycast(ray_L, out hit, 100, GriplayerMask))
        {

           // LineDraw(trLeft.position);
           // GripObject(trLeft);
        }
        else
        {
            //line.enabled = false;
          //  line.gameObject.SetActive(false);
        }
    }


    void LineDraw(Vector3 Pos)
    {
        line.gameObject.SetActive(true);
        line.SetPosition(0, Pos);
        line.SetPosition(1, hit.point);

        print(hit.collider.name); //�´� �ݶ��̴��̸�

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
            else if (hit.transform.name.Contains("AirHockeyBtn")) //��Ű
            {
                AirHockeyTableManager.hockeyTableM.OnClickHockeyBtn();
                //��Ű ��ũ��Ʈ �ѱ�
                GetComponent<ThrowHockeyBall>().enabled = true;
            }
            else if (hit.transform.name.Contains("AirHockeyOutBtn")) //��Ű
            {
                AirHockeyTableManager.hockeyTableM.OnClickExitHockeyBtn();
                GetComponent<ThrowHockeyBall>().enabled = false;
            }
            else if (hit.transform.name.Contains("StartDartBtn")) //��Ʈ
            {
                SEJDartBoard.db.OnStartDart();
            }
            else if (hit.transform.name.Contains("ExitDartBtn")) //��Ʈ
            {
                SEJDartBoard.db.OnExitDart();
            }
            else if (hit.transform.name.Contains("StartGunBtn")) //��
            {
                GunTableManager.gunTableM.OnClickStartGun();
            }
            else if (hit.transform.name.Contains("ExitGunBtn")) //��
            {
                GunTableManager.gunTableM.OnClickExitGun();
            }


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

    public Transform VRHand;
    public Transform VLHand;
    public bool isGrip = false;
    public void GripObject(Transform Pos)
    {
        print("hit name:" + hit.collider.name);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            print("��ü ���");
            //hit.transform.gameObject.layer = 1 << LayerMask.NameToLayer("Hand");
            //print("���̸��� "+hit.transform.name);
            //hit.transform.SetParent(VRHand);


            //�θ�(��)�� ������ٵ� �ְ� �ڽİ�ü(��ƽ)�� ������ٵ� ��� ���� ��ü�� �ڲ� ������ �ٲ�
            //����Ű�� ��ü�� ��ƽ�� �����ϱ� collider.transform�� �־��ָ� ��
            hit.collider.transform.parent = VRHand;
            grabObj = hit.collider.transform;

            print("ȣ��");
            isGrip = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if(grabObj !=null)
            {
                Throw();
                print("��ü ��ġ��" + hit.collider.name);
                //hit.transform.SetParent(null);
                grabObj.parent = null;
                grabObj = null;

                isGrip = false;
            }
        }

        //else return;
    }

    //������Ʈ ��� - �浹�ؼ� �̸�Ȯ���ϰ� ������ ��������
    //��� - ��Ʈ, ��ƽ, ��
    //���� ������ ��´�
 
    Rigidbody SetKinematic(bool enable)  //�ݺ��ؼ� �� ������ٵ� �Ѱ���� �Լ�
    {
        //grabObj����  Rigidbody������Ʈ�� �����´�
        Rigidbody rb = grabObj.GetComponent<Rigidbody>();
        if(rb != null)
        {
            //������ ������Ʈ ������ ����
            rb.isKinematic = enable;
        }
        return rb;
    }
   

    public void Throw()
    {
        //���� ��
        Vector3 dir = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //���� ������
        Vector3 angularDir = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);

        Rigidbody rb = SetKinematic(false);

       if(rb != null) //��ƽ���� ������ٵ� ��� �ȳ����ϱ�
        {
            rb.velocity = dir * throwPower;
            //������ Rigidbody �� angularVelocity ���� angularDir �� ����
            rb.angularVelocity = angularDir;
        }
    }

 


}
