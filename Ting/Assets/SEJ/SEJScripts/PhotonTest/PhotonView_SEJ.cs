using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonView_SEJ: MonoBehaviour
{
    public PhotonView myPhotonView;
    public GameObject cam;


    void Start()
    {
        if (myPhotonView.IsMine)
        {
            cam.SetActive(true);
        }
        else
        {
            cam.SetActive(false);
            GetComponent<PlayerMove_Rio>().enabled = false;
        }
    }

    void Update()
    {

    }
}
