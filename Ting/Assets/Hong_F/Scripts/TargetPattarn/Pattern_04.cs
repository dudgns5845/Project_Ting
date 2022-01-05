using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_04 : MonoBehaviour
{

    public GameObject Center100point;
    public GameObject Center100point_1;
    public GameObject Point300;
    public GameObject point500;

    public GameObject[] p4obj;

    Quaternion rotaValue = Quaternion.Euler(0, 0, 90);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        centerRotate();
        Point500();
        Pattern04();
    }

    void centerRotate()
    {

        Center100point.transform.Rotate(0, 0, 90 * Time.deltaTime * 1);
        Center100point_1.transform.Rotate(0, 0, -90 * Time.deltaTime * 1);

    }

    void Point500()
    {
        if (Point300.activeSelf == false)
        {
            point500.SetActive(true);
        }
    }

    void Pattern04()
    {
        if (p4obj[0].activeSelf == false &&
            p4obj[1].activeSelf == false &&
            p4obj[2].activeSelf == false &&
            p4obj[3].activeSelf == false &&
            p4obj[4].activeSelf == false &&
            p4obj[5].activeSelf == false &&
            p4obj[6].activeSelf == false &&
            p4obj[7].activeSelf == false &&
            p4obj[8].activeSelf == false &&
            p4obj[9].activeSelf == false &&
            p4obj[10].activeSelf == false &&
            p4obj[11].activeSelf == false 
          )
        {
            gameObject.SetActive(false);
        }
    }


}
