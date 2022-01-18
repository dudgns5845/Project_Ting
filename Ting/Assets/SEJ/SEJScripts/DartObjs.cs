using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartObjs : MonoBehaviour
{
    public GameObject[] darts;

    void Start()
    {
        
    }

    public void ResetDart()
    {
        for(int i = 0; i < darts.Length; i++)
        {
            Destroy(darts[i]);
        }
        Destroy(gameObject);
    }
}
