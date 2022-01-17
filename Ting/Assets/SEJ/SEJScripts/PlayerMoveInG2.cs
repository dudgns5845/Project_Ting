using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //리오플레이어 무브 스크립트 복사
public class PlayerMoveInG2 : MonoBehaviour
{


    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null) return;
        FSM();
        playerMove();
        playerRot();
    }

    private void FSM()
    {
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) != Vector2.zero)
            anim.SetBool("walk", true);
        else if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) == Vector2.zero)
            anim.SetBool("walk", false);
        //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
        //    anim.SetBool("jump", true);
        //else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
        //    anim.SetBool("jump", false);

    }

    private void playerRot()
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
        rot.y += 50;
    }
    void rotMinus()
    {
        rot.y -= 50;
    }
    private void playerMove()
    {
        //조이스틱 값 받아오기 x 좌우 ,y 상하
        Vector2 stickPos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        moveDirection = new Vector3(stickPos.x, 0, stickPos.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        //if (Input.GetButton("Jump"))
        //    moveDirection.y = jumpSpeed;

        //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
        //    moveDirection.y = jumpSpeed;

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
