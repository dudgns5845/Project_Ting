using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerController_SEJ : MonoBehaviour
{
    //지금 플레이어의 상태 -- 어떤 게임을 하는중인지
    //그 영역에 들어가면 true로 만들어준다
    //나머지는 false
    public bool isAirHokey = false;
    public bool isDart = false;
    public bool isGun = false;

    //다트가 닿았는지 확인용
    public bool isTouch;



    public LayerMask gripObjectLayer;

    public LineRenderer line;

    //물체 던지는 힘
    public float throwPower;

    public GameObject grabObject;

   
    private bool tryGrab;
    public float grabRadius = 0.5f;
    //양손 손위치
    public Transform trRight;
    public Transform trLeft;
    //잡은 물체를 담을 위치
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
        //오른손 위치,오른손 앞방향으로 나가는 Ray를 만든다
        Ray ray_R = new Ray(trRight.position, trRight.forward);
        Ray ray_L = new Ray(trLeft.position, trLeft.forward);

        //맞은위치
        int UilayerMask = 1 << LayerMask.NameToLayer("UI");
        int GriplayerMask = 1 << LayerMask.NameToLayer("gripObjectLayer");
   


        //ui클릭
        if (Physics.Raycast(ray_R, out hit, 100, UilayerMask)) //Ray발사 후 어딘가에 부딪힌다면
        {
            LineDraw(trRight.position);


        }
        else if (Physics.Raycast(ray_L, out hit, 100, UilayerMask))
        {
            LineDraw(trLeft.position);
        }

        //물체 잡기
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

        print(hit.collider.name); //맞는 콜라이더이름

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
                GetComponent<ThrowHockeyBall>().enabled = true;
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


        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            line.gameObject.SetActive(false);
            line.transform.parent = null;
            line.enabled = true;
        }

        #region outline
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
            print("물체 잡기");
            //hit.transform.gameObject.layer = 1 << LayerMask.NameToLayer("Hand");
            //print("내이름은 "+hit.transform.name);
            //hit.transform.SetParent(VRHand);


            //부모(손)의 리지드바디가 있고 자식개체(스틱)에 리지드바디가 없어서 잡은 물체가 자꾸 손으로 바뀜
            //가리키는 물체는 스틱이 맞으니까 collider.transform을 넣어주면 됨
            hit.collider.transform.parent = VRHand;
            grabObj = hit.collider.transform;

            print("호출");
            isGrip = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if(grabObj !=null)
            {
                Throw();
                print("물체 놓치기" + hit.collider.name);
                //hit.transform.SetParent(null);
                grabObj.parent = null;
                grabObj = null;

                isGrip = false;
            }
        }

        //else return;
    }

    //오브젝트 잡기 - 충돌해서 이름확인하고 손으로 가져오기
    //대상 - 다트, 스틱, 총
    //먼저 물건을 잡는다
 
    Rigidbody SetKinematic(bool enable)  //반복해서 쓸 리지드바디 켜고끄기 함수
    {
        //grabObj한테  Rigidbody컴포넌트를 가져온다
        Rigidbody rb = grabObj.GetComponent<Rigidbody>();
        if(rb != null)
        {
            //가져온 컴포넌트 물리력 제거
            rb.isKinematic = enable;
        }
        return rb;
    }
   

    public void Throw()
    {
        //던진 힘
        Vector3 dir = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //던진 돌림힘
        Vector3 angularDir = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);

        Rigidbody rb = SetKinematic(false);

       if(rb != null) //스틱에는 리지드바디가 없어서 안놔지니까
        {
            rb.velocity = dir * throwPower;
            //가져온 Rigidbody 의 angularVelocity 값에 angularDir 을 넣자
            rb.angularVelocity = angularDir;
        }
    }

 


}
