using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Cinemachine_Rio : MonoBehaviour
{
    CinemachineVirtualCamera cv;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        print("»£√‚");
        cv = GetComponent<CinemachineVirtualCamera>();
        cv.Follow = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
        cv.LookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
}
