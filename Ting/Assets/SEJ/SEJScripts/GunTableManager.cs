using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunTableManager : MonoBehaviour
{
    public static GunTableManager gunTableM;



    public GameObject pointM;
    public GameObject targetPatternM;
    public GameObject gun;
    public GameObject reloadObj;

    public GameObject reset;

    private void Awake()
    {
        if (gunTableM == null)
            gunTableM = this;
    }

    void Start()
    {
       
    }
    void Update()
    {
        Setting();
    }
    void Setting()
    {
        pointM.SetActive(true);
        targetPatternM.SetActive(true);
        gun.SetActive(true);
        reloadObj.SetActive(true);
    }

    public Transform[] resetPattern;
   public void OnClickResetGun()
    {
        
        print("���¹�ư");
        PointManager.pm.currScore = 0; //�������� �ʱ�ȭ
        PointManager.pm.Pstate = 0;

        for (int i =0; i<resetPattern.Length; i++)
        {
            for(int j=0; j< resetPattern[i].childCount; j++)
            {

                resetPattern[i].GetChild(j).gameObject.SetActive(false);
                resetPattern[i].GetChild(j).gameObject.SetActive(true);
            }
        }


        
            for (int j = 0; j < targetPattern.childCount; j++)
            {
                targetPattern.GetChild(j).gameObject.SetActive(false);
            targetPattern.GetChild(0).gameObject.SetActive(true);
            }
        

    }
      public  Transform targetPattern;
 
}
