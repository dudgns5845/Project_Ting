using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerController_SEJ : MonoBehaviour
{
    //��� ����ġ, ����
    public Transform trRight;
    public Transform trLeft;
    public LineRenderer line;

  
    //���� ��ü�� ���� ��ġ
    Transform grabObj;

    public LayerMask gripObjectLayer;

    //��ü ������ ��
    public float throwPower;
    public float grabRadius = 0.5f;

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
            line.gameObject.SetActive(false);
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
            //line.transform.parent = VRHand;

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
            else if (hit.transform.name.Contains("HockeyResetBtn"))
            {
                AirHockeyTableManager.hockeyTableM.OnClickHockeyReset();
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

    public bool isGrip = false;

    #region ��Ʈ���ӿ� ������
    
    public bool isTouch; //��Ʈ�� ��Ҵ��� Ȯ�ο�
    float forceWithTime; // ���� ��� �������� ���� Ŀ����
    public float forceAdg = 2; //������
    public float forceMax = 50; //�ִ� ��
    SEJDarts dart;
    public Transform rayOrigin;
    #endregion

    #region ��Ű���ӿ� ������
    public Transform stickPos;
    public Transform stick2Pos;

    #endregion
    #region �Ѱ��ӿ� ������
    //public bool isGrip;
    public int MaxCount;
    public GameObject bulletFactory;
    public GameObject gunHole;
    public Text bulletText;
    public Transform Tracker;
    public Transform point; //���� ���ư� ��ġ
    #endregion
    public void GripObject(Transform Pos)
    {
        print("hit name:" + hit.collider.name);

        if (isAirHokey)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                print("��ü ���");

                //hit.transform.gameObject.layer = 1 << LayerMask.NameToLayer("Stick");
                hit.collider.transform.parent = trRight;
                grabObj = hit.collider.transform;
                print("ȣ��");
                isGrip = true;
                //print("���̸��� "+hit.transform.name);
              

                //�����ڵ� �θ�(��)�� ������ٵ� �ְ� �ڽİ�ü(��ƽ)�� ������ٵ� ��� ���� ��ü�� �ڲ� ������ �ٲ�
                //����Ű�� ��ü�� ��ƽ�� �����ϱ� collider.transform�� �־��ָ� ��


                hit.collider.transform.localPosition = new Vector3(0, -0.05f, 0);
                hit.collider.transform.eulerAngles = new Vector3(0, 0, 0);
                //�����̼� 0,0,0  ������ 0,-0.12,0.02


            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                //if (grabObj != null)
                //{
                //    Throw();
                //    print("��ü ��ġ��" + hit.collider.name);
                //    //hit.transform.SetParent(null);
                //    grabObj.parent = null;
                //    grabObj = null;
                //    //SetKinematic(false);
                //    isGrip = false;
                //}
                //��ƽ ������ �� ���� ��ġ��
                if (grabObj.name == "Stick")
                    grabObj.transform.position = stickPos.position; //���� ���� ��ƽ�� Stick1 �� �� ������ �� �� ��ġ��

                else if (grabObj.name == "Stick2")
                    grabObj.transform.position = stick2Pos.position; //���� ���� ��ƽ�� Stick2 �� �� ������ �� �� ��ġ��
            }
        }
        else if (isDart)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                hit.collider.transform.parent = trRight;
                grabObj = hit.collider.transform;

                print("ȣ��");
                isGrip = true;

            }
            
            if (grabObj != null)
            {
                //���� ������ ��������(=Ʈ���Ÿ� ������ ��������) ������ ���� Ŀ����.
                forceWithTime += forceMax * Time.deltaTime * forceAdg;
            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                if (grabObj != null) //��Ʈ�� �տ� �ִ� ���¶�� 
                {
                    // ������ ���� ũ�⸦ �����ϰ�ʹ�.
                    forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
                    //��Ʈ�� ���� ���������� �θ��� shootPos�� ���ش�.
                    dart.gameObject.transform.parent = null;
                    //��Ʈ�� ������ �Լ� ����
                    dart.Shooting(forceWithTime);
                    //�տ��� ���� ��Ʈ
                    dart = null;
                }
                //if (grabObj != null)
                //{
                //    Throw();
                //    print("��ü ��ġ��" + hit.collider.name);
                //    //hit.transform.SetParent(null);
                //    grabObj.parent = null;
                //    grabObj = null;
                //    SetKinematic(false);
                //    isGrip = false;
                //}
            }
        }
        else if (isGun)
        {
            if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                hit.collider.transform.parent = trRight;
                grabObj = hit.collider.transform;
                hit.collider.transform.rotation = trRight.rotation;

                //grabObj.transform.rotation = Quaternion.Euler(new Vector3(196.343f, 90, 180));
                print("ȣ��");
                isGrip = true;
            }

            else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Shoot(); // �Ѿ� �߻�
            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {

                    grabObj.GetComponent<Rigidbody>().useGravity = true; // �ѿ� �߷»��ܼ� ����������
                    StartCoroutine(respwanGun()); //�� ����ġ�� �������ϱ�
                
                //if (grabObj != null)
                //{
                //    Throw();
                //    print("��ü ��ġ��" + hit.collider.name);
                //    //hit.transform.SetParent(null);
                //    grabObj.parent = null;
                //    grabObj = null;
                //    SetKinematic(false); //�߷��Ѿ��ϴϱ�
                //    isGrip = false;
                //}
            }
        }

        //else return;
    }


  

    //������Ʈ ��� - �浹�ؼ� �̸�Ȯ���ϰ� ������ ��������
    //��� - ��Ʈ, ��ƽ, ��
    //���� ������ ��´�

    //Rigidbody SetKinematic(bool enable)  //�ݺ��ؼ� �� ������ٵ� �Ѱ���� �Լ�
    //{
    //    //grabObj����  Rigidbody������Ʈ�� �����´�
    //    Rigidbody rb = grabObj.GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        //������ ������Ʈ ������ ����
    //        rb.isKinematic = enable;
    //    }
    //    return rb;
    //}

    public void Shoot() //�� Advanced Events�� �� �Լ�
    {
        print("�Ѿ� �߻�");
        if (0 < MaxCount)
        {
            print("�Ѿ� �߻�");
            SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_SHOOT_GUN);
            GameObject Bullet = Instantiate(bulletFactory);
            Bullet.transform.position = gunHole.transform.position;
            Bullet.transform.rotation = gunHole.transform.rotation;
            Destroy(Bullet, 5);
            MaxCount--;
        }
        else
        {
            return;
        }

        if (MaxCount <= 0)
        {
            print("�Ѿ˾���");
            MaxCount = 0;
        }
        string countS = MaxCount.ToString();
        bulletText.text = countS;
    }
    IEnumerator respwanGun()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = point.position;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(180, 180, 90));
    }
    public void Throw()
    {
        //���� ��
        Vector3 dir = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //���� ������
        Vector3 angularDir = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);


        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        /*SetKinematic(false);*/

        if (rb != null) //��ƽ���� ������ٵ� ��� �ȳ����ϱ�
        {
            rb.velocity = dir * throwPower;
            //������ Rigidbody �� angularVelocity ���� angularDir �� ����
            rb.angularVelocity = angularDir;
        }
    }

    #region ���� ��� ���� �ִ���

    //���� �÷��̾��� ���� -- � ������ �ϴ�������
    //�� ������ ���� true�� ������ش�
    //�������� false
    public bool isAirHokey = false;
    public bool isDart = false;
    public bool isGun = false;
    public void OnTriggerEnter(Collider other)
    {
        print(other.name);

        if (other.gameObject.name == "HockeyFloors")
        {
            isAirHokey = true;
            isDart = false;
            isGun = false;
        }
        else if (other.gameObject.name == "DartFloors")
        {
            isDart = true;
            isAirHokey = false;
            isGun = false;
        }
        else if (other.gameObject.name == "GunFloors")
        {
            isGun = true;
            isDart = false;
            isAirHokey = false;
        }

        else return;

    }
    #endregion




}
