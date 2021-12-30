using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class SignIn_Rio : MonoBehaviour
{
    //FirebaseAuth auth;

    private void Start()
    {
        //�α��� ���� üũ �̺�Ʈ ���
        //auth = Database_Rio.instance.auth;
    }

    public GameObject SignINUI;

    public void SetActiveUI()
    {
        SignINUI.SetActive(!SignINUI.activeSelf);
    }

    //�Է°��� üũ�� ��
    public InputField Email;
    public InputField Password;
    public InputField Name;
    public InputField NickName;
    public InputField Age;
    public Toggle Toggle_M;
    public Toggle Toggle_W;

    //�Է°����� �� �������� Ȯ���ϴ� �Լ�
    public bool InputCheck()
    {
        return Email.text.Length == 0 || Password.text.Length == 0 || Name.text.Length == 0 || NickName.text.Length == 0 || Age.text.Length == 0 ? false : true;
    }

    //������ ���Է��ϰ� ������ư Ŭ���ϴ°�
    public void onClickSignInBTN()
    {
        //���� ��������� ���� �߻��ϰ� ������
        if (!InputCheck())
        {
            print("�Է��� ��Ȯ�ϰ� ���ּ���");
            return;
        }
        //�Է��� �������� ���� �����ϰ� �����ͺ��̽��� ���� �����ؾ��Ѵ�.
        else
        {
            StartCoroutine(SignIn(Email.text, Password.text));
           
        }
    }

    //ȸ������ �ڷ�ƾ �Լ�
    IEnumerator SignIn(string email, string password)
    {
        var task = Database_Rio.instance.auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => task.IsCompleted);
        if (task.Exception == null)
        {
            print("ȸ������ ����!!");
            //���� ���� �����ͺ��̽� �����ϴ� �Լ� ȣ��
            Database_Rio.instance.SaveUserInfo(Name.text, NickName.text, Age.text, Toggle_M.isOn ? "����" : "����");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("01_CustomScene");
        }
        else print("ȸ������ ����!!");
    }
}
