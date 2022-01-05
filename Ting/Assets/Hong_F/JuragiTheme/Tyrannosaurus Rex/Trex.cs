using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trex : MonoBehaviour
{

    Animator anim;

    float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimIdlePattern();
    }

    void AnimIdlePattern()
    {

        delayTime += Time.deltaTime;

        if(delayTime >= 10)
        {
            int rand = Random.Range(0, 4);
            if (rand == 0)
            {
                anim.SetTrigger("Idle1");
                print("11111111111111111");
                delayTime = 0;

            }
            else if (rand == 1)
            {
                anim.SetTrigger("Idle2");
                print("2222222222");
                delayTime = 0;


            }
            else if (rand == 2)
            {
                anim.SetTrigger("Idle3");
                print("33333333333333");
                delayTime = 0;


            }
            else if (rand == 3)
            {
                anim.SetTrigger("Idle4");
                print("444444444444444");
                delayTime = 0;


            }
        }
        
    }

   

    
}
