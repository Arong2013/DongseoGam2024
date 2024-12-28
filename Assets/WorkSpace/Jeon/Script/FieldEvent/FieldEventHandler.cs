using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class FieldEventHandler : MonoBehaviour
{
    public PlayableDirector playableDirector;
    // 타임라인이 끝났는지 확인하는 프로퍼티
    public bool IsCutEnd
    {
        get
        {
            return playableDirector.time <= playableDirector.duration-0.1f;
        }
    }
}
