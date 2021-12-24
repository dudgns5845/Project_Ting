using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//Ÿ�̸� �ʴ����� 0~59������ ������ ��ũ��Ʈ ����

public class Countdown_SEJ : MonoBehaviour
{
    //public string m_Timer = @"00:00:00.000";
    public string m_Timer = @"00:00";
    public KeyCode m_KcdPlay = KeyCode.Space;
    private bool m_IsPlaying;
    float m_TotalSeconds = 30 * 60; // ī��Ʈ �ٿ� ��ü ��(5�� X 60��), �ν���Ʈ â���� �����ؾ� ��. 
    
    public TextMeshProUGUI m_Text;

    private void Start()
    {
        m_Timer = CountdownTimer(false); // Text�� �ʱⰪ�� �־� �ֱ� ����
        m_IsPlaying = true;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(m_KcdPlay))
        //    m_IsPlaying = !m_IsPlaying;

        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
        }

        // m_TotalSeconds�� �پ�鶧, ������ 0�� ����� ���� ������  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
            //... ���⿡ ī��Ʈ �ٿ��� ���� �ɶ� [�̺�Ʈ]�� ������ �˴ϴ�. 
        }
        
        if (m_Text)
            m_Text.text = m_Timer;
    }

    private string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}",
             timespan.Minutes, timespan.Seconds);

        return timer;
    }

    private void SetZero()
    {
        m_Timer = @"00:00";
        m_TotalSeconds = 0;
        m_IsPlaying = false;
    }
}