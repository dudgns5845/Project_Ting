using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keyboard_Rio : MonoBehaviour
{
    public InputField inputField;

    public string total_text;

    public void input_char(string input)
    {
        if (input.Equals("delete"))
        {
            //문자 길이가 0보다 같거나 작으면 ""을 반환 크면 뒷문자 제거
            total_text = total_text.Length <= 0 ? "" : total_text.Substring(0, total_text.Length - 1);
            //텍스트 필드에 입력
            inputField.text = total_text;
        }
        else if (input == "enter")
        {
            total_text = "";
            gameObject.SetActive(false);
        }
        else
        {
            total_text += input;
            //텍스트 필드에 입력
            inputField.text = total_text;
        }
    }


}
