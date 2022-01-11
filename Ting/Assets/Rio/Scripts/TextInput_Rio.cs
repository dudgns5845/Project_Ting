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
        //Ű���� Ȱ��ȭ
        keyborad.SetActive(!keyborad.activeSelf);
        //�Ҵ����ְ�
        keyborad.GetComponentInParent<VirtualKeyboard>().TextInputBox = GetComponent<VirtualTextInputBox>();
  
    }
}
