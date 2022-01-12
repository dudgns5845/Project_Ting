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
        if (isGrip == false) return; //안잡히면 호출안함
        else Shoot(); //잡히면 호출함
    }

    public void Shoot() //update에서 불러줌
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            print("총알 발사");
            if (0 < MaxCount)
            {
                print("총알 발사");
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
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if( other가 손일때)
    //    if (other.gameObject.layer == 1 << LayerMask.NameToLayer("Hand"))
    //    {
    //        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
    //        {
    //            print("총 잡음");
    //            isGrip = true;
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    print("총 놨음");
    //    isGrip = false;
    //}
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 1 << LayerMask.NameToLayer("Hand"))
        {
            print(collision.gameObject.name);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                print("총 잡음");
                isGrip = true;
            }
        }
    }
  

}
