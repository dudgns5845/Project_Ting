using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

// UI와 종업원 캐릭터를 동기화시켜 같이 볼 수 있도록 한다

public class SEJMeetingGM : MonoBehaviourPunCallbacks
{
    public static SEJMeetingGM gm;


    //처음에 뜨는 메세지
    public GameObject startUI;
    public TextMeshProUGUI startMSG;

    //버튼 UI 손목시계처럼 위치 손등에 자식으로 넣어버릴것
    public GameObject buttonUI;

    //컨텐츠 상자 안에 텍스트 관련 UI 
    public GameObject contentsTextBox; //텍스트를 담은 빈오브젝트임
    public TextMeshProUGUI contentMSG;
    //public GameObject contentsText; 
    //public TextMeshProUGUI questionMSG;
    //ContentsTxt(TMP)
    public GameObject contBox; //콘텐츠창

    public GameObject rightBtn; //다음 페이지로 넘기는 화살표

    public Button balanceBtn;
    public bool bbb; //밸런스버튼 눌림 여부
    public Button questionBtn;
    public bool qqq; //질문지버튼 눌림 여부

    public GameObject button;  // 말풍선 버튼을 둘다 담아준 빈 오브젝트

    //말풍선 버튼
    public GameObject BmenuBtn;
    public GameObject QmenuBtn;
    public bool startUI_ing;
    public bool contUI_ing;

    //나의 포톤 View ID
    public PhotonView myPhotonView;
    public Transform[] PlayerPos; //플레이어 생성할 위치들
    int playerPosIndex; //생선된 플레이어 순서 위치


 
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            CreatePlayer();
        }
        else
        {
            PhotonNetwork.GameVersion = "1"; 
            PhotonNetwork.ConnectUsingSettings(); // name서버에서 master서버로  
        }

        startUI.SetActive(true);
        startUI_ing = true;
        contentsTextBox.SetActive(false);
        contUI_ing = false;
        contBox.SetActive(false);
        //무의식적으로 화면에 뜬 글을 읽었을 때 따듯함이 느껴지는 좋은 인삿말 위주로 설정하기
        //자기소개를 먼저시키기
        startMSG.text = "축하드립니다, 매칭되었습니다" + '\n' + " 소중한 인연과 대화를 나눠보세요!" + '\n' + "매너를 지켜주세요 (•ᴗ-)";

        StartCoroutine(NextText());
        StartCoroutine(ColorRenderer(11f));

    }

    private void CreatePlayer()
    {
        PhotonNetwork.SendRate = 50;
        PhotonNetwork.SerializationRate = 50;
        //나의 플레이어 생성
        //Vector3 pos = new Vector3()


    }
    public void SetPlayerPos(PhotonView pv)
    {

    }

    IEnumerator NextText()
    {
        yield return new WaitForSeconds(6f);
        startMSG.text = "대화는 30분으로 제한됩니다" + '\n' + "궁금하신 점이 있다면 상단에 \"?\"를 눌러주세요";
    }
    IEnumerator ColorRenderer(float time)
    {
        yield return new WaitForSeconds(time);
        //startBg.enabled = false;
        //startMSG.enabled = false;
        startUI.SetActive(false);
        startUI_ing = false;
    }

    //밸런스게임 컨텐츠
    public List<string> balanceList = new List<string>();


    public bool balanceFinish;

    public void BalanceList()
    {
        //contentsBox.SetActive(true);
        contUI_ing = true;

        balanceList.Add("10년 사귀었던 애인과 친구가 된 애인" + '\n' + "VS" + '\n' + "10년지기 이성친구 있는 애인");
        balanceList.Add("집착하는 애인(1분이라도 연락이 끊기면 안됨)" + '\n' + "VS" + '\n' + "무관심한 애인(일주일 이상 연락 안돼도 신경안씀)");
        balanceList.Add("전 애인의 친구와 사귀기" + '\n' + "VS" + '\n' + "친구 전 애인과 사귀기");
        balanceList.Add("내 원수와 바람 난 애인" + '\n' + "VS" + '\n' + "내 절친과 바람 난 애인");
        balanceList.Add("싸우면 풀릴 때 까지 대화 요구하는 애인" + '\n' + "VS" + '\n' + "싸우면 연락두절 애인");
        balanceList.Add("내가 좋아하는 사람" + '\n' + "VS" + '\n' + "나를 좋아하는 사람");
        balanceList.Add("입만 열면 거짓말 하는 애인" + '\n' + "VS" + '\n' + "바람피는 애인");
        balanceList.Add("내 애인 집에 친구 속옷 발견" + '\n' + "VS" + '\n' + "내 친구집에 애인 속옷 발견");
        balanceList.Add("밖에서 손도 안잡는 애인" + '\n' + "VS" + '\n' + "공공장소에서 애정표현하는 애인");
        balanceList.Add("연애 경력이 많아서 센스있는 애인" + '\n' + "VS" + '\n' + "연애 경력이 없어서 순수한 애인");
        balanceList.Add("바람핀 걸 자백하고 용서를 구하는 애인" + '\n' + "VS" + '\n' + "바람핀 걸 평생 비밀로 하는 애인");
        balanceList.Add("월 200만원 백수" + '\n' + "VS" + '\n' + "월 600만원 직장인");
        balanceList.Add("내가 원하는 얼굴과 몸매로 살기" + '\n' + "VS" + '\n' + "10억 받기");
        balanceList.Add("좋아하는 사람이 날 싫어하기" + '\n' + "VS" + '\n' + "싫어하는 사람이 날 좋아하기");
        balanceList.Add("고양이 키우기" + '\n' + "VS" + '\n' + "강아지 키우기");


        if (balanceList.Count == 0)
        {
            balanceFinish = true;
        }
        else
        {
            balanceFinish = false;
        }
    }

    public List<string> Quation = new List<string>();

    public bool questionFinish;
    public void QuationList()
    {
        Quation.Add("취미 및 관심사가 무엇인가요?");
        Quation.Add("당신이 즐겨보는 유튜브 or 좋아하는 유튜버는?");
        Quation.Add("당신의 MBTI는?");
        Quation.Add("반려동물을 키우시나요?");
        Quation.Add("주량은 얼마나 되시나요?");
        Quation.Add("닮은 꼴이 있나요?");
        Quation.Add("이상형이 있나요?");
        Quation.Add("당신의 인생 영화 or 드라마는?");
        Quation.Add("요리실력은 어느정도인가요?");
        Quation.Add("실제로 만나게 된다면 하고싶은 것은 무엇인가요?");
        Quation.Add("자기 여행했던 곳 중 추천하고 싶은 여행지는?");
        Quation.Add("애인이 생긴다면 가고싶은 명소는?");
        Quation.Add("본인의 음악 재생 목록을 말해주세요!");


        if (Quation.Count == 0)
        {
            questionFinish = true;
        }
        else
        {
            questionFinish = false;
        }
    }

}
