using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Gun Bullet Hole안에 붙어있던 스크립트


public class BulletFactory : MonoBehaviour
{

    public GameObject bulletFactory;
    public Text bulletText;
    public GameObject gunHole;
    //Rigidbody rd;
    public int MaxCount;

    public bool isGunGrip = false;
    public GameObject reloadobj;
    // Start is called before the first frame update
    void Start()
    {
        //rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGunGrip == true)
        {
            bulletinstantiate();
        }
    }


    void bulletinstantiate()
    {
        //if (hc.gun.transform.parent == hc.trRight)

        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
            

                if (0 < MaxCount)
                {
                    SoundManager_SEJ.soundM.PlayEFT(SoundManager_SEJ.EFT.EFT_SHOOT_GUN);
                    GameObject Bullet = Instantiate(bulletFactory);
                    Bullet.transform.position = gunHole.transform.position;
                    Bullet.transform.rotation = gunHole.transform.rotation;
                    Destroy(Bullet, 5);
                    MaxCount--;
                }
                else
                {
                    return;
                }

            }

            if (MaxCount <= 0)
            {
                MaxCount = 0;
            }

            string countS = MaxCount.ToString();
            bulletText.text = countS;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reload")
        {
            MaxCount = 12;
            //string countS = MaxCount.ToString();
            //bulletText.text = countS;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            StartCoroutine(respwanGun());
            print("바닥에 닿았습니다.");
        }
    }
    IEnumerator respwanGun()
    {
        yield return new WaitForSeconds(1f);
        transform.position = point.position;
        GetComponent<Rigidbody>().useGravity = false;
        transform.rotation = Quaternion.Euler(new Vector3(180, 180, 90));
        //rd.useGravity = false;
    }

    public GameObject GunHole;
    LineRenderer layser;
    bool isborder;
    public float raycastDistance = 10f;
    public Transform point;
}
