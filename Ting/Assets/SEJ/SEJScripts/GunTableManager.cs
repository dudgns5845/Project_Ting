using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunTableManager : MonoBehaviour
{
    public static GunTableManager gunTableM;

    //public GameObject startGunBtn;
   
    //public GameObject exitGunBtn;

    public GameObject pointM;
    public GameObject targetPatternM;
    public GameObject gun;
    public GameObject reloadObj;

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


    //버튼 함수들
    //public void OnClickStartGun()
    //{

    //    pointM.SetActive(true);
    //    targetPatternM.SetActive(true);
    //    gun.SetActive(true);
    //    reloadObj.SetActive(true);
    //}
    //public void OnClickExitGun()
    //{

    //    pointM.SetActive(false);
    //    targetPatternM.SetActive(false);
    //    gun.SetActive(false);
    //    reloadObj.SetActive(false);
    //}

 
}
