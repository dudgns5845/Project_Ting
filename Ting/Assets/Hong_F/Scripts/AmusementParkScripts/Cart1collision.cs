using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart1collision : MonoBehaviour
{

    public GameObject Position02;
    public GameObject Position03;


    float delayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Position03")
        {
            PteraPattern.pt.m1 = true;

        }

        if (other.gameObject.name == "Position02")
        {

            PteraPattern.pt.m1 = false;

        }

        if (other.gameObject.name == "Position06")
        {

            PteraPattern.pt.m4 = false;
            PteraPattern.pt.m5 = true;

        }

        if (other.gameObject.name == "Position07")
        {
            PteraPattern.pt.m5 = false;
            PteraPattern.pt.mStart = true;
        }





    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Position02")
        {
            PteraPattern.pt.m4 = true;
        }
    }


}
