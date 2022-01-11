using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발사되고싶다.
// rb를 이용해서 물리법칙에 의해서 움직이고싶다.
public class SEJDarts : MonoBehaviour
{
    Rigidbody rb;
    public bool isTouching;
    public Transform rayOrigin;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity != new Vector3(0, 0, 0))
            transform.forward = rb.velocity.normalized;
    }

    public void Shooting(float forceWithTime)
    {
        if (rb == null)
        {
            //start에 쓰면 순서대로 읽느라 오래걸리니까 아예 조건으로 필요할때마다 불러주기
            rb = GetComponent<Rigidbody>();
        }
        isTouching = false;
        //던져지면 물리법칙을 받는다
        rb.isKinematic = false;
        //리지드바디를 이용한 속도는 앞방향 * 힘
        rb.velocity = transform.forward * forceWithTime;
        //회전가속도 
        rb.AddTorque(transform.forward * 10000, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTouching == true)
            return;

        Ray ray = new Ray(rayOrigin.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            SEJBoardPiece boardPiece = hitInfo.collider.GetComponent<SEJBoardPiece>();
            if (boardPiece != null)
            {
                print(boardPiece.name);
                isTouching = true;
                SetMyChildren(boardPiece.transform);

                transform.position = hitInfo.point + transform.forward * 0.25f;

                // 다트가 보드조각에 부딪혔을때 보드조각의 본체인 보드에게 점수정보를 넘겨주고싶다.
                boardPiece.AddScorePlz(this);
            }
        }
    }

    public void SetMyChildren(Transform parent)
    {
        //gameObject.GetComponentInChildren<Collider>().enabled = false;
        //transform.parent = parent;
        //Board에 닿으면 멈춘다
        //coll가진 물체에 닿으면
        //print("충돌" + coll.gameObject.name);
        isTouching = true;
        rb.useGravity = false; //중력제거
        rb.isKinematic = true; //회전제거
        // 충돌체도 끈다
        // 내 부모 = 너
    }

    //void CheckDart(Collision coll)
    //{
    //    print("충돌" + coll.gameObject.name);
    //    print(coll.contacts[0].point);
    //    isTouching = true;
    //    rb.velocity = Vector3.zero; //속도제거
    //    rb.useGravity = false; //중력제거
    //    rb.isKinematic = true; //회전제거
    //}
}
