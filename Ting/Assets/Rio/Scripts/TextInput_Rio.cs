using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextInput_Rio : MonoBehaviour, IPointerClickHandler
{
    InputField inputField;
    public GameObject keyborad;

    private void Start()
    {
        inputField = GetComponent<InputField>();
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //키보드 활성화
        keyborad.SetActive(!keyborad.activeSelf);
        //할당해주고
        keyborad.GetComponentInParent<VirtualKeyboard>().TextInputBox = GetComponent<VirtualTextInputBox>();
  
    }
}
