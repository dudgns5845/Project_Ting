using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Rio : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FSM();
    }

    void FSM()
    {
        if (Input.GetKeyDown(KeyCode.W))
            anim.SetBool("walk", true);
        if (Input.GetKeyUp(KeyCode.W))
            anim.SetBool("walk", false);

        if (Input.GetKey(KeyCode.Space))
            anim.SetBool("jump", true);
        if (Input.GetKeyUp(KeyCode.Space))
            anim.SetBool("jump", false);

        if (Input.GetKey(KeyCode.Alpha1))
            anim.SetBool("shuffling", true);
        if (Input.GetKeyUp(KeyCode.Alpha1))
            anim.SetBool("shuffling", false);

        if (Input.GetKey(KeyCode.Alpha2))
            anim.SetBool("excited", true);
        if (Input.GetKeyUp(KeyCode.Alpha2))
            anim.SetBool("excited", false);

        if (Input.GetKey(KeyCode.Alpha3))
            anim.SetBool("angry", true);
        if (Input.GetKeyUp(KeyCode.Alpha3))
            anim.SetBool("angry", false);
    }
}
