using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public float timeRemaining;     // 남은 시간
    public bool isActiveTimer = false;  // 타이머 활성화 여부
    public int minutes;
    public int seconds;

    public void Update()
    {
        if (isActiveTimer)
        {
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isActiveTimer = false;
                HandleEndOfStage();  // 스테이지 끝 처리
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                UpdateTime();  // 시간 갱신
            }
        }
    }

    // 스테이지 종료 시 몬스터 제거 및 포탈 생성
    public void HandleEndOfStage()
    {
        
        GameManager.Instance.ItemEnable?.Invoke();
    }

    public void UpdateTime()
    {
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
    }

    public void TimeReStart(float MapTime)
    {
        timeRemaining = MapTime;
        isActiveTimer = true;
    }
}