using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발사되고싶다.
// rb를 이용해서 물리법칙에 의해서 움직이고싶다.
public class Donut : MonoBehaviour
{
    Rigidbody rb;

    void Update()
    {

    }

    public void Shoot(float timeIsForce)
    {
        if (rb == null)
        {
            //start에 쓰면 순서대로 읽느라 오래걸리니까 아예 조건으로 필요할때마다 불러주기
            rb = GetComponent<Rigidbody>();
        }
        //던져지면 물리법칙을 받는다
        rb.isKinematic = false;
        //리지드바디를 이용한 속도는 앞방향 * 힘
        rb.velocity = transform.forward * timeIsForce;
        //회전가속도 (y축으로 회전하면서 나아가도록)
        rb.angularVelocity = new Vector3(0, Random.Range(-10f, 10f), 0);

    }


}
