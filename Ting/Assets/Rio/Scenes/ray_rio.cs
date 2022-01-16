using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_rio : MonoBehaviour
{
    public Transform rhand;
    Ray Ray;
    RaycastHit hit;
    private void Update()
    {
       Ray = new Ray();
        if(Physics.Raycast(rhand.position,rhand.forward,out hit, 100))
        {
            print(hit.collider.name);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                hit.collider.transform.SetParent(rhand);
                hit.transform.localPosition = new Vector3(0, 0, 0);
                hit.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                //hit.transform.rotation =Quaternio
            }
          
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(rhand.position, rhand.forward * 100, Color.red);
    }
}
