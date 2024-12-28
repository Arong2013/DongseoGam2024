using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Update()
    {
        // TimeManager���� �а� �� ��������
        int minutes = TimeManager.Instance.minutes;
        int seconds = TimeManager.Instance.seconds;

        // �а� �ʸ� �� ������ ��ħ
        int totalSeconds = (minutes * 60) + seconds;

        // �� ������ timeText�� ǥ��
        timeText.text = totalSeconds.ToString();

        // 10�� ������ ��� �ؽ�Ʈ ũ�� Ű��� ���� ���������� ����
        if (totalSeconds <= 10)
        {
            timeText.fontSize = 70;  // ũ�⸦ Ű�� (���ϴ� ������ ����)
            timeText.color = Color.red;  // �ؽ�Ʈ ������ ���������� ����
        }
        else
        {
            timeText.fontSize = 45;  // ���� ũ�� (���ϴ� ������ ����)
            timeText.color = Color.black;  // �⺻ ���� (������� ����)
        }
    }
}
