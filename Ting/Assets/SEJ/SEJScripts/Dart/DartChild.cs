using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartChild : MonoBehaviour
{

    
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
}
