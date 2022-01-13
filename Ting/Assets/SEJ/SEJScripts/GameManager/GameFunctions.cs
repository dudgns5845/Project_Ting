using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFunctions : MonoBehaviour
{
    //모두 리지드바디가 필요함 (이미 들어가 있음)
    Rigidbody rb;

    #region 하키게임용 변수들
    public Transform stickPos;
    public Transform stick2Pos;

    #endregion
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    public void ReleaseStick() //에어하키
    {
        //스틱 놓았을 때 원래 위치로
        if (gameObject.name == "Stick")
            gameObject.transform.position = stickPos.position; //내가 잡은 스틱이 Stick1 일 때 놓았을 때 이 위치로

        else if (gameObject.name == "Stick2")
            gameObject.transform.position = stick2Pos.position; //내가 잡은 스틱이 Stick2 일 때 놓았을 때 이 위치로
    }


    #region 다트게임용 변수들
    public bool isTouch;
    float forceWithTime; // 오래 잡고 있을수록 힘이 커진다
    public float forceAdg = 2; //힘조절
    public float forceMax = 50; //최대 힘
    SEJDarts dart;
    #endregion
    public void GripDart() //잡고 있는 동안 힘의 크기 증가
    {
        if (gameObject.CompareTag("Dart"))
        {
            print("다트 잡았다");

            //gameObject.GetComponentInChildren<MeshRenderer>().transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
            //gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
            if(gameObject!=null)
            {
                print("다트잡힌상태");
                forceWithTime += forceMax * Time.deltaTime * forceAdg;
            }
        }
    }
    public Transform rayOrigin;
    public void ThrowDart() //release할 때 다트 날아가도록
    {
        print("다트 던졌다");
        if (gameObject != null)
        {
            print(gameObject.name);

            forceWithTime = Mathf.Clamp(forceWithTime, 5, forceMax);
            gameObject.GetComponent<SEJDarts>().Shooting(forceWithTime);


        }
        if(gameObject ==null)
        {
            Ray ray = new Ray(rayOrigin.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                SEJBoardPiece boardPiece = hitInfo.collider.GetComponent<SEJBoardPiece>();
                if (boardPiece != null)
                {
                    print(boardPiece.name);
                    isTouch = true;
                    SetMyChildren(boardPiece.transform);

                    transform.position = hitInfo.point + transform.forward * 0.25f;

                    // 다트가 보드조각에 부딪혔을때 보드조각의 본체인 보드에게 점수정보를 넘겨주고싶다.
                    boardPiece.AddScorePlz(gameObject.GetComponent<SEJDarts>());
                }
            }
        }
      

    }
    public void SetMyChildren(Transform parent)
    {
        
        isTouch = true;
        rb.useGravity = false; //중력제거
        rb.isKinematic = true; //회전제거
        // 충돌체도 끈다
        // 내 부모 = 너
    }

    #region 총게임용 변수들
    public bool isGrip;
    public int MaxCount;
    public GameObject bulletFactory;
    public GameObject gunHole;
    public Text bulletText;
    public Transform Tracker;
    public Transform point; //총이 돌아갈 위치
    #endregion

    public void Shoot() //총 Advanced Events에 들어갈 함수
    {
        print("총알 발사");
        if (0 < MaxCount)
        {
            print("총알 발사");
            GameObject Bullet = Instantiate(bulletFactory);
            Bullet.transform.position = gunHole.transform.position;
            Bullet.transform.rotation = gunHole.transform.rotation;
            Destroy(Bullet, 5);
            MaxCount--;
        }
        else
        {
            return;
        }

        if (MaxCount <= 0)
        {
            print("총알없음");
            MaxCount = 0;
        }
        string countS = MaxCount.ToString();
        bulletText.text = countS;
    }
    public void GripGun()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(196.343f, 90, 180));
    }
    public void ReleaseGun() //총 놨을 때 제자리로
    {
        if (gameObject.name == "Gun")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(respwanGun());
        }
    }
    IEnumerator respwanGun()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = point.position;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(180, 180, 90));
    }
}
