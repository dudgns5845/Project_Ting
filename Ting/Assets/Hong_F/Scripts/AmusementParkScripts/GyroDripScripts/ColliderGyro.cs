using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGyro : MonoBehaviour
{
    public GameObject groDoor;
    Vector3 openDoorPos;
    Vector3 closeDoorPos;

    public AudioSource doorSound;


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
            // rollDoor.transform.localPosition = openDoorPos;

            groDoor.transform.localPosition = Vector3.MoveTowards(groDoor.transform.localPosition, openDoorPos, 3 * Time.deltaTime);
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        doorSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player")
        {
            //  rollDoor.transform.position = closeDoorPos;

            groDoor.transform.localPosition = Vector3.MoveTowards(openDoorPos, closeDoorPos, 3 * Time.deltaTime);
            doorSound.Play();



        }
    }
}
