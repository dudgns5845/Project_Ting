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
        keyborad = GameObject.Find("keyboard");

        keyborad.SetActive(true);
        keyborad.GetComponent<Keyboard_Rio>().inputField = this.inputField;
        keyborad.GetComponent<Keyboard_Rio>().total_text = inputField.text;
    }
}
