using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// 로그인 화면 부분을 담당하는 스크립트 
/// </summary>
public class LogIn_Rio : MonoBehaviour
{
    FirebaseAuth auth;

    //이메일 패스워드 InputField
    public InputField inputEmail;
    public InputField inputPassword;


    //로그인 시도 결과 텍스트
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

    //로그인 하기
    public void onClickLogIn()
    {
        if (inputEmail.text.Length == 0 || inputEmail.text.Length == 0)
        {
            TXT_Result.text = "정보를 다 입력해주세요!!";
            return;
        }
        else
        {
            StartCoroutine(Login(inputEmail.text, inputPassword.text));
        }

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
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("01_CustomScene_VR");
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
