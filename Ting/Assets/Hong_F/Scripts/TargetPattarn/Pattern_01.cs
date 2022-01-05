using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_01 : MonoBehaviour
{

    Vector3 movePosition;

    public GameObject[] p1obj;

    public int obj_count;



    // Start is called before the first frame update
    void Start()
    {
        obj_count = p1obj.Length;
        //transform.position = new Vector3(0, 3, 15);
        transform.localPosition = new Vector3(0, 0, 12);
        
    }

    // Update is called once per frame
    void Update()
    {
        Pattern1();
    }

    public void Pattern1()
    {
        //movePosition = new Vector3(0, 3, 5);
        movePosition = new Vector3(0, 0, 1);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, movePosition, 0.1f);

        print(transform.position);

       //if(p1obj[0|1|2|3|4].activeSelf == false)
       // {
       //     obj_count--;
       // }

       // if (obj_count == 0)
       // {
       //     gameObject.SetActive(false);
       // }

       
        //if (p1obj[0].activeSelf == false &&
        //         p1obj[1].activeSelf == false &&
        //         p1obj[2].activeSelf == false &&
        //         p1obj[3].activeSelf == false &&
        //         p1obj[4].activeSelf == false)
        //{
        //    gameObject.SetActive(false);
        //}
        //if (obj_count == 0)
        //{
        //    gameObject.SetActive(false);
        //}
    }


   

}

