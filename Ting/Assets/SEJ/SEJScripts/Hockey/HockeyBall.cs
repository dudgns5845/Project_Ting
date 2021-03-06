using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HockeyBall : MonoBehaviour
{
    public static HockeyBall instance;

    //public GameObject ballFactory;
    public bool isLeftGoal; //왼쪽에 골 들어감 
    public bool isRightGoal; //오른쪽에 골 들어감
    public Transform leftBallPos;  //오른쪽에 골 들어갔을 때 왼쪽 pos에서 리스폰
    public Transform rightBallPos;  //왼쪽에 골 들어갔을 때 오른쪽 pos에서 리스폰
    Rigidbody rigidbody;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
 
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //rigidbody.AddForce(dir, ForceMode.Impulse);
        inDirection = rigidbody.velocity;
        //inDirection = rigidbody.transform.position - transform.position;
        rigidbody.AddForceAtPosition(inDirection.normalized, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
    }

    Vector3 inDirection;
    // 공이 받는 힘 조절
    public float kAdjustForce = 5;
    bool isHit=false;
    public void OnCollisionEnter(Collision collision)
    {
        //스틱에 닿으면
        if (collision.gameObject.layer == LayerMask.NameToLayer("gripObjectLayer")) 
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Stick")) 
        {   //컨트롤러로 치는 힘을 리지드바디의 속도로 입사각으로 넣는다
            print("충돌" + collision.rigidbody.velocity);
            print("충돌컨트롤러" + OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch));
            isHit = true;
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * kAdjustForce;
            SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_HIT_HOCKEY); //사운드

        }
        else
        {   //컨트롤러로 받은 힘을 반사각으로 뱉는다
            isHit = false;
            rigidbody.velocity = Vector3.Reflect(inDirection, collision.contacts[0].normal);

        }

    }

  
   public void OnTriggerEnter(Collider other)
    {
        print("리스폰 호출");
        if (other.gameObject.name == "RightGoal") //오른쪽 골대 = 왼쪽플레이어 승리
        {
            SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_GOAL_HOCKEY);
            AirHockeyTableManager.hockeyTableM.MakeLeftBall();
            Destroy(gameObject);
        }
        if (other.gameObject.name == "LeftGoal")
        {
            SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_GOAL_HOCKEY);
            AirHockeyTableManager.hockeyTableM.MakeRightBall();
            Destroy(gameObject);
        }
    }

}
