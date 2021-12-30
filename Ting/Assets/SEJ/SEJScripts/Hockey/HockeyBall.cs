using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HockeyBall : MonoBehaviourPun
{
    //먼저 치는 사람이 방장으로 
    public bool IsMasterClientLocal => PhotonNetwork.IsMasterClient && photonView.IsMine;




    Rigidbody rigidbody;

    public HockeyBall(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    private void FixedUpdate()
    {
        if (!IsMasterClientLocal || PhotonNetwork.PlayerList.Length < 2)
        {
            return;
        }

    }


    void Update()
    {
        //rigidbody.AddForce(dir, ForceMode.Impulse);
        inDirection = rigidbody.velocity;

        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
    }

    Vector3 inDirection;
    // 공이 받는 힘 조절
    public float kAdjustForce = 5;
    

    public void OnCollisionEnter(Collision collision)
    {
        //스틱에 닿으면
        if (collision.gameObject.layer == LayerMask.NameToLayer("Stick"))
        {   //컨트롤러로 치는 힘을 리지드바디의 속도로 입사각으로 넣는다
            rigidbody.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * kAdjustForce;
        }
        else
        {   //컨트롤러로 받은 힘을 반사각으로 뱉는다
            rigidbody.velocity = Vector3.Reflect(inDirection, collision.contacts[0].normal);
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}
