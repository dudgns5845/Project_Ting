using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedPeopleSystem;
public class GameManager_Rio : MonoBehaviour
{
    //public GameObject Man;
    //public GameObject Woman;
    //public bool isMan;

    //GameObject Player;
    //CharacterCustomization cc;


    //private void Start()
    //{
    //    this.isMan = FindObjectOfType<CustomInfo_Rio>().GetComponent<CustomInfo_Rio>().isMan;

    //    if (this.isMan)
    //    {
    //        Player = Instantiate(Man);
    //        Player.transform.position = Vector3.zero;
    //        cc = Player.GetComponent<CharacterCustomization>();
    //        var saves = cc.GetSavedCharacterDatas();
    //        cc.ApplySavedCharacterData(saves[0]);
    //    }

    //    if (!this.isMan)
    //    {
    //        Player = Instantiate(Woman);
    //        Player.transform.position = Vector3.zero;
    //        cc = Player.GetComponent<CharacterCustomization>();
    //        var saves = cc.GetSavedCharacterDatas();
    //        cc.ApplySavedCharacterData(saves[0]);
    //    }

    //    Destroy(FindObjectOfType<CustomInfo_Rio>().gameObject);
    //}


    public GameObject Man;
    public GameObject Woman;
    public GameObject Player;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        //일단 서버에서 값을 읽어온다
        Database_Rio.instance.LoadUserInfo();
        yield return new WaitForSeconds(1f);

        if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "MaleSettings")
        {
        
            print("나 실행한다...");
            Player = Instantiate(Man);
            Player.transform.position = Vector3.zero;
            Database_Rio.instance.UserSetting = Man.GetComponent<CharacterCustomization>();
            yield return new WaitForSeconds(1f);

            Database_Rio.instance.UserSetting.SetCharacterSetup(Database_Rio.instance.myInfo.characterCustomizationSetup);
        }
        else if (Database_Rio.instance.myInfo.characterCustomizationSetup.settingsName == "FemaleSettings")
        {
            Player = Instantiate(Woman);
            Player.transform.position = Vector3.zero;
            Database_Rio.instance.UserSetting = Man.GetComponent<CharacterCustomization>();
            Database_Rio.instance.UserSetting.SetCharacterSetup(Database_Rio.instance.myInfo.characterCustomizationSetup);
        }
    }
}