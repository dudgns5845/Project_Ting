using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camrot_SEJ : MonoBehaviour
{
    //회전값
    float rotX;
    float rotY;

    float rotSpeed = 200; //회전속력


    void Start()
    {
        //회전값 초기화
        rotX = -transform.localEulerAngles.x;
        rotY = transform.localEulerAngles.y;
    }

    void Update()
    {
        //마우스 움직임에 따라서 카메라를 회전시키고 싶다

        //1. 마우스 입력을 받고
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //2. 마우스 입력값을 누적(회전값)
        rotX += my * rotSpeed * Time.deltaTime;
        rotY += mx * rotSpeed * Time.deltaTime;

        //상하 회전을 -60 ~ 60으로 제한
        rotX = Mathf.Clamp(rotX, -60, 60);

        //3. 카메라의 회전값을 누적값으로 셋팅
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);


    }
}
