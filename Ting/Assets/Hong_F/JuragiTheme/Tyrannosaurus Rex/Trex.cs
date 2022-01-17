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
                SoundManager.sM.Trex_01();
                delayTime = 0;

            }
            else if (rand == 1)
            {
                anim.SetTrigger("Idle2");
                SoundManager.sM.Trex_02();

                delayTime = 0;


            }
            else if (rand == 2)
            {
                anim.SetTrigger("Idle3");
                SoundManager.sM.Trex_04();
                delayTime = 0;


            }
            else if (rand == 3)
            {
                anim.SetTrigger("Idle4");
                SoundManager.sM.Trex_03();

                delayTime = 0;


            }
        }
        
    }

   

    
}
