using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���,����,���,������,�����̴� �� (ThrowHockeyBall,ThrowDart,GunControl��ġ��)
//���� ��� �͵鸸 �������ִ� �÷��̾��� ��ũ��Ʈ�� ����


//������ �ְ�ް�, ����ġ ������ ���� ���̺��̳� ������ �������ֱ�**
public class TestX : MonoBehaviour
{
    public static TestX test;
    private void Awake()
    {
        if (test == null)
        {
            test = this;
        }
    }

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

    void Update()
    {
        if (isGrip == false)
        {
            ClickRay();
        }
        else if (isGrip == true)
        {
            ReleaseObject(trRight);
            line.gameObject.SetActive(false);
        }
    }

    public void ClickRay() //���̽��
    {
        //������ ��ġ,������ �չ������� ������ Ray�� �����
        Ray ray_R = new Ray(trRight.position, trRight.forward);
        Ray ray_L = new Ray(trLeft.position, trLeft.forward);
       

        //uiŬ��
        if (Physics.Raycast(ray_R, out hit, 100, layer)) //Ray�߻� �� ��򰡿� �ε����ٸ�
        {
            LineDraw(trRight.position);
            GripObject(trRight);
        }
        else if (Physics.Raycast(ray_L, out hit, 100, layer))
        {
            LineDraw(trLeft.position);
            GripObject(trLeft);
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
            line.enabled = false;
        }

    } //���̿��� ������ ����

    public void GripObject(Transform Pos) //��ü�� ��´� 
    {
        print("hit name:" + hit.transform.name); //���̰� ���� ��ü


        if (isAirHokey) //������Ű���̶��
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                hit.transform.parent = trRight;
                hit.transform.position = trRight.position;
                grabObj = hit.transform;
                isGrip = true;
                ////�� ��ġ�� �°� ȸ�������ֱ� -> �տ� ��� ������ ����� �θ�� �������ֱ�
                grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //if (grabObj.transform.name == "Stick" || grabObj.transform.name == "Stick2")
                //{
                //    grabObj.transform.Find("Stick").GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
                //    grabObj.transform.Find("Stick").GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //}
                ////else if(grabObj.transform.name == "Stick2")
                //  {
                //      grabObj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //  }
                //grabObj.transform.Find("Stick").GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //grabObj.transform.Find("Stick2").GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
        else if (isDart)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {

                GameObject dartpin = hit.transform.gameObject;
                dart = dartpin.GetComponent<SEJDarts>();
                dartpin.transform.SetParent(trRight);
                //�տ� ��� ��ġ
                dartpin.transform.localPosition = new Vector3(-0.03f, 0.001f, 0.213f);
                //dartpin.transform.localPosition = new Vector3(0, 0, 0);
                dartpin.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                dartpin.transform.Find("Dart4B").GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0, 180, 0));

                isGrip = true;

            }

        }
        else if (isGun)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                hit.collider.transform.parent = trRight;
                hit.collider.transform.position = trRight.position;
                grabObj = hit.collider.transform;
                isGrip = true;

                grabObj.GetComponent<Rigidbody>().useGravity = false;
                grabObj.transform.localPosition = new Vector3(0, 0, 0);
                grabObj.transform.localRotation = Quaternion.Euler(new Vector3(0, -90f, 0));
                transform.GetComponentInChildren<BulletFactory>().isGunGrip = true;
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
                    isGrip = false;
                    grabObj.transform.parent = null;

                    if (grabObj.name == "Stick")
                    {
                        grabObj.transform.position = AirHockeyTableManager.hockeyTableM.stickPos.position;
                        grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        grabObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        grabObj.GetComponent<Rigidbody>().freezeRotation = true;
                        grabObj.GetComponent<Rigidbody>().useGravity = false;
                    }

                    else if (grabObj.name == "Stick2")
                    {
                        grabObj.transform.position = AirHockeyTableManager.hockeyTableM.stick2Pos.position;
                        grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        grabObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        grabObj.GetComponent<Rigidbody>().freezeRotation = true;
                        grabObj.GetComponent<Rigidbody>().useGravity = false;
                    }

                }

            }


        }
        else if (isDart)
        {
            if (dart != null)
            {
                isGrip = true;

                //���� ������ ��������(=Ʈ���Ÿ� ������ ��������) ������ ���� Ŀ����.
                forceWithTime += forceMax * Time.deltaTime * forceAdg;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {

               
                if (dart != null) //��Ʈ�� �տ� �ִ� ���¶�� 
                {

                    isGrip = false;
                    SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_THROW_DART);

                    dart.GetComponent<Collider>().enabled = false;
                    // ������ ���� ũ�⸦ �����ϰ�ʹ�.
                    forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
                    //��Ʈ�� ���� ���������� �θ��� shootPos�� ���ش�.
                    dart.gameObject.transform.parent = null;
                    //��Ʈ�� ������ �Լ� ����
                    dart.Shooting(forceWithTime);
                    //�տ��� ���� ��Ʈ
                    dart = null;

                }

            }

        }
        else if (isGun)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                if (grabObj != null)
                {
                    transform.GetComponentInChildren<BulletFactory>().isGunGrip = false;
                    isGrip = false;
                    grabObj.transform.parent = null;
                    grabObj.GetComponent<Rigidbody>().useGravity = true; // �ѿ� �߷»��ܼ� ����������
                }
            }
        }

    }

    #region ��Ʈ���ӿ� ������
    public bool isTouch; //��Ʈ�� ��Ҵ��� Ȯ�ο�
    float forceWithTime; // ���� ��� �������� ���� Ŀ����
    public float forceAdg = 2; //������
    public float forceMax = 50; //�ִ� ��
    public SEJDarts dart;
    #endregion
}
