using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Rio : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (anim == null) return;
        FSM();
        playerMove();
        playerRot();
    }

    void FSM()
    {
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) != Vector2.zero)
            anim.SetBool("walk", true);
        else if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) == Vector2.zero)
            anim.SetBool("walk", false);
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
            anim.SetBool("jump", true);
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
            anim.SetBool("jump", false);

        //if (Input.GetKeyDown(KeyCode.W))
        //    anim.SetBool("walk", true);
        //if (Input.GetKeyUp(KeyCode.W))
        //    anim.SetBool("walk", false);
        //if (Input.GetKey(KeyCode.Space))
        //    anim.SetBool("jump", true);
        //if (Input.GetKeyUp(KeyCode.Space))
        //    anim.SetBool("jump", false);

        //if (Input.GetKey(KeyCode.Alpha1))
        //    anim.SetBool("shuffling", true);
        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //    anim.SetBool("shuffling", false);

        //if (Input.GetKey(KeyCode.Alpha2))
        //    anim.SetBool("excited", true);
        //if (Input.GetKeyUp(KeyCode.Alpha2))
        //    anim.SetBool("excited", false);

        //if (Input.GetKey(KeyCode.Alpha3))
        //    anim.SetBool("angry", true);
        //if (Input.GetKeyUp(KeyCode.Alpha3))
        //    anim.SetBool("angry", false);
    }

    void playerMove()
    {
        //조이스틱 값 받아오기 x 좌우 ,y 상하
        Vector2 stickPos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        moveDirection = new Vector3(stickPos.x, 0, stickPos.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        //if (Input.GetButton("Jump"))
        //    moveDirection.y = jumpSpeed;

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


