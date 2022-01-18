using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{

    PointManager pointM;
    public GameObject eftFactory;
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

            GameObject eft = Instantiate(eftFactory);
            eft.transform.position = gameObject.transform.position;

            gameObject.SetActive(false);    
            PointManager.pm.AddScore(100);
            print("100Á¡");
            pointM.objCount--;
            
        }
    }
}
