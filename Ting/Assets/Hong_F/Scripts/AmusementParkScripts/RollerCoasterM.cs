using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterM : MonoBehaviour
{
    public static RollerCoasterM rollerM;

    public GameObject StartButton;
    public bool rollStart;
     Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        if(null == rollerM)
        {
            rollerM = this;
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Start", false);
        rollStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartRollerCoaster();
    }

    public void StartRollerCoaster()
    {

        if(rollStart == true)
        {

        anim.SetBool("Start", true);

        }
        else
        {
            anim.SetBool("Start", false);
        }
    }

    public void rollfalseFuntion()
    {
        rollStart = false;
    }

    
}
