using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PteraPattern : MonoBehaviour
{
    public static PteraPattern pt;

    public GameObject position01;
    public GameObject position02;
    public GameObject position03;

    public GameObject position04;
    public GameObject position05;

    Vector3 startPos;

    public bool m1;
    public bool m4;
    public bool m5;
    public bool mStart;

    Animator anim;

    private void Awake()
    {
        pt = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m1 == true)
        {

            MovePosition01();

        }

        if (m4 == true)
        {
            MovePosition04();
        }

        if(m5 ==  true)
        {
            MovePosition05();
        }

        if(mStart == true)
        {
            MovestartPos();
        }

    }

    public void MovePosition01()
    {
        transform.position = Vector3.Slerp(transform.position, position01.transform.position, 0.5f * Time.deltaTime);
        transform.LookAt(position02.transform.position);
    }

    public void MovePosition04()
    {
        anim.SetBool("isFlight", true);
        transform.position = Vector3.Lerp(transform.position, position04.transform.position, 1.5f * Time.deltaTime);
        transform.LookAt(position04.transform.position);
        
        


    }

    public void MovePosition05()
    {
        anim.SetBool("isFlight", false);
        transform.position = Vector3.Lerp(transform.position, position05.transform.position, 1.5f * Time.deltaTime);
       
    }

    public void MovestartPos()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, 0.5f * Time.deltaTime);
        transform.LookAt(position03.transform.position);
    }
    





}
