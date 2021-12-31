using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterManager : MonoBehaviour
{

    public Animator rollerCoasterAnim;
    public bool rollerStart;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        StartRollerCoaster();
    }

    void StartRollerCoaster()
    {
       if(rollerStart)
        {
            rollerCoasterAnim.SetBool("Start", true);
            
        }


    }
}
