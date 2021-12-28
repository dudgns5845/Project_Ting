using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;
public class Player_Pun_Setting_Rio : MonoBehaviour
{
    PhotonView pv;
    PhotonVoiceView pv_voice;
    public GameObject Cam;

    private void Awake()
    {
      
        pv = GetComponent<PhotonView>();
        pv_voice = GetComponent<PhotonVoiceView>();
        if (pv.IsMine)
        {
            pv_voice.enabled = true;
            GetComponent<PlayerMove_Rio>().enabled = true;
            Cam.SetActive(true);
            AudioListener.volume = 1;
        }
        else
        {
            pv_voice.enabled = false;
            GetComponent<AudioListener>().enabled = false;
            GetComponent<PlayerMove_Rio>().enabled = false;
            Cam.SetActive(false);
        }
    }
}
