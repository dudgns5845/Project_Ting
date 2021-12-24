using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//타이머 초단위가 0~59까지로 설정된 스크립트 복사

public class Countdown_SEJ : MonoBehaviour
{
    //public string m_Timer = @"00:00:00.000";
    public string m_Timer = @"00:00";
    public KeyCode m_KcdPlay = KeyCode.Space;
    private bool m_IsPlaying;
    float m_TotalSeconds = 30 * 60; // 카운트 다운 전체 초(5분 X 60초), 인스펙트 창에서 수정해야 함. 
    
    public TextMeshProUGUI m_Text;

    private void Start()
    {
        m_Timer = CountdownTimer(false); // Text에 초기값을 넣어 주기 위해
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

        // m_TotalSeconds이 줄어들때, 완전히 0에 맞출수 없기 때문에  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
            //... 여기에 카운트 다운이 종료 될때 [이벤트]를 넣으면 됩니다. 
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