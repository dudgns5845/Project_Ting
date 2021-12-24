using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    // ������ ��Ʈ�ѷ�
    public Transform trRight;
    // ��� �ִ��� ����
    bool isgGrabbing = false;
    //��� �ִ� ��ü 
    public GameObject gun;
    public Rigidbody gunRb;
    public LayerMask Gunlayer;
    public BulletFactory bulletF;

    //������ �ִ� �Ÿ� 
    float grabRange = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
