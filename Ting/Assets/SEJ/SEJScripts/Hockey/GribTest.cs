using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GribTest : MonoBehaviour
{
    public bool isGrip = false;

    public int MaxCount;
    public GameObject bulletFactory;
    public GameObject gunHole;
    public Text bulletText;


    private void Update()
    {
        if (isGrip == false) return; //�������� ȣ�����
        else Shoot(); //������ ȣ����
    }

    public void Shoot() //update���� �ҷ���
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
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
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if( other�� ���϶�)
    //    if (other.gameObject.layer == 1 << LayerMask.NameToLayer("Hand"))
    //    {
    //        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
    //        {
    //            print("�� ����");
    //            isGrip = true;
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    print("�� ����");
    //    isGrip = false;
    //}
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 1 << LayerMask.NameToLayer("Hand"))
        {
            print(collision.gameObject.name);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                print("�� ����");
                isGrip = true;
            }
        }
    }
  

}
