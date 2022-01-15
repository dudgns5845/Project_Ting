using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tq : MonoBehaviour
{
    //오른손
    public Transform trRight;
    public Transform trLeft;
    //public GameObject grabObject;
    Transform grabObj;
    public float grabRange = 0.01f;
    public LayerMask layer;
    public float throwPower = 5;
    void Start()
    {

    }

    void Update()
    {
        Grip();
        Drop();
        ThrowObj();
    }
    void Grip()
    {
        //만약에 오른쪽 A버튼을 누르면
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            //오른손 위치,오른손 앞방향으로 나가는 Ray를 만든다
            Ray ray_R = new Ray(trRight.position, trRight.forward);
            Ray ray_L = new Ray(trLeft.position, trLeft.forward);

            Collider[] hits = Physics.OverlapSphere(trRight.position, grabRange);

            //만약에 ray를 해서 어딘가에 부딪혔다면
            if (hits.Length > 0)
            {
                hits[0].transform.parent = trRight; //오른손 자식
                grabObj = hits[0].transform;
                SetKinematic(true);
            }
        }
    }
    void Drop()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            if (grabObj != null)
            {

                ThrowObj();

                //2. 잡은 물체를 놓는다.(잡은 물체의 부모를 없앤다)
                grabObj.parent = null;
                //3. trCatced의 값을 null로 한다
                grabObj = null;
            }

        }
    }
    void ThrowObj()
    {
        //던지는 방향     (이동속도)
        Vector3 dir = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //던지는 회전방향 (회전속도)
        Vector3 angularDir = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);

        Rigidbody rb = SetKinematic(false);
        //가져온 Rigidbody의 velocity 값에 dir을 넣자
        rb.velocity = dir * throwPower;
        //가져온 Rigidbody의 angularVelocity 값에 angularDir을 넣자
        rb.angularVelocity = angularDir;
    }
    Rigidbody SetKinematic(bool enable)
    {
        // 잡은 물체에서 Rigidbody 컴포넌트 가져온다
        Rigidbody rb = grabObj.GetComponent<Rigidbody>();
        // 가져온 컴포넌트의 isKinematic을 false한다
        rb.isKinematic = enable;

        return rb;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trRight.position, grabRange);
    }
}
