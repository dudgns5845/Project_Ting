using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.name == "Tip") //�ճ��� ���� �����
            //if (other.gameObject.name == "Player") //�ճ��� ���� �����
        {
            if (gameObject.name == "HockeyFloors" )
            {
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isAirHokey = true;
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isDart = false;
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isGun = false;
            }

            if (gameObject.name == "DartFloors" )
            {
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isDart = true;
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isAirHokey = false;
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isGun = false;

            }

            if (gameObject.name == "GunFloors" )
            {
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isGun = true;
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isDart = false;
                other.gameObject.GetComponentInParent<GamePlayerController_SEJ>().isAirHokey = false;
            }
        }

    }
}
