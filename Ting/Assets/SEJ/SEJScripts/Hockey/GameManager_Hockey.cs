using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//점수받기
public class GameManager_Hockey : MonoBehaviourPun
{
    public static GameManager_Hockey gmHockey;
    public Transform[] spawnPositions;

    private void Awake()
    {
        if(gmHockey==null)
        {
            gmHockey = this;
        }
    }

    void SpawnStick()
    {
        var localStickIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
