using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class PlayerMove_Rio : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    CharacterController controller;

    public PhotonView pv;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        pv = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (pv.IsMine)
        {
            if (anim == null) return;
            FSM();
            playerMove();
            playerRot();
        }
    }

    void FSM()
    {
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) != Vector2.zero)
        {
            //anim.SetBool("walk", true);
            pv.RPC("SetAnim", RpcTarget.All, "walk", true);
        }
        else if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) == Vector2.zero)
        {
            //anim.SetBool("walk", false);
            pv.RPC("SetAnim", RpcTarget.All, "walk", false);
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
        {
            //anim.SetBool("jump", true);
            pv.RPC("SetAnim", RpcTarget.All, "jump", true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
        {
            //anim.SetBool("jump", false);
            pv.RPC("SetAnim", RpcTarget.All, "jump", false);
        }
    }

    [PunRPC]
    void SetAnim(string animName, bool isActive)
    {
        anim.SetBool(animName, isActive);
    }

    void playerMove()
    {
        //조이스틱 값 받아오기 x 좌우 ,y 상하
        Vector2 stickPos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        moveDirection = new Vector3(stickPos.x, 0, stickPos.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
            moveDirection.y = jumpSpeed;

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void playerRot()
    {

        transform.rotation = Quaternion.Euler(rot);
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
        {
            rotPlus();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            rotMinus();
        }

    }

    Vector3 rot;
    void rotPlus()
    {
        rot.y += 30;
    }
    void rotMinus()
    {
        rot.y -= 30;
    }

  
}


