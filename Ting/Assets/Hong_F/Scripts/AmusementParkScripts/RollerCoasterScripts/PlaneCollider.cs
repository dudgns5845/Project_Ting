using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaneCollider : MonoBehaviour
{
    public static PlaneCollider pc;

    public GameObject infoCanvas;
    public Text tx;
    public GameObject enterBall;
    public bool isReady = false;
    private void Awake()
    {
        if (pc == null)
            pc = this;
    }



    float currTime;

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


            if (infoCanvas.activeSelf == true)
            {
                currTime += Time.deltaTime;
                if (currTime >= 4 && currTime < 8)
                {

                    tx.text = "���׶��ڽ��Ϳ�" + '\n' + "ž���Ͻðڽ��ϱ�?";



                }
                else if (currTime >= 8)
                {
                    tx.text = "ž���� ���ϽŴٸ�" + '\n' + "���� ���� ����" + '\n' + "���� ���� �뼼��";




                    enterBall.SetActive(true);
                }






            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {
            infoCanvas.SetActive(true);

            SoundManager.sM.welCome.Play();
            StartCoroutine(WantCoaster());
            StartCoroutine(HandPlease());
          


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {
            currTime = 0;
            infoCanvas.SetActive(false);

        }
    }

    IEnumerator WantCoaster()
    {
        yield return new WaitForSeconds(4f);
        SoundManager.sM.wantCoaster.Play();




    }

    IEnumerator HandPlease()
    {
        yield return new WaitForSeconds(8f);
        SoundManager.sM.handPlease.Play();
    }


}

