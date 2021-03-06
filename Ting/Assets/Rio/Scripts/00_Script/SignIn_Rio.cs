using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class SignIn_Rio : MonoBehaviour
{
    //FirebaseAuth auth;
    Database_Rio db;
    private void Start()
    {
        //로그인 상태 체크 이벤트 등록
        //auth = Database_Rio.instance.auth;
        db = FindObjectOfType<Database_Rio>();
    }

    public GameObject SignINUI;

    public void SetActiveUI()
    {
        SignINUI.SetActive(!SignINUI.activeSelf);
    }

    //입력값들 체크할 것
    public InputField Email;
    public InputField Password;
    public InputField Name;
    public InputField NickName;
    public InputField Age;
    public Toggle Toggle_M;
    public Toggle Toggle_W;

    //입력값들이 잘 들어가졌는지 확인하는 함수
    public bool InputCheck()
    {
        return Email.text.Length == 0 || Password.text.Length == 0 || Name.text.Length == 0 || NickName.text.Length == 0 || Age.text.Length == 0 ? false : true;
    }

    //값들을 다입력하고 생성버튼 클릭하는것
    public void onClickSignInBTN()
    {
        //값이 비어있으면 에러 발생하고 끝내기
        if (!InputCheck())
        {
            GetComponent<AudioSource>().PlayOneShot(sfx_fail);
            TXT_Result.color = new Color(255, 0, 0);
            TXT_Result.text = "입력을 정확하게 해주세요";
            print("입력을 정확하게 해주세요");
            return;
        }
        //입력을 잘했으면 계정 생성하고 데이터베이스에 값을 저장해야한다.
        else
        {
            StartCoroutine(SignIn(Email.text, Password.text));

        }
    }

    public AudioClip sfx_sucess;
    public AudioClip sfx_fail;
    public Text TXT_Result;
    //회원가입 코루틴 함수
    IEnumerator SignIn(string email, string password)
    {
        var task = db.auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => task.IsCompleted);
        if (task.Exception == null)
        {
            GetComponent<AudioSource>().PlayOneShot(sfx_sucess);
            TXT_Result.color = new Color(0, 0, 255);
            TXT_Result.text = "회원가입 성공!!";
            print("회원가입 성공!!");
            //유저 정보 데이터베이스 저장하는 함수 호출
            db.SaveUserInfo(Name.text, NickName.text, Age.text, Toggle_M.isOn ? "남성" : "여성");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("01_CustomScene_VR");
        }
        else
        {
            print("회원가입 실패!!");
            GetComponent<AudioSource>().PlayOneShot(sfx_fail);
            TXT_Result.color = new Color(255, 0, 0);
            TXT_Result.text = "회원가입 실패!!";
        }
    }
}