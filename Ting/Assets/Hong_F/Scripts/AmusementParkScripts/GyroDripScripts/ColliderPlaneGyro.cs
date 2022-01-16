using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColliderPlaneGyro : MonoBehaviour
{
    public static ColliderPlaneGyro cp;
    public GameObject infoCanvas;
    public Text tx;
    public GameObject enterBall;
    public bool isReady = false;

    float currTime;


    private void Awake()
    {
        if (cp == null)
            cp = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tx.text = "환영합니다";
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (isReady) return;
        if (other.gameObject.name == "Auto Hand Player")
        {
            infoCanvas.SetActive(true);
            if (infoCanvas.activeSelf == true)
            {
                currTime += Time.deltaTime;
                if (currTime >= 4 && currTime < 8)
                {
                    tx.text = "자이로드롭에" + '\n' + "탑승하시겠습니까?";

                }
                else if (currTime >= 8)
                {
                    tx.text = "탑승을 원하신다면" + '\n' + "빛이 나는곳에" + '\n' + "손을 갖다 대세요";
                    enterBall.SetActive(true);
                }



            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {
            infoCanvas.SetActive(false);

        }
    }
}
