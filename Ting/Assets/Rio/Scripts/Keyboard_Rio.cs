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
            //���� ���̰� 0���� ���ų� ������ ""�� ��ȯ ũ�� �޹��� ����
            total_text = total_text.Length <= 0 ? "" : total_text.Substring(0, total_text.Length - 1);
            //�ؽ�Ʈ �ʵ忡 �Է�
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
            //�ؽ�Ʈ �ʵ忡 �Է�
            inputField.text = total_text;
        }
    }


}
