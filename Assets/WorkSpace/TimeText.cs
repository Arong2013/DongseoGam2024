using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public float startTime;
    public TextMeshProUGUI timeText;

    public float timeRemaining;

    private void Start()
    {
        Utils.GetUI<TimeText>();

        timeRemaining = startTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            timeRemaining = 0;
        }
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
