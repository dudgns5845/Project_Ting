using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

//골이 먹히면 내 진영에 공이 나타난다

public class HockeyFail : MonoBehaviourPun
{
    public GameObject ballFactory;
    bool isFail;
    public Transform mine; //공 나오는 위치가 나의 진영

    public TextMeshProUGUI txtYourScore;
    public int yourScore;

    private void Start()
    {
        txtYourScore.text = " " + yourScore;
    }
    void Update()
    {
        if (isFail == true)
        {
            MakeMyBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            yourScore += 1;
            txtYourScore.text = "" + yourScore;
            print("상대팀 득점");
            other.gameObject.SetActive(false);
            isFail = true;
        }
    }
    void MakeMyBall()
    {
        GameObject ballObj = Instantiate(ballFactory);
        ballObj.transform.position = mine.position;
        ballObj.SetActive(true);

        //계속 공이 생성되면 안되니까
        isFail = false;
    }
}
