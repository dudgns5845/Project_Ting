using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunTableManager : MonoBehaviour
{
    public static GunTableManager gunTableM;

    public GameObject startGunBtn;
   
    public GameObject exitGunBtn;

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
        pointM.SetActive(false);
        targetPatternM.SetActive(false);
        gun.SetActive(false);
        reloadObj.SetActive(false);
    }

    public void OnClickStartGun()
    {
        startGunBtn.SetActive(false);
        pointM.SetActive(true);
        targetPatternM.SetActive(true);
        gun.SetActive(true);
        reloadObj.SetActive(true);
        GameOnOff_SEJ.onoff.PlayGun();
    }
    public void OnClickExitGun()
    {
        pointM.SetActive(false);
        startGunBtn.SetActive(true);
        targetPatternM.SetActive(false);
        gun.SetActive(false);
        reloadObj.SetActive(false);
        GameOnOff_SEJ.onoff.Start();
    }

    void Update()
    {
        
    }
}
