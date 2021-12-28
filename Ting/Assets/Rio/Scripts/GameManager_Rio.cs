using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedPeopleSystem;

public class GameManager_Rio : MonoBehaviour
{

    public GameObject Man;
    public GameObject Woman;
    public GameObject Player;

   
    public IEnumerator UserInit()
    {

        yield return new WaitForSeconds(0.5f);

        //일단 서버에서 값을 읽어온다
        //Database_Rio.instance.LoadUserInfo(Database_Rio.instance.auth.CurrentUser.UserId);

        yield return new WaitForSeconds(3f);

        if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "MaleSettings")
        {
            Player = Instantiate(Man);
        }
        else if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "FemaleSettings")
        {
            Player = Instantiate(Woman);
        }

        Player.transform.position = Vector3.zero;
        Database_Rio.instance.UserSetting = Player.GetComponent<CharacterCustomization>();
        Database_Rio.instance.UserSetting.SetCharacterSetup(Database_Rio.instance.myInfo.characterCustomizationSetup);
    }
}