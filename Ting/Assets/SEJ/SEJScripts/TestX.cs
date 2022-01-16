using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//잡고,놓고,쏘고,던지고,움직이는 것 (ThrowHockeyBall,ThrowDart,GunControl합치기)
//레이 쏘는 것들만 정리해주는 플레이어의 스크립트로 쓴다


//점수를 주고받고, 원위치 정렬은 각자 테이블이나 존에서 지정해주기**
public class TestX : MonoBehaviour
{
    public static TestX test;
    private void Awake()
    {
        if(test==null)
        {
            test = this;
        }
    }

    //양손 손위치, 라인
    public Transform trRight;
    public Transform trLeft;
    public LineRenderer line;

    public RaycastHit hit;
    public LayerMask layer; //레이어 선택해서 쓰기

    public bool isGrip; //잡았다
    Transform grabObj; //잡은 물체를 담아줄 위치


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
    void Start()
    {

    }

    void Update()
    {
       
      
        if(isGrip == false)
        {
            ClickRay();
        }
        else if(isGrip == true)
        {
        

            ReleaseObject(trRight);
            line.gameObject.SetActive(false);
        }

    }

    public void ClickRay() //레이쏜다
    {
        //오른손 위치,오른손 앞방향으로 나가는 Ray를 만든다
        Ray ray_R = new Ray(trRight.position, trRight.forward);
        Ray ray_L = new Ray(trLeft.position, trLeft.forward);


        ////맞은위치
        int UilayerMask = 1 << LayerMask.NameToLayer("UI");
        //int GriplayerMask = 1 << LayerMask.NameToLayer("gripObjectLayer");

        //ui클릭
        if (Physics.Raycast(ray_R, out hit, 100, layer)) //Ray발사 후 어딘가에 부딪힌다면
        {

            LineDraw(trRight.position);
            GripObject(trRight);
        }
        else if (Physics.Raycast(ray_L, out hit, 100, layer))
        {
            LineDraw(trLeft.position);
            GripObject(trLeft);
        }

        ////물체 잡기
        //else if (Physics.Raycast(ray_R, out hit, 100, GriplayerMask))
        //{
        //    LineDraw(trRight.position);
        //    GripObject(trRight);
        //}
        //else if (Physics.Raycast(ray_L, out hit, 100, GriplayerMask))
        //{
        //    //LineDraw(trLeft.position);
        //    //GripObject(trLeft);
        //}
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
            //line.enabled = true;
            line.enabled = false;
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
    } //레이에서 나오는 라인

