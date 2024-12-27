using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public StageManager stageManager;

    public float startTime = 120f;  // �ʱ� Ÿ�̸� ��
    public float timeRemaining;     // ���� �ð�
    public bool isActiveTimer = true;  // Ÿ�̸� Ȱ��ȭ ����
    public int minutes;
    public int seconds;

    private void Start()
    {
        // Ÿ�̸� �ʱ�ȭ
        timeRemaining = startTime;
    }

    public void Update()
    {
        if (isActiveTimer)
        {
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isActiveTimer = false;
                HandleEndOfStage();  // �������� �� ó��
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                UpdateTime();  // �ð� ����
            }
        }
    }

    // �������� ���� �� ���� ���� �� ��Ż ����
    public void HandleEndOfStage()
    {
        stageManager.KillMonster();
        stageManager.SpawnPortal();
    }

    public void UpdateTime()
    {
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
    }   
}