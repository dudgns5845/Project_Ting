using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HockeyBall : MonoBehaviour
{
    public static HockeyBall instance;

    //public GameObject ballFactory;
    public bool isLeftGoal; //���ʿ� �� �� 
    public bool isRightGoal; //�����ʿ� �� ��
    public Transform leftBallPos;  //�����ʿ� �� ���� �� ���� pos���� ������
    public Transform rightBallPos;  //���ʿ� �� ���� �� ������ pos���� ������
    Rigidbody rigidbody;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    //public HockeyBall(Rigidbody rigidbody)
    //{
    //    rigidbody = rigidbody;
    //}

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
    // ���� �޴� �� ����
    public float kAdjustForce = 5;

    public void OnCollisionEnter(Collision collision)
    {
        //��ƽ�� ������
        if (collision.gameObject.layer == LayerMask.NameToLayer("Stick")) 
        {   //��Ʈ�ѷ��� ġ�� ���� ������ٵ��� �ӵ��� �Ի簢���� �ִ´�
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * kAdjustForce;
        }
        else
        {   //��Ʈ�ѷ��� ���� ���� �ݻ簢���� ��´�
            rigidbody.velocity = Vector3.Reflect(inDirection, collision.contacts[0].normal);
        }

    }

  
   public void OnTriggerEnter(Collider other)
    {
        print("������ ȣ��");
        if (other.gameObject.name == "RightGoal") //������ ��� = �����÷��̾� �¸�
        {
            AirHockeyTableManager.hockeyTableM.MakeLeftBall();
            Destroy(gameObject);
        }
        if (other.gameObject.name == "LeftGoal")
        {
            AirHockeyTableManager.hockeyTableM.MakeRightBall();
            Destroy(gameObject);
        }
    }


   //public void MakeRightBall() //������ ������ 
   // {
   //     GameObject ballObj = Instantiate(ballFactory);
   //     ballObj.transform.position = rightBallPos.position;
   //     ballObj.SetActive(true);
       

   //     //��� ���� �����Ǹ� �ȵǴϱ�
   //     isRightGoal = false;
   // }

   // public void MakeLeftBall() //���� ������
   // {
   //     GameObject ballObj = Instantiate(ballFactory);
   //     ballObj.transform.position = leftBallPos.position;
   //     ballObj.SetActive(true);

   //     //��� ���� �����Ǹ� �ȵǴϱ�
   //     isLeftGoal = false;
   // }    


    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    throw new System.NotImplementedException();
    //}
}
