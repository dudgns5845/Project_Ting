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


            if (infoCanvas.activeSelf == true)
            {
                currTime += Time.deltaTime;
                if (currTime >= 4 && currTime < 8)
                {

                    tx.text = "프테라돈코스터에" + '\n' + "탑승하시겠습니까?";



                }
                else if (currTime >= 8)
                {
                    tx.text = "탑승을 원하신다면" + '\n' + "빛이 나는 곳에" + '\n' + "손을 갖다 대세요";




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

