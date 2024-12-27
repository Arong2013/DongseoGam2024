using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Update()
    {
        int minutes = TimeManager.Instance.minutes;
        int seconds = TimeManager.Instance.seconds;

        timeText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
