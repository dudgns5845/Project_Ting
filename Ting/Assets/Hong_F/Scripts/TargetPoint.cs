using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{

    PointManager pointM;
    // Start is called before the first frame update
    void Start()
    {
        pointM = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            PointManager.pm.AddScore(100);
            print("100Á¡");
            pointM.objCount--;
            

            
        }
    }
}
