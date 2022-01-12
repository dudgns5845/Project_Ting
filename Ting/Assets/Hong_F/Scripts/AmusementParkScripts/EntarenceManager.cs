using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntarenceManager : MonoBehaviour
{
    public GameObject rollDoor;
    Vector3 openDoorPos;
    Vector3 closeDoorPos;


    public Collider[] cols;
    // Start is called before the first frame update
    void Start()
    {
        openDoorPos = rollDoor.transform.localPosition + new Vector3(3.5f, 0, 0);
        closeDoorPos = rollDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            rollDoor.transform.localPosition = openDoorPos;
        }
        else
        {
            rollDoor.transform.position = closeDoorPos;
        }



    }
}
