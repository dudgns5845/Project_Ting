using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerController_SEJ : MonoBehaviour
{
    //양손 손위치, 라인
    public Transform trRight;
    public Transform trLeft;
    public LineRenderer line;

  
    //잡은 물체를 담을 위치
    Transform grabObj;

    public LayerMask gripObjectLayer;

    //물체 던지는 힘
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
            line.gameObject.SetActive(false);
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

    public bool isGrip = false;

    #region 다트게임용 변수들
    
    public bool isTouch; //다트가 닿았는지 확인용
    float forceWithTime; // 오래 잡고 있을수록 힘이 커진다
    public float forceAdg = 2; //힘조절
    public float forceMax = 50; //최대 힘
    SEJDarts dart;
    public Transform rayOrigin;
    #endregion

    #region 하키게임용 변수들
    public Transform stickPos;
    public Transform stick2Pos;

    #endregion
    #region 총게임용 변수들
    //public bool isGrip;
    public int MaxCount;
    public GameObject bulletFactory;
    public GameObject gunHole;
    public Text bulletText;
    public Transform Tracker;
    public Transform point; //총이 돌아갈 위치
    #endregion
    public void GripObject(Transform Pos)
    {
        print("hit name:" + hit.collider.name);

        if (isAirHokey)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                print("물체 잡기");

                //hit.transform.gameObject.layer = 1 << LayerMask.NameToLayer("Stick");
                hit.collider.transform.parent = trRight;
                grabObj = hit.collider.transform;
                print("호출");
                isGrip = true;
                //print("내이름은 "+hit.transform.name);
              

                //오토핸드 부모(손)의 리지드바디가 있고 자식개체(스틱)에 리지드바디가 없어서 잡은 물체가 자꾸 손으로 바뀜
                //가리키는 물체는 스틱이 맞으니까 collider.transform을 넣어주면 됨


                hit.collider.transform.localPosition = new Vector3(0, -0.05f, 0);
                hit.collider.transform.eulerAngles = new Vector3(0, 0, 0);
                //로테이션 0,0,0  포지션 0,-0.12,0.02


            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                //if (grabObj != null)
                //{
                //    Throw();
                //    print("물체 놓치기" + hit.collider.name);
                //    //hit.transform.SetParent(null);
                //    grabObj.parent = null;
                //    grabObj = null;
                //    //SetKinematic(false);
                //    isGrip = false;
                //}
                //스틱 놓았을 때 원래 위치로
                if (grabObj.name == "Stick")
                    grabObj.transform.position = stickPos.position; //내가 잡은 스틱이 Stick1 일 때 놓았을 때 이 위치로

                else if (grabObj.name == "Stick2")
                    grabObj.transform.position = stick2Pos.position; //내가 잡은 스틱이 Stick2 일 때 놓았을 때 이 위치로
            }
        }
        else if (isDart)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                hit.collider.transform.parent = trRight;
                grabObj = hit.collider.transform;

                print("호출");
                isGrip = true;

            }
            
            if (grabObj != null)
            {
                //오래 가지고 있을수록(=트리거를 누르고 있을수록) 던지는 힘이 커진다.
                forceWithTime += forceMax * Time.deltaTime * forceAdg;
            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                if (grabObj != null) //다트가 손에 있는 상태라면 
                {
                    // 던지는 힘의 크기를 제한하고싶다.
                    forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
                    //다트가 손을 떠나가도록 부모의 shootPos를 없앤다.
                    dart.gameObject.transform.parent = null;
                    //다트를 던지는 함수 실행
                    dart.Shooting(forceWithTime);
                    //손에서 떠난 다트
                    dart = null;
                }
                //if (grabObj != null)
                //{
                //    Throw();
                //    print("물체 놓치기" + hit.collider.name);
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
                print("호출");
                isGrip = true;
            }

            else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Shoot(); // 총알 발사
            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {

                    grabObj.GetComponent<Rigidbody>().useGravity = true; // 총에 중력생겨서 떨어지도록
                    StartCoroutine(respwanGun()); //총 원위치로 리스폰하기
                
                //if (grabObj != null)
                //{
                //    Throw();
                //    print("물체 놓치기" + hit.collider.name);
                //    //hit.transform.SetParent(null);
                //    grabObj.parent = null;
                //    grabObj = null;
                //    SetKinematic(false); //중력켜야하니까
                //    isGrip = false;
                //}
            }
        }

        //else return;
    }


  

    //오브젝트 잡기 - 충돌해서 이름확인하고 손으로 가져오기
    //대상 - 다트, 스틱, 총
    //먼저 물건을 잡는다

    //Rigidbody SetKinematic(bool enable)  //반복해서 쓸 리지드바디 켜고끄기 함수
    //{
    //    //grabObj한테  Rigidbody컴포넌트를 가져온다
    //    Rigidbody rb = grabObj.GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        //가져온 컴포넌트 물리력 제거
    //        rb.isKinematic = enable;
    //    }
    //    return rb;
    //}

    public void Shoot() //총 Advanced Events에 들어갈 함수
    {
        print("총알 발사");
        if (0 < MaxCount)
        {
            print("총알 발사");
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
            print("총알없음");
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
        //던진 힘
        Vector3 dir = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //던진 돌림힘
        Vector3 angularDir = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);


        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        /*SetKinematic(false);*/

        if (rb != null) //스틱에는 리지드바디가 없어서 안놔지니까
        {
            rb.velocity = dir * throwPower;
            //가져온 Rigidbody 의 angularVelocity 값에 angularDir 을 넣자
            rb.angularVelocity = angularDir;
        }
    }

    #region 현재 어느 존에 있는지

    //지금 플레이어의 상태 -- 어떤 게임을 하는중인지
    //그 영역에 들어가면 true로 만들어준다
    //나머지는 false
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
