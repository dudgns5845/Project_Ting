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
        //로그인 상태 체크 이벤트 등록
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += onChangedAuthState;
    }

    //게임오브젝트 파괴될때 호출
    private void OnDestroy()
    {
        auth.StateChanged -= onChangedAuthState;
    }

    //이벤트 핸들러
    void onChangedAuthState(object sender, EventArgs e)
    {
        //만약 유저정보 있으면
        if (auth.CurrentUser != null)
            print("로그인 상태");
        //그렇지 않으면
        else
            print("비로그인 상태");
    }

    //회원 가입
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
            TXT_Result.text = "회원가입 성공!!";

            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("01_CustomScene");
        }


        else
        {
            TXT_Result.text = "회원가입 실패!!";
        }
    }


    //로그인 
    public void onClickLogIn()
    {
        if (inputEmail.text.Length == 0 || inputEmail.text.Length == 0)
        {
            TXT_Result.text = "정보를 다 입력해주세요!!";
            return;
        }

        StartCoroutine(Login(inputEmail.text, inputpassword.text));
    }

    IEnumerator Login(string email, string password)
    {
        //로그인 시도
        var task = auth.SignInWithEmailAndPasswordAsync(email, password);
        //통신이 완료될때까지 기다린다
        yield return new WaitUntil(() => task.IsCompleted);

        //만약에 에러가 없다면
        if (task.Exception == null)
        {
            TXT_Result.text = "로그인 성공!!";
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("01_CustomScene");
        }
        else //로그인 실패 로그 출력
        {
            TXT_Result.text = "로그인 실패!! ";
        }
    }

    //로그아웃
    public void onClickLogOut()
    {
        auth.SignOut();
    }
}
