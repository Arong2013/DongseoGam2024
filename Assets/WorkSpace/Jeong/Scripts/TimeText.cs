using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Update()
    {
        // TimeManager에서 분과 초 가져오기
        int minutes = TimeManager.Instance.minutes;
        int seconds = TimeManager.Instance.seconds;

        // 분과 초를 초 단위로 합침
        int totalSeconds = (minutes * 60) + seconds;

        // 초 단위로 timeText에 표시
        timeText.text = totalSeconds.ToString();

        // 10초 이하일 경우 텍스트 크기 키우고 색상 빨간색으로 변경
        if (totalSeconds <= 10)
        {
            timeText.fontSize = 70;  // 크기를 키움 (원하는 값으로 설정)
            timeText.color = Color.red;  // 텍스트 색상을 빨간색으로 변경
        }
        else
        {
            timeText.fontSize = 45;  // 원래 크기 (원하는 값으로 설정)
            timeText.color = Color.black;  // 기본 색상 (흰색으로 변경)
        }
    }
}
