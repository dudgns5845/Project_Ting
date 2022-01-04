using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//다트공장에서 다트를 생성한다
//트리거를 누른 상태로 뒤로 잡아 댕겼다가 놓으면 발사하고싶다

public class ThrowDart : MonoBehaviour
{
    //다트 공장
    public GameObject dartFactory;
    public Transform trRight;
    public Transform trLeft;

    SEJDarts dart; // dart스크립트 담은 변수 
    float forceWithTime; //오래 잡고 있을 수록 던지는 힘이 커진다
    public float forceAdg = 2; //힘조절
    public float forceMax = 50; //최대힘

    //public Vector3 throwPower;

    void Start()
    {
        //throwPos = Camera.main.transform;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            Darts();
        }
        //else if (Input.GetButtonUp("Fire1") || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            if (dart != null) //다트가 손에 있는 상태라면 
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
        }
        // 다트가 null이 아니라면 아직 다트를 던지기 전이다. 그 상태라면 timeIsForce를 증가시키고싶다.
        if (dart != null)
        {
            //오래 가지고 있을수록(=트리거를 누르고 있을수록) 던지는 힘이 커진다.
            forceWithTime += forceMax * Time.deltaTime * forceAdg;
        }
    }

    void Darts()
    {
        GameObject dartobj = GameObject.Instantiate(dartFactory);
        dartobj.transform.position = trRight.position;
        dartobj.transform.forward = trRight.forward;

        dartobj.transform.parent = trRight;
        //잡고 있는 동안엔 중력을 없앤다
        dartobj.GetComponent<Rigidbody>().isKinematic = true;
        //dartobj.GetComponent<Rigidbody>().AddForce(throwPower, ForceMode.Impulse);
        dart = dartobj.GetComponent<SEJDarts>();
        forceWithTime = 0;
    }
    
}
