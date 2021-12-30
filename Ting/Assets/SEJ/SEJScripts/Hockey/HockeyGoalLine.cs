using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//���� �� ��ġ�� ����
//�����ǿ� ���� �ö󰣴�
//�����ϴ� ��ġ�� ���� ���� ������ �Ǵ� ��ġ�� �����Ѵ�

public class HockeyGoalLine : MonoBehaviour
{
    public static HockeyGoalLine hockeyGoalLine;


    public GameObject ballFactory;
    bool isLeftGoal; //���ʿ� �� ��
    bool isRightGoal; //�����ʿ� �� ��
    public Transform leftBallPos;  //�����ʿ� �� ���� �� ���� pos���� ������
    public Transform rightBallPos;  //���ʿ� �� ���� �� ������ pos���� ������

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
