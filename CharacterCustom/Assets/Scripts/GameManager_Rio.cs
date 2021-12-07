using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedPeopleSystem;
public class GameManager_Rio : MonoBehaviour
{
    public GameObject Man;
    public GameObject Woman;
    public bool isMan;

    GameObject Player;
    CharacterCustomization cc;

    
    private void Start()
    {
        this.isMan = FindObjectOfType<CustomInfo_Rio>().GetComponent<CustomInfo_Rio>().isMan;

        if (this.isMan)
        {
            Player = Instantiate(Man);
            Player.transform.position = Vector3.zero;
            cc = Player.GetComponent<CharacterCustomization>();
            var saves = cc.GetSavedCharacterDatas();
            cc.ApplySavedCharacterData(saves[0]);
        }

        if (!this.isMan)
        {
            Player = Instantiate(Woman);
            Player.transform.position = Vector3.zero;
            cc = Player.GetComponent<CharacterCustomization>();
            var saves = cc.GetSavedCharacterDatas();
            cc.ApplySavedCharacterData(saves[0]);
        }

        Destroy(FindObjectOfType<CustomInfo_Rio>().gameObject);
    }
}