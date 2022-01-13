//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class GunManager : MonoBehaviour
//{


//    public GameObject bulletFactory;
//    public Text bulletText;
//    public GameObject gunHole;
//    Rigidbody rd;
//    public int MaxCount;


//    // Start is called before the first frame update
//    void Start()
//    {
//        rd = GetComponent<Rigidbody>();
//        MaxCount = 12;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }


//    void bulletinstantiate()
//    {
//        if (hc.gun.transform.parent == hc.trRight)
//        {
//            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
//            {
//                rd.useGravity = true;

//                if (0 < MaxCount)
//                {
//                    GameObject Bullet = Instantiate(bulletFactory);
//                    Bullet.transform.position = gunHole.transform.position;
//                    Bullet.transform.rotation = gunHole.transform.rotation;
//                    Destroy(Bullet, 5);
//                    MaxCount--;
//                }
//                else
//                {
//                    return;
//                }

//            }

//            if (MaxCount <= 0)
//            {
//                MaxCount = 0;
//            }

//            string countS = MaxCount.ToString();
//            bulletText.text = countS;
//        }

//    }
//}
