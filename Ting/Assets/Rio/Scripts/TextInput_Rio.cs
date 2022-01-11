using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextInput_Rio : MonoBehaviour, IPointerClickHandler
{
    public InputField inputField;
    public GameObject keyborad;

    public void OnPointerClick(PointerEventData eventData)
    {
        keyborad.SetActive(true);
        keyborad.GetComponent<Keyboard_Rio>().inputField = this.inputField;
        keyborad.GetComponent<Keyboard_Rio>().total_text = inputField.text;
    }

    //private void Start()
    //{
    //    EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();

    //    EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
    //    entry_PointerDown.eventID = EventTriggerType.PointerDown;
    //    entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
    //    eventTrigger.triggers.Add(entry_PointerDown);
    //}

    //void OnPointerDown(PointerEventData data)
    //{
    //    keyborad.SetActive(true);
    //}
}
