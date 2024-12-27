using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public TimeManager timeManager;

    public TextMeshProUGUI timeText;

    void Update()
    {
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        timeText.text = string.Format("{0:D2}:{1:D2}", timeManager.minutes, timeManager.seconds);
    }
}
