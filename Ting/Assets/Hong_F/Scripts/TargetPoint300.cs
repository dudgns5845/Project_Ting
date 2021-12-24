using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint300 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            PointManager.pm.AddScore(300);
            print("300Á¡");
        }
    }

}
