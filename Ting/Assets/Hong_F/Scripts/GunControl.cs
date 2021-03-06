using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    //오른손 컨트롤러
    public Transform trRight;
    //잡고 있는 물체
    public GameObject gun;
    public Rigidbody gunRb;
    public LayerMask Gunlayer; //Gun으로 바꾸기
    public BulletFactory bulletF;

    //잡을수 있는 거리
    float grabRange = 0.2f;
  

    void Update()
    {
        CathGun();
    }

    public void CathGun()
    {
        gunRb = gun.GetComponent<Rigidbody>();

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            Collider[] gunObj = Physics.OverlapSphere(trRight.position, grabRange, Gunlayer);

            gun = gunObj[0].gameObject;
            gun.transform.SetParent(trRight);
            gunRb.useGravity = false;
            gun.transform.position = trRight.transform.position;
            gun.transform.rotation = trRight.rotation;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            gun.transform.SetParent(null);
            if (gun.transform.position == trRight.transform.position)
            {
                gunRb.useGravity = true;
            }
        }
    }
}
