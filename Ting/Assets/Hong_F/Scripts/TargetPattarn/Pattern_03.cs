using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_03 : MonoBehaviour
{
    public GameObject[] p3obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pattenr03();
    }

    void Pattenr03()
    {
        if(p3obj[0].activeSelf == false &&
            p3obj[1].activeSelf == false&&
            p3obj[2].activeSelf == false&&
            p3obj[3].activeSelf == false&&
            p3obj[4].activeSelf == false&&
            p3obj[5].activeSelf == false&&
            p3obj[6].activeSelf == false&&
            p3obj[7].activeSelf == false&&
            p3obj[8].activeSelf == false&&
            p3obj[9].activeSelf == false&&
            p3obj[10].activeSelf == false&&
            p3obj[11].activeSelf == false&&
            p3obj[12].activeSelf == false &&
            p3obj[13].activeSelf == false &&
            p3obj[14].activeSelf == false &&
            p3obj[15].activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }
}
