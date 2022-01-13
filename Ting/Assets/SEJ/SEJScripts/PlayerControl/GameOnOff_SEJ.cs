using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//처음엔 게임 스크립트 다 꺼주고 이동하는 스크립트만 남긴다
//지나가다가 게임기에 가까워지면 UI가 뜨면서 카메라 (1인칭으로) 전환시키기
//시작할지 말지 UI뜨도록
//시작한다면 그 게임에 맞는 스크립트만 켜주고 다른 게임 스크립트는 꺼준다

public class GameOnOff_SEJ : MonoBehaviour
{
    public static GameOnOff_SEJ onoff;
    public GameObject dartObjFactory; //다트핀 프리펩

    private void Awake()
    {
        if (onoff == null)
            onoff = this;
    }
    public void Start()
    {
       //처음에 게임에 관련된 스크립트는 다 꺼준다
        GetComponent<ThrowHockeyBall>().enabled = false;
        GetComponent<ThrowDart>().enabled = false;
        dartObjFactory.SetActive(false);
        //GetComponent<GunControl>().enabled = false;
    }

    void Update()
    {
    }

    public bool isHockey;
    public bool isDart;
    public bool isGun;
    public void PlayHockey()
    {
        //GetComponent<ThrowHockeyBall>().enabled = true;
        if (isHockey)
        {
            GetComponent<ThrowHockeyBall>().enabled = true;
        }
        if (isHockey == false)
        {
            GetComponent<ThrowHockeyBall>().enabled = false;
        }

    }
    public void PlayDart()
    {
        //GetComponent<ThrowDart>().enabled = true;
        if (isDart)
        {
            GetComponent<ThrowDart>().enabled = true;
        }
        if (isDart == false)
        {
            GetComponent<ThrowDart>().enabled = false;
        }

    }
    //public void PlayGun()
    //{
    //    //GetComponent<GunControl>().enabled = true;
    //    if (isGun)
    //    {
    //        GetComponent<GunControl>().enabled = true;
    //    }
    //    if (isGun == false)
    //    {
    //        GetComponent<GunControl>().enabled = false;
    //    }
    //}



}
