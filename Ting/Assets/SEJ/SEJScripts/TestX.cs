using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���,����,���,������,�����̴� �� (ThrowHockeyBall,ThrowDart,GunControl��ġ��)
//���� ��� �͵鸸 �������ִ� �÷��̾��� ��ũ��Ʈ�� ����


//������ �ְ�ް�, ����ġ ������ ���� ���̺��̳� ������ �������ֱ�**
public class TestX : MonoBehaviour
{
    //��� ����ġ, ����
    public Transform trRight;
    public Transform trLeft;
    public LineRenderer line;

    public RaycastHit hit;
    public LayerMask layer; //���̾� �����ؼ� ����

    public bool isGrip; //��Ҵ�
    Transform grabObj; //���� ��ü�� ����� ��ġ


    #region ���� ��� ���� �ִ���
    //���� �÷��̾��� ���� -- � ������ �ϴ�������
    //�� ������ ���� true�� ������ش�
    //�������� false
    public bool isAirHokey = false;
    public bool isDart = false;
    public bool isGun = false;
    bool isClickRay = false;
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
    void Start()
    {

    }

    void Update()
    {
        ClickRay();
        ReleaseObject(trLeft);
    }

    public void ClickRay() //���̽��
    {
        //������ ��ġ,������ �չ������� ������ Ray�� �����
        Ray ray_R = new Ray(trRight.position, trRight.forward);
        Ray ray_L = new Ray(trLeft.position, trLeft.forward);


        //������ġ
        int UilayerMask = 1 << LayerMask.NameToLayer("UI");
        int GriplayerMask = 1 << LayerMask.NameToLayer("gripObjectLayer");

        //uiŬ��
        if (Physics.Raycast(ray_R, out hit, 100, layer)) //Ray�߻� �� ��򰡿� �ε����ٸ�
        {

            LineDraw(trRight.position);
            GripObject(trRight);
            ReleaseObject(trRight);
            isClickRay = true;
        }
        else if (Physics.Raycast(ray_L, out hit, 100, layer))
        {
            LineDraw(trLeft.position);
            GripObject(trLeft);
            isClickRay = true;
        }

        //��ü ���
        else if (Physics.Raycast(ray_R, out hit, 100, GriplayerMask))
        {
            LineDraw(trRight.position);
            GripObject(trRight);
            isClickRay = true;

        }
        else if (Physics.Raycast(ray_L, out hit, 100, GriplayerMask))
        {
            //LineDraw(trLeft.position);
            //GripObject(trLeft);
            //isClickRay = true;
        }
        else
        {
            line.gameObject.SetActive(false);
            isClickRay = false;
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
    } //���̿��� ������ ����

    public void GripObject(Transform Pos) //��ü�� ��´� 
    {
        print("hit name:" + hit.transform.name); //���̰� ���� ��ü


        if (isAirHokey) //������Ű���̶��
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                print("������Ű ��Ҵ�" + grabObj);
                hit.transform.parent = trRight;
                hit.transform.position = trRight.position;
                grabObj = hit.transform;
                isGrip = true;
                ////�� ��ġ�� �°� ȸ�������ֱ�
                grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //hit.transform.localPosition = new Vector3(0, -0.05f, 0);
                //hit.transform.eulerAngles = new Vector3(0, 0, 0);

                if (isGrip)
                {
                    isClickRay = false;
                }
            }



        }
        else if (isDart)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                hit.transform.parent = trRight;
                hit.transform.position = trRight.position;
                grabObj = hit.transform;
                grabObj.GetComponent<BoxCollider>().enabled = false;
                grabObj.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 0)); //����� �� 
                grabObj.GetComponent<Rigidbody>().useGravity = false; //����ִ� ���� �߷� ����
                dart = grabObj.GetComponent<SEJDarts>();  // ���� ��ü�� ��Ʈ��ũ��Ʈ �ٿ��ش�
                print("ȣ��");
                isGrip = true;

                if (grabObj != null)
                {
                    if(isGrip)
                    {
                        isClickRay = false;

                        //���� ������ ��������(=Ʈ���Ÿ� ������ ��������) ������ ���� Ŀ����.
                        forceWithTime += forceMax * Time.deltaTime * forceAdg;
                    }
                   
                }

            }

        }
        else if (isGun)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                hit.transform.parent = trRight;
                hit.transform.position = trRight.position;
                grabObj = hit.transform;
                hit.transform.rotation = trRight.rotation;

                //grabObj.transform.rotation = Quaternion.Euler(new Vector3(196.343f, 90, 180));
                print("ȣ��");
                isGrip = true;

            }
            else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Shoot(); // �Ѿ� �߻�
            }
        }

           
        }
    public void ReleaseObject(Transform Pos)
    {


        if (isAirHokey) //������Ű���̶��
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                if (grabObj != null)
                {
                    print("���´�" + grabObj);

                    isGrip = false;

                    //grabObj.GetComponent<Rigidbody>().useGravity = true;
                    grabObj.transform.parent = null;

                    if (grabObj.name == "Stick")
                    {
                        grabObj.transform.position = AirHockeyTableManager.hockeyTableM.stickPos.position;
                        grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        grabObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        grabObj.GetComponent<Rigidbody>().freezeRotation = true;
                        //grabObj.transform.position = GetComponent<AirHockeyTableManager>().stickPos.position; //���� ���� ��ƽ�� Stick1 �� �� ������ �� �� ��ġ��
                        grabObj.GetComponent<Rigidbody>().useGravity = false;
                    }

                    else if (grabObj.name == "Stick2")
                    {
                        grabObj.transform.position = AirHockeyTableManager.hockeyTableM.stick2Pos.position;
                        grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        grabObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        grabObj.GetComponent<Rigidbody>().freezeRotation = true;
                        //grabObj.transform.position = GetComponent<AirHockeyTableManager>().stick2Pos.position; //���� ���� ��ƽ�� Stick2 �� �� ������ �� �� ��ġ��
                        grabObj.GetComponent<Rigidbody>().useGravity = false;
                    }

                }

            }


        }
        else if (isDart)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                if (dart != null) //��Ʈ�� �տ� �ִ� ���¶�� 
                {

                    // ������ ���� ũ�⸦ �����ϰ�ʹ�.
                    forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
                    //��Ʈ�� ���� ���������� �θ��� shootPos�� ���ش�.
                    dart.gameObject.transform.parent = null;
                    //��Ʈ�� ������ �Լ� ����
                    dart.Shooting(forceWithTime);
                    //�տ��� ���� ��Ʈ
                    dart = null;
                    isGrip = false;
                }

            }

        }
        else if (isGun)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                if (grabObj != null)
                {
                    isGrip = false;
                    grabObj.GetComponent<Rigidbody>().useGravity = true; // �ѿ� �߷»��ܼ� ����������
                    StartCoroutine(respwanGun()); //�� ����ġ�� �������ϱ�
                }
            }
        }

    }

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

    #region ��Ʈ���ӿ� ������

    public bool isTouch; //��Ʈ�� ��Ҵ��� Ȯ�ο�
    float forceWithTime; // ���� ��� �������� ���� Ŀ����
    public float forceAdg = 2; //������
    public float forceMax = 50; //�ִ� ��
    SEJDarts dart;
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


}
