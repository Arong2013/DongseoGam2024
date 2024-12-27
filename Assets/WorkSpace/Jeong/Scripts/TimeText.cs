using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public StageClear stageClear;
    public TextMeshProUGUI timeText;

    public float startTime;
    public float timeRemaining;
    public bool isActiveTimer = true;

    private void Start()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        if(isActiveTimer)
        {
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isActiveTimer = false;

                Debug.Log("스테이지 클리어");
                stageClear.KillMonster();
                stageClear.SpawnPortal();
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimeText();
            }
        }
    }

    void UpdateTimeText()
    {
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
