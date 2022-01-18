using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint300 : MonoBehaviour
{
    public GameObject eftFactory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            GameObject eft = Instantiate(eftFactory);
            eft.transform.position = gameObject.transform.position;

            gameObject.SetActive(false);
            PointManager.pm.AddScore(300);
            print("300Á¡");
        }
    }

}
