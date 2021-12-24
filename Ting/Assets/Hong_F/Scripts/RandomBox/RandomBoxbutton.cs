using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBoxbutton : MonoBehaviour
{

    public Animator anim;
    int rand;

    public Text test;


    public List<string> Quation = new List<string>();

    List<int> Quation2 = new List<int>();
    // Start is called before the first frame update
    void Start()
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



    }

    // Update is called once per frame
    void Update()
    {
        CameraRay();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            rand = Random.Range(0, Quation.Count);
            print(Quation[rand]);
            Quation.RemoveAt(rand);
            test.text = Quation[rand];

        }




    }

    void CameraRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo,100, 1 << LayerMask.NameToLayer("Button")))
            {

                if (Quation.Count == 0)
                {
                    test.text = "모든 질문지를 사용하셨습니다.";
                    return;
                }

                rand = Random.Range(0, Quation.Count);
                anim.SetTrigger("ButtonClick");
                print(Quation[rand]);
                test.text = Quation[rand];
                Quation.RemoveAt(rand);

            }
           

        }


    }




}
