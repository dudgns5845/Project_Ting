using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirebaseAuth_Rio : MonoBehaviour
{
    FirebaseAuth auth;

    //email, pssword inpufield
    public InputField inputEmail;
    public InputField inputpassword;

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

    //ȸ�� ����
    public void onClickSignIn()
    {
        StartCoroutine(SignIn(inputEmail.text, inputpassword.text));
    }

    IEnumerator SignIn(string email, string password)
    {
        var task = auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception == null)
        {
            TXT_Result.text = "ȸ������ ����!!";

            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("01_CustomScene");
        }


        else
        {
            TXT_Result.text = "ȸ������ ����!!";
        }
    }


    //�α��� 
    public void onClickLogIn()
    {
        if (inputEmail.text.Length == 0 || inputEmail.text.Length == 0)
        {
            TXT_Result.text = "������ �� �Է����ּ���!!";
            return;
        }

        StartCoroutine(Login(inputEmail.text, inputpassword.text));
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
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("01_CustomScene");
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
