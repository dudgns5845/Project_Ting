using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollerEnterBall : MonoBehaviour
{
    public float setTime;

    public GameObject RollerCart1;
    public GameObject Player;
    public 
   
    // Start is called before the first frame update
    void Start()
    {
        setTime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "hand")
        {
            setTime -= Time.deltaTime;
            PlaneCollider.pc.isReady = true;
            PlaneCollider.pc.tx.text = ((int)setTime).ToString();



            print("트리거발동");
            setTime -= Time.deltaTime;


            if (setTime < 0)
            {
                PlaneCollider.pc.tx.text = "탑승 중";
                Player.transform.transform.parent = RollerCart1.transform;
                Player.transform.localPosition = new Vector3(0, 0, 0);
                Player.GetComponent<Rigidbody>().useGravity = false;


            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "hand")
        {
            setTime = 4;

        }


    }
}
