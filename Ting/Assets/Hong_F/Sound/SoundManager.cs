using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sM;

    public AudioSource trex_01;
    public AudioSource trex_02;
    public AudioSource trex_03;
    public AudioSource trex_04;

    public AudioSource wantCoaster;
    public AudioSource wnatGyro;
    public AudioSource handPlease;
    public AudioSource welCome;

    public AudioSource GyroUP;
    public AudioSource GyroMIDDLE;
    public AudioSource GyroDOWN;
    
    private void Awake()
    {

        if(null == sM)
        {
            sM = this;
        }
    }

    // Start is called before the first frame update
    public void Trex_01()
    {
        trex_01.Play();
        print("티라노 1번");
    }

    public void Trex_02()
    {
        trex_02.Play();
        print("티라노 2번");


    }
    public void Trex_03()
    {
        trex_03.Play();
        print("티라노 4번");
       


    }
    public void Trex_04()
    {
        trex_04.Play();
        print("티라노 3번");

    }
}
