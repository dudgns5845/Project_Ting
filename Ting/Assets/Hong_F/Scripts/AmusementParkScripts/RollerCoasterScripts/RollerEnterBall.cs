using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollerEnterBall : MonoBehaviour
{
    public static RollerEnterBall Rn;

    public float setTime;

    public GameObject RollerCart1;
    public GameObject Player;
    public GameObject playerCam;
    public GameObject Cart1Cam;

    public GameObject Lhand;
    public GameObject Rhand;
    public GameObject po;

    public GameObject outPosition;

    public float isStartTime;
    public bool isRide;

    public AudioSource rolSound;

    private void Awake()
    {
        if (null == Rn)
        {
            Rn = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setTime = 4;

    }

    // Update is called once per frame
    void Update()
    {

        if (Cart1Cam.activeSelf)
        {
            isRide = true;

        }


        if (isRide)
        {
            RollerCoasterM.rollerM.rollStart = true;
           
        }
       //else
       // {
       //     Cart1Cam.SetActive(false);
       //     playerCam.SetActive(true);
       // }



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
                print("탑승 중 ");
                // 카메라 바꿔주기
                playerCam.SetActive(false);
                Cart1Cam.SetActive(true);

                // 끝나고 플레이어 나가게 만들기 
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

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(5f);
        RollerCoasterM.rollerM.rollStart = true;
        
    }

    IEnumerator endDelay()
    {
        yield return new WaitForSeconds(5f);
        Cart1Cam.SetActive(false);
        playerCam.SetActive(true);
        Player.transform.position = outPosition.transform.position;


    }
}
