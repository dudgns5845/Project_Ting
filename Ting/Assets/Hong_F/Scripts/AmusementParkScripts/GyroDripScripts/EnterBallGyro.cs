using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBallGyro : MonoBehaviour
{
    public static EnterBallGyro Gn;

    public float setTime;

    public GameObject RollerCart1;
    public GameObject Player;
    public GameObject playerCam;
    public GameObject gyRoCam1;

    public GameObject Lhand;
    public GameObject Rhand;
    public GameObject po;

    public GameObject outPosition;

    public float isStartTime;
    public bool isRide;
    // Start is called before the first frame update
    void Start()
    {
        setTime = 4;
    }

    // Update is called once per frame
    void Update()
    {

        if (gyRoCam1.activeSelf)
        {
            isRide = true;
        }


        if (isRide)
        {


            StartCoroutine(delayTime());
         //   RollerCoasterM.rollerM.rollStart = true;

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
            ColliderPlaneGyro.cp.isReady = true;
            ColliderPlaneGyro.cp.tx.text = ((int)setTime).ToString();



            print("Ʈ���Źߵ�");
            setTime -= Time.deltaTime;


            if (setTime < 0)
            {
                ColliderPlaneGyro.cp.tx.text = "ž�� ��";
                print("ž�� �� ");
                // ī�޶� �ٲ��ֱ�
                playerCam.SetActive(false);
                gyRoCam1.SetActive(true);
                // ������ �÷��̾� ������ ����� 
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
    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(5f);
        GyroDrop.Gyro.GyodropPlay();

    }
}
