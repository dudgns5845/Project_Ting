using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HockeyBall : MonoBehaviour
{
    public static HockeyBall instance;

    public GameObject ballFactory;
   public bool isLeftGoal; //���ʿ� �� �� 
   public bool isRightGoal; //�����ʿ� �� ��
    public Transform leftBallPos;  //�����ʿ� �� ���� �� ���� pos���� ������
    public Transform rightBallPos;  //���ʿ� �� ���� �� ������ pos���� ������

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightGoal") //������ ��� = �����÷��̾� �¸�
        {
            isRightGoal = true;
            leftScore += 1;
            txtLeftScore.text = " " + leftScore;
            print("�����÷��̾�  1�� Get");
            this.gameObject.SetActive(false); //���� ���������

        }
        if (other.gameObject.name == "LeftGoal")
        {
            isLeftGoal = true;
            rightScore += 1;
            txtRightScore.text = " " + rightScore;
            print("�����÷��̾�  1�� Get");
            this.gameObject.SetActive(false); //���� ���������
        }
    }


   public void MakeRightBall() //������ ������ 
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = rightBallPos.position;
        ballObj.SetActive(true);

        //��� ���� �����Ǹ� �ȵǴϱ�
        isRightGoal = false;
    }
    public void MakeLeftBall() //���� ������
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = leftBallPos.position;
        ballObj.SetActive(true);

        //��� ���� �����Ǹ� �ȵǴϱ�
        isLeftGoal = false;
    }    


    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    throw new System.NotImplementedException();
    //}
}
