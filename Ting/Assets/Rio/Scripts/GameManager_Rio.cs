using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedPeopleSystem;

public class GameManager_Rio : MonoBehaviour
{

    public GameObject Man;
    public GameObject Woman;
    public GameObject Player;

    Database_Rio db;
    private void Start()
    {
        db = FindObjectOfType<Database_Rio>();
    }


    public IEnumerator UserInit()
    {

        yield return new WaitForSeconds(0.5f);

        //일단 서버에서 값을 읽어온다
        //Database_Rio.instance.LoadUserInfo(Database_Rio.instance.auth.CurrentUser.UserId);

        yield return new WaitForSeconds(3f);

        if (db.myInfo.characterCustomizationSetup.settingsName == "MaleSettings")
        {
            Player = Instantiate(Man);
        }
        else if (db.myInfo.characterCustomizationSetup.settingsName == "FemaleSettings")
        {
            Player = Instantiate(Woman);
        }

        Player.transform.position = Vector3.zero;
        db.UserSetting = Player.GetComponent<CharacterCustomization>();
        db.UserSetting.SetCharacterSetup(db.myInfo.characterCustomizationSetup);
    }
}