using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_SEJ : MonoBehaviour
{
    public static SoundManager_SEJ soundM;

    private void Awake()
    {
        if (soundM == null)
            soundM = this;
    }
    void Start()
    {
        PlayBGM(BGM.BGM_GAMEZONE);
    }

    public AudioSource audioEft;
    public AudioClip[] eftAudios;
    public AudioSource audioBgm;
    public AudioClip[] bgmAudios;

    public enum BGM
    {
        BGM_GAMEZONE,
        BGM_CAFE
    }
    public enum EFT
    { 
        EFT_HIT_HOCKEY,
        EFT_WALL_HOCKEY,
        EFT_GOAL_HOCKEY,
        EFT_SHOOT_GUN,
        EFT_RESPAWN_GUN,
        EFT_THROW_DART,
        EFT_TOUCHING_DART

    }


    public void PlayBGM(BGM type)
    {
        audioBgm.clip = bgmAudios[(int)type];
        audioBgm.Play();
    }
    public void StopBGM()
    {
        audioBgm.Stop();
    }
    public void PlayEFT(EFT type)
    {
        print("사운드 호출");
        audioEft.PlayOneShot(eftAudios[(int)type]);
    }

   
   
}
