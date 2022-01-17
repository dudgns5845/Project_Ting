using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGyro : MonoBehaviour
{
    public GameObject groDoor;
    Vector3 openDoorPos;
    Vector3 closeDoorPos;


    // Start is called before the first frame update
    void Start()
    {
        openDoorPos = groDoor.transform.localPosition + new Vector3(3.5f, 0, 0);
        closeDoorPos = groDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {

            groDoor.transform.localPosition = openDoorPos;
        }




    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {
            groDoor.transform.position = closeDoorPos;
        }
    }
}
