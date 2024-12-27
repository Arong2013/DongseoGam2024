using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public StageManager stageManager;

    public float startTime;
    public float timeRemaining;
    public bool isActiveTimer = true;
    public int minutes;
    public int seconds;

    private void Start()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        if (isActiveTimer)
        {
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isActiveTimer = false;

                stageManager.KillMonster();
                stageManager.SpawnPortal();
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                UpdateTime();
            }
        }
    }

    public void UpdateTime()
    {
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
    }
}
