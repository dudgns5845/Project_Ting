using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//공이 들어간 위치에 따라
//점수판에 점수 올라간다
//골인하는 위치에 따라 공이 리스폰 되는 위치를 지정한다

public class HockeyGoalLine : MonoBehaviour
{
    public static HockeyGoalLine hockeyGoalLine;


    public GameObject ballFactory;
    bool isLeftGoal; //왼쪽에 골 들어감
    bool isRightGoal; //오른쪽에 골 들어감
    public Transform leftBallPos;  //오른쪽에 골 들어갔을 때 왼쪽 pos에서 리스폰
    public Transform rightBallPos;  //왼쪽에 골 들어갔을 때 오른쪽 pos에서 리스폰

    public TextMeshProUGUI txtLeftScore;
    int leftScore;
    public TextMeshProUGUI txtRightScore;
    int rightScore;

    private void Awake()
    {
        if (hockeyGoalLine == null)
            hockeyGoalLine = this;
    }
    void Start()
    {
        txtLeftScore.text = "" + leftScore;
        txtRightScore.text = "" + rightScore;
    }

    void Update()
    {
        
    }
  



}
