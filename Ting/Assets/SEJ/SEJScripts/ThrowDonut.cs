using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스 왼쪽 버튼을 누르면 도넛 공장에서 도넛을 생성해서 총구의 자식으로 넣고싶다.
// 마우스 왼쪽 버튼을 떼면 던지고싶다.
public class ThrowDonut : MonoBehaviour
{
    //도넛공장
    public GameObject donutFac;
    //카메라가 일단 총구
    public Transform shootPos; //vr 로 하면 손으로 위치 이동하기

    void Start()
    { 
        shootPos = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  //VR 트리거 눌렀을 때
        {
            DonutFactory();
        }
        if (Input.GetButtonUp("Fire1")) //VR 트리거 놓았을 때
        {
            if (donut != null) //도넛이 손에 있는 상태라면 
            {
                // 던지는 힘의 크기를 제한하고싶다.
                timeIsForce = Mathf.Clamp(timeIsForce, 5, maxForce);
                //도넛이 손을 떠나가도록 부모의 shootPos를 없앤다.
                donut.gameObject.transform.parent = null;
                //도넛을 던지는 함수 실행
                donut.Shoot(timeIsForce);
                //손에서 떠난 도넛 
                donut = null;
            }

        }

        // 도넛이 null이 아니라면 아직 도넛을 던지기 전이다. 그 상태라면 timeIsForce를 증가시키고싶다.
        if (donut != null)
        {
           //오래 가지고 있을수록(=트리거를 누르고 있을수록) 던지는 힘이 커진다.
            timeIsForce += maxForce * Time.deltaTime * forceAdjust;
        }
    }
    Donut donut = null;
    float timeIsForce;  //잡고있는 시간이 길수록 힘이 커지도록 정의할 변수
    public float forceAdjust = 2; //힘조절
    public float maxForce = 10; //힘의 최대크기 (인스펙터창에서 조절) , 40정도가 적당한듯
    void DonutFactory()
    {
        // 도넛을 만들어서 위치와 방향을 결정하고싶다.
        GameObject donutGameObject = GameObject.Instantiate(donutFac);
        donutGameObject.transform.position = shootPos.position;
        donutGameObject.transform.forward = shootPos.forward;
        // donut오브젝트를 shootpos의 자식으로 넣는다 (도넛을 놓기 전까지 shootpos위치 따라다니도록)
        donutGameObject.transform.parent = shootPos;
        //만들어진 도넛은 던지기 전까지는 물리법칙을 무시한다
        donutGameObject.GetComponent<Rigidbody>().isKinematic = true;
        donut = donutGameObject.GetComponent<Donut>();
        timeIsForce = 0; 
    }

}