    public void GripObject(Transform Pos) //물체를 잡는다 
    {
        print("hit name:" + hit.transform.name); //레이가 닿은 물체


        if (isAirHokey) //에어하키존이라면
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                print("에어하키 잡았다" + grabObj);
                hit.transform.parent = trRight;
                hit.transform.position = trRight.position;
                grabObj = hit.transform;
                isGrip = true;
                ////손 위치에 맞게 회전시켜주기 -> 손에 잡는 포지션 만들고 부모로 지정해주기
                grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  
               
                print(grabObj.transform.rotation);
                //hit.transform.localPosition = new Vector3(0, -0.05f, 0);
                //hit.transform.eulerAngles = new Vector3(0, 0, 0);

            }
        }
        else if (isDart)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {

                GameObject dartpin = hit.transform.gameObject;
                dart = dartpin.GetComponent<SEJDarts>();
                dartpin.transform.SetParent(trRight);
                dartpin.transform.localPosition = new Vector3(0, 0, 0);
                dartpin.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                if (dartpin.transform.Find("Dart4B") == null)
                {
                    print("없어");
                }
                else
                {
                    print("있어");
                    dartpin.transform.Find("Dart4B").GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                
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
                //grabObj.transform.rotation = trRight.rotation;
                isGrip = true;
                
                grabObj.GetComponent<Rigidbody>().useGravity = false;
                grabObj.transform.localPosition = new Vector3(0, 0, 0);
                grabObj.transform.localRotation = Quaternion.Euler(new Vector3(0, -90f, 0));
                //grabObj.transform.rotation = Quaternion.Euler(new Vector3(196.343f, 90, 180));

                //hit.transform.Find("Gun").GetComponent<BulletFactory>().isGunGrip = true;
                transform.GetComponentInChildren<BulletFactory>().isGunGrip = true;
                print("총 잡았다");

              
            }
        }

           
        }
    public void ReleaseObject(Transform Pos)
    {
        if (isAirHokey) //에어하키존이라면
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                if (grabObj != null)
                {
                    print("놓는다" + grabObj);

                    isGrip = false;

                    //grabObj.GetComponent<Rigidbody>().useGravity = true;
                    grabObj.transform.parent = null;

                    if (grabObj.name == "Stick")
                    {
                        grabObj.transform.position = AirHockeyTableManager.hockeyTableM.stickPos.position;
                        grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        grabObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        grabObj.GetComponent<Rigidbody>().freezeRotation = true;
                        //grabObj.transform.position = GetComponent<AirHockeyTableManager>().stickPos.position; //내가 잡은 스틱이 Stick1 일 때 놓았을 때 이 위치로
                        grabObj.GetComponent<Rigidbody>().useGravity = false;
                    }

                    else if (grabObj.name == "Stick2")
                    {
                        grabObj.transform.position = AirHockeyTableManager.hockeyTableM.stick2Pos.position;
                        grabObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        grabObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        grabObj.GetComponent<Rigidbody>().freezeRotation = true;
                        //grabObj.transform.position = GetComponent<AirHockeyTableManager>().stick2Pos.position; //내가 잡은 스틱이 Stick2 일 때 놓았을 때 이 위치로
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

                //오래 가지고 있을수록(=트리거를 누르고 있을수록) 던지는 힘이 커진다.
                forceWithTime += forceMax * Time.deltaTime * forceAdg;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {

                
                if (dart != null) //다트가 손에 있는 상태라면 
                {

                    isGrip = false;

                    dart.GetComponent<Collider>().enabled = false;
                    // 던지는 힘의 크기를 제한하고싶다.
                    forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
                    //다트가 손을 떠나가도록 부모의 shootPos를 없앤다.
                    dart.gameObject.transform.parent = null;
                    //다트를 던지는 함수 실행
                    dart.Shooting(forceWithTime);
                    //손에서 떠난 다트
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
                    grabObj.GetComponent<Rigidbody>().useGravity = true; // 총에 중력생겨서 떨어지도록
                    //StartCoroutine(respwanGun()); //총 원위치로 리스폰하
                }
            }
        }

    }

    public void Shoot() //총 Advanced Events에 들어갈 함수
    {
        //print("총알 발사");
        //if (0 < MaxCount)
        //{
        //    print("총알 발사");
        //    SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_SHOOT_GUN);
        //    GameObject Bullet = Instantiate(bulletFactory);
        //    Bullet.transform.position = gunHole.transform.position;
        //    Bullet.transform.rotation = gunHole.transform.rotation;
        //    Destroy(Bullet, 5);
        //    MaxCount--;
        //}
        //else
        //{
        //    return;
        //}

        //if (MaxCount <= 0)
        //{
        //    print("총알없음");
        //    MaxCount = 0;
        //}
        //string countS = MaxCount.ToString();
        //bulletText.text = countS;
    }
    //IEnumerator respwanGun()
    //{
    //    yield return new WaitForSeconds(1f);
    //    grabObj.transform.position = point.position;
    //    grabObj.GetComponent<Rigidbody>().useGravity = false;
    //    grabObj.transform.rotation = Quaternion.Euler(new Vector3(180, 180, 90));
    //}

    #region 다트게임용 변수들

    public bool isTouch; //다트가 닿았는지 확인용
    float forceWithTime; // 오래 잡고 있을수록 힘이 커진다
    public float forceAdg = 2; //힘조절
    public float forceMax = 50; //최대 힘
    public SEJDarts dart;
    #endregion

    #region 총게임용 변수들
    //public bool isGrip;
    public int MaxCount;
    public GameObject bulletFactory;
    public GameObject gunHole;
    public Text bulletText;
    public Transform Tracker;
    //public Transform point; //총이 돌아갈 위치
    #endregion


}
