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
        tx.text = "ȯ���մϴ�";
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
                    tx.text = "���̷ε�ӿ�" + '\n' + "ž���Ͻðڽ��ϱ�?";

                }
                else if (currTime >= 8)
                {
                    tx.text = "ž���� ���ϽŴٸ�" + '\n' + "���� ���°���" + '\n' + "���� ���� �뼼��";
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
