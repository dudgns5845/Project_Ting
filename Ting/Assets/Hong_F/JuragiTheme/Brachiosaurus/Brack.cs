using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brack : MonoBehaviour
{

    Animator anim;
    float currTime;

    // 나중엔 20초정도로 맞추자! 딱적당 할 듯 하다 !
    float delayTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        brackAnimPattern();
    }

    void brackAnimPattern()
    {
        currTime += Time.deltaTime;

        if(currTime >= delayTime)
        {
            anim.SetTrigger("Brack2");
            currTime = 0;
        }
    }
}
