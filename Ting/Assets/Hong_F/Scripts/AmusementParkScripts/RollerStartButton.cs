using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerStartButton : MonoBehaviour
{

   public  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      //  anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
            
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject.name == "Button")
        //        {
        //            RollerCoasterM.rollerM.rollStart = true;
        //            print(hit.collider.gameObject.name);
        //        }
        //    }
        //}

    }

   


   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Tip"))
        {
            print("클릭되었습니다");
            anim.SetTrigger("ButtonClick");
         RollerCoasterM.rollerM.rollStart = true;

        }
    }




}
