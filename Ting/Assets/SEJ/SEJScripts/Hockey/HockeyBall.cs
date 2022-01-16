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
    bool isHit=false;
    public void OnCollisionEnter(Collision collision)
    {
        //��ƽ�� ������
        if (collision.gameObject.layer == LayerMask.NameToLayer("gripObjectLayer")) 
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Stick")) 
        {   //��Ʈ�ѷ��� ġ�� ���� ������ٵ��� �ӵ��� �Ի簢���� �ִ´�
            print("�浹" + collision.rigidbody.velocity);
            print("�浹��Ʈ�ѷ�" + OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch));
            isHit = true;
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * kAdjustForce;
            SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_HIT_HOCKEY); //����

        }
        else
        {   //��Ʈ�ѷ��� ���� ���� �ݻ簢���� ��´�
            isHit = false;
            rigidbody.velocity = Vector3.Reflect(inDirection, collision.contacts[0].normal);

        }

    }

  
   public void OnTriggerEnter(Collider other)
    {
        print("������ ȣ��");
        if (other.gameObject.name == "RightGoal") //������ ��� = �����÷��̾� �¸�
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
