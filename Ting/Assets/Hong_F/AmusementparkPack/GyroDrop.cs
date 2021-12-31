using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GyroDrop : MonoBehaviour
{

    public float upSpeed = 2f;
    public float downSpeed = 15f;
    public float rotaSpeed = 4f;


    public bool upMove;
    public bool downMove;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GyodropPlay();
    }

    void GyodropPlay()
    {
        CenterUPMove();
        CenterDownMove();

        
    }


    void CenterUPMove()
    {
        if (upMove == true)
        {
            // �������� �ö󰥶�~
            if (transform.localPosition.y <= 10f)
            {
                transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
                transform.Rotate(new Vector3(0, rotaSpeed * Time.deltaTime, 0));
                
            }
            else
            {
                StartCoroutine(CenterDownDelay());

            }
        }

    }

    void CenterDownMove()
    {
        if (downMove == true)
        {
            if (transform.localPosition.y >= -75f)
            {
                transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
            }
            else
            {
                downMove = false;
            }
          
            
        }
    }

    IEnumerator CenterDownDelay()
    {
        yield return new WaitForSeconds(2f);
        downMove = true;
        upMove = false;
        print(" �������ϴ�");


    }
}
