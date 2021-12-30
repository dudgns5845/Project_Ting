using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HockeyBall : MonoBehaviour
{
    public static HockeyBall instance;

    public GameObject ballFactory;
   public bool isLeftGoal; //왼쪽에 골 들어감 
   public bool isRightGoal; //오른쪽에 골 들어감
    public Transform leftBallPos;  //오른쪽에 골 들어갔을 때 왼쪽 pos에서 리스폰
    public Transform rightBallPos;  //왼쪽에 골 들어갔을 때 오른쪽 pos에서 리스폰

    public TextMeshProUGUI txtLeftScore;
    int leftScore;
    public TextMeshProUGUI txtRightScore;
    int rightScore;

    Rigidbody rigidbody;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public HockeyBall(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        txtLeftScore.text = " " + leftScore;
        txtRightScore.text = " " + rightScore;
    }

    void Update()
    {
        //rigidbody.AddForce(dir, ForceMode.Impulse);
        inDirection = rigidbody.velocity;
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);

        if (isRightGoal == true)
        {
            MakeRightBall();
        }
        if (isLeftGoal == true)
        {
            MakeLeftBall();
        }

    }

    Vector3 inDirection;
    // 공이 받는 힘 조절
    public float kAdjustForce = 5;
    

    public void OnCollisionEnter(Collision collision)
    {
        //스틱에 닿으면
        if (collision.gameObject.layer == LayerMask.NameToLayer("Stick"))
        {   //컨트롤러로 치는 힘을 리지드바디의 속도로 입사각으로 넣는다
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * kAdjustForce;
        }
        else
        {   //컨트롤러로 받은 힘을 반사각으로 뱉는다
            rigidbody.velocity = Vector3.Reflect(inDirection, collision.contacts[0].normal);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightGoal") //오른쪽 골대 = 왼쪽플레이어 승리
        {
            isRightGoal = true;
            leftScore += 1;
            txtLeftScore.text = " " + leftScore;
            print("왼쪽플레이어  1점 Get");
            this.gameObject.SetActive(false); //공이 사라져야함

        }
        if (other.gameObject.name == "LeftGoal")
        {
            isLeftGoal = true;
            rightScore += 1;
            txtRightScore.text = " " + rightScore;
            print("왼쪽플레이어  1점 Get");
            this.gameObject.SetActive(false); //공이 사라져야함
        }
    }


   public void MakeRightBall() //오른쪽 리스폰 
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = rightBallPos.position;
        ballObj.SetActive(true);

        //계속 공이 생성되면 안되니까
        isRightGoal = false;
    }
    public void MakeLeftBall() //왼쪽 리스폰
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = leftBallPos.position;
        ballObj.SetActive(true);

        //계속 공이 생성되면 안되니까
        isLeftGoal = false;
    }    


    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    throw new System.NotImplementedException();
    //}
}
