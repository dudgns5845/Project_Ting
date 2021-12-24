using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HockeyBall : MonoBehaviourPun,IPunObservable
{
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        //rigidbody.AddForce(dir, ForceMode.Impulse);
        inDirection = rigidbody.velocity;

        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
    }

    Vector3 inDirection;
    // ���� �޴� �� ����
    public float kAdjustForce = 5;
    

    public void OnCollisionEnter(Collision collision)
    {
        //Mallet�� ������
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mallet"))
        {   //��Ʈ�ѷ��� ġ�� ���� ������ٵ��� �ӵ��� �Ի簢���� �ִ´�
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * kAdjustForce;
        }
        else
        {   //��Ʈ�ѷ��� ���� ���� �ݻ簢���� ��´�
            rigidbody.velocity = Vector3.Reflect(inDirection, collision.contacts[0].normal);
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}
