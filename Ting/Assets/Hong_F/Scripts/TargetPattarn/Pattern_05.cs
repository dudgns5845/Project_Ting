using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_05 : MonoBehaviour
{

    public GameObject[] Point100obj;
    public GameObject[] Point100obj_1;

    Vector3 pointPos_0;
    Vector3 pointPos_1;
    Vector3 pointPos_2;
    Vector3 pointPos_3;
    Vector3 pointPos_4;

    Vector3 pointPos_0_1;
    Vector3 pointPos_1_1;
    Vector3 pointPos_2_1;
    Vector3 pointPos_3_1;
    Vector3 pointPos_4_1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move100point();
        move100point_1();
    }

    void move100point()
    {
        pointPos_0 = Point100obj[0].transform.position;
        pointPos_1 = Point100obj[1].transform.position;
        pointPos_2 = Point100obj[2].transform.position;
        pointPos_3 = Point100obj[3].transform.position;
        pointPos_4 = Point100obj[4].transform.position;

        Vector3 v0 = pointPos_0;
        Vector3 v1 = pointPos_1;
        Vector3 v2 = pointPos_2;
        Vector3 v3 = pointPos_3;
        Vector3 v4 = pointPos_4;

        v0.z += 0.05f * Mathf.Sin(Time.time * 2);
        v1.z -= 0.05f * Mathf.Sin(Time.time * 2);
        v2.z += 0.05f * Mathf.Sin(Time.time * 2);
        v3.z -= 0.05f * Mathf.Sin(Time.time * 2);
        v4.z += 0.05f * Mathf.Sin(Time.time * 2);

        Point100obj[0].transform.position = v0;
        Point100obj[1].transform.position = v1;
        Point100obj[2].transform.position = v2;
        Point100obj[3].transform.position = v3;
        Point100obj[4].transform.position = v4;

    }

    void move100point_1()
    {
        pointPos_0_1 = Point100obj_1[0].transform.position;
        pointPos_1_1 = Point100obj_1[1].transform.position;
        pointPos_2_1 = Point100obj_1[2].transform.position;
        pointPos_3_1 = Point100obj_1[3].transform.position;
        pointPos_4_1 = Point100obj_1[4].transform.position;

        Vector3 v0 = pointPos_0_1;
        Vector3 v1 = pointPos_1_1;
        Vector3 v2 = pointPos_2_1;
        Vector3 v3 = pointPos_3_1;
        Vector3 v4 = pointPos_4_1;

        v0.z -= 0.05f * Mathf.Sin(Time.time * 2);
        v1.z += 0.05f * Mathf.Sin(Time.time * 2);
        v2.z -= 0.05f * Mathf.Sin(Time.time * 2);
        v3.z += 0.05f * Mathf.Sin(Time.time * 2);
        v4.z -= 0.05f * Mathf.Sin(Time.time * 2);

        Point100obj_1[0].transform.position = v0;
        Point100obj_1[1].transform.position = v1;
        Point100obj_1[2].transform.position = v2;
        Point100obj_1[3].transform.position = v3;
        Point100obj_1[4].transform.position = v4;
    }

    void Pattern05()
    {
        if (Point100obj[0].activeSelf == false &&
            Point100obj[1].activeSelf == false &&
            Point100obj[2].activeSelf == false &&
            Point100obj[3].activeSelf == false &&
            Point100obj[4].activeSelf == false &&
           Point100obj_1[0].activeSelf == false &&
           Point100obj_1[1].activeSelf == false &&
           Point100obj_1[2].activeSelf == false &&
           Point100obj_1[3].activeSelf == false &&
           Point100obj_1[4].activeSelf == false)
        {
            gameObject.SetActive(false);
        }

    }
}
