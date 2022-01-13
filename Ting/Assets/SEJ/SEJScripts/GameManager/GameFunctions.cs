using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFunctions : MonoBehaviour
{
    //��� ������ٵ� �ʿ��� (�̹� �� ����)
    Rigidbody rb;

    #region ��Ű���ӿ� ������
    public Transform stickPos;
    public Transform stick2Pos;

    #endregion
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    public void ReleaseStick() //������Ű
    {
        //��ƽ ������ �� ���� ��ġ��
        if (gameObject.name == "Stick")
            gameObject.transform.position = stickPos.position; //���� ���� ��ƽ�� Stick1 �� �� ������ �� �� ��ġ��

        else if (gameObject.name == "Stick2")
            gameObject.transform.position = stick2Pos.position; //���� ���� ��ƽ�� Stick2 �� �� ������ �� �� ��ġ��
    }


    #region ��Ʈ���ӿ� ������
    public bool isTouch;
    float forceWithTime; // ���� ��� �������� ���� Ŀ����
    public float forceAdg = 2; //������
    public float forceMax = 50; //�ִ� ��
    SEJDarts dart;
    #endregion
    public void GripDart() //��� �ִ� ���� ���� ũ�� ����
    {
        if (gameObject.CompareTag("Dart"))
        {
            print("��Ʈ ��Ҵ�");

            //gameObject.GetComponentInChildren<MeshRenderer>().transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
            //gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
            if(gameObject!=null)
            {
                print("��Ʈ��������");
                forceWithTime += forceMax * Time.deltaTime * forceAdg;
            }
        }
    }
    public Transform rayOrigin;
    public void ThrowDart() //release�� �� ��Ʈ ���ư�����
    {
        print("��Ʈ ������");
        if (gameObject != null)
        {
            print(gameObject.name);

            forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
            gameObject.GetComponent<SEJDarts>().Shooting(forceWithTime);


        }
        if(gameObject ==null)
        {
            Ray ray = new Ray(rayOrigin.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                SEJBoardPiece boardPiece = hitInfo.collider.GetComponent<SEJBoardPiece>();
                if (boardPiece != null)
                {
                    print(boardPiece.name);
                    isTouch = true;
                    SetMyChildren(boardPiece.transform);

                    transform.position = hitInfo.point + transform.forward * 0.25f;

                    // ��Ʈ�� ���������� �ε������� ���������� ��ü�� ���忡�� ���������� �Ѱ��ְ�ʹ�.
                    boardPiece.AddScorePlz(gameObject.GetComponent<SEJDarts>());
                }
            }
        }
      

    }
    public void SetMyChildren(Transform parent)
    {
        
        isTouch = true;
        rb.useGravity = false; //�߷�����
        rb.isKinematic = true; //ȸ������
        // �浹ü�� ����
        // �� �θ� = ��
    }

    #region �Ѱ��ӿ� ������
    public bool isGrip;
    public int MaxCount;
    public GameObject bulletFactory;
    public GameObject gunHole;
    public Text bulletText;
    public Transform Tracker;
    public Transform point; //���� ���ư� ��ġ
    #endregion

    public void Shoot() //�� Advanced Events�� �� �Լ�
    {
        print("�Ѿ� �߻�");
        if (0 < MaxCount)
        {
            print("�Ѿ� �߻�");
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
    public void GripGun()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(196.343f, 90, 180));
    }
    public void ReleaseGun() //�� ���� �� ���ڸ���
    {
        if (gameObject.name == "Gun")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(respwanGun());
        }
    }
    IEnumerator respwanGun()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = point.position;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(180, 180, 90));
    }
}
