using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_02 : MonoBehaviour
{

    Vector3 movePosition;
    Vector3 point100pos_0;
    Vector3 point100pos_1;
    
    public GameObject[] point100;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Pattern2();

        if(transform.position == movePosition)
        {
        move100point();

        }
    }
    public void Pattern2()
    {
        movePosition = new Vector3(0, 3, 15);
        transform.position = Vector3.MoveTowards(transform.position, movePosition, 0.1f);

        if(point100[0].activeSelf == false &&
            point100[1].activeSelf == false&&
            point100[2])
        {
            gameObject.SetActive(false);
        }

        


    }

    void move100point()
    {

        point100pos_0 = point100[0].transform.position;
        point100pos_1 = point100[1].transform.position;

        Vector3 v0 = point100pos_0;
        Vector3 v1 = point100pos_1;
        v0.x += 0.05f * Mathf.Sin(Time.time * 2);
        v1.x -= 0.05f * Mathf.Sin(Time.time * 2);
        
        point100[0].transform.position = v0;
        point100[1].transform.position = v1;

      
    }
}
