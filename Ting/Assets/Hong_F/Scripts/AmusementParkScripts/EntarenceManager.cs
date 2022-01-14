using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntarenceManager : MonoBehaviour
{
    public GameObject rollDoor;
    Vector3 openDoorPos;
    Vector3 closeDoorPos;


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
        if (other.gameObject.name == "Auto Hand Player")
        {
            rollDoor.transform.localPosition = openDoorPos;
        }
        



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {
            rollDoor.transform.position = closeDoorPos;
        }
    }
}
