using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// �α��� ȭ�� �κ��� ����ϴ� ��ũ��Ʈ 
/// </summary>
public class LogIn_Rio : MonoBehaviour
{
    FirebaseAuth auth;

    //�̸��� �н����� InputField
    public InputField inputEmail;
    public InputField inputPassword;


    //�α��� �õ� ��� �ؽ�Ʈ
    public Text TXT_Result;

    private void Start()
    {
        //�α��� ���� üũ �̺�Ʈ ���
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += onChangedAuthState;
    }

    //���ӿ�����Ʈ �ı��ɶ� ȣ��
    private void OnDestroy()
    {
        auth.StateChanged -= onChangedAuthState;
    }

    //�̺�Ʈ �ڵ鷯
    void onChangedAuthState(object sender, EventArgs e)
    {
        //���� �������� ������
        if (auth.CurrentUser != null)
            print("�α��� ����");
        //�׷��� ������
        else
            print("��α��� ����");
    }

    //�α��� �ϱ�
    public void onClickLogIn()
    {
        if (inputEmail.text.Length == 0 || inputEmail.text.Length == 0)
        {
            TXT_Result.text = "������ �� �Է����ּ���!!";
            return;
        }
        else
        {
            StartCoroutine(Login(inputEmail.text, inputPassword.text));
        }

    }


    IEnumerator Login(string email, string password)
    {
        //�α��� �õ�
        var task = auth.SignInWithEmailAndPasswordAsync(email, password);
        //����� �Ϸ�ɶ����� ��ٸ���
        yield return new WaitUntil(() => task.IsCompleted);

        //���࿡ ������ ���ٸ�
        if (task.Exception == null)
        {
            TXT_Result.text = "�α��� ����!!";
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("01_CustomScene_VR");
        }
        else //�α��� ���� �α� ���
        {
            TXT_Result.text = "�α��� ����!! ";
        }
    }

    //�α׾ƿ�
    public void onClickLogOut()
    {
        auth.SignOut();
    }
}
