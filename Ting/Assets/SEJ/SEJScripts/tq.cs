using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tq : MonoBehaviour
{
    //������
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
        //���࿡ ������ A��ư�� ������
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            //������ ��ġ,������ �չ������� ������ Ray�� �����
            Ray ray_R = new Ray(trRight.position, trRight.forward);
            Ray ray_L = new Ray(trLeft.position, trLeft.forward);

            Collider[] hits = Physics.OverlapSphere(trRight.position, grabRange);

            //���࿡ ray�� �ؼ� ��򰡿� �ε����ٸ�
            if (hits.Length > 0)
            {
                hits[0].transform.parent = trRight; //������ �ڽ�
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

                //2. ���� ��ü�� ���´�.(���� ��ü�� �θ� ���ش�)
                grabObj.parent = null;
                //3. trCatced�� ���� null�� �Ѵ�
                grabObj = null;
            }

        }
    }
    void ThrowObj()
    {
        //������ ����     (�̵��ӵ�)
        Vector3 dir = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //������ ȸ������ (ȸ���ӵ�)
        Vector3 angularDir = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);

        Rigidbody rb = SetKinematic(false);
        //������ Rigidbody�� velocity ���� dir�� ����
        rb.velocity = dir * throwPower;
        //������ Rigidbody�� angularVelocity ���� angularDir�� ����
        rb.angularVelocity = angularDir;
    }
    Rigidbody SetKinematic(bool enable)
    {
        // ���� ��ü���� Rigidbody ������Ʈ �����´�
        Rigidbody rb = grabObj.GetComponent<Rigidbody>();
        // ������ ������Ʈ�� isKinematic�� false�Ѵ�
        rb.isKinematic = enable;

        return rb;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trRight.position, grabRange);
    }
}
