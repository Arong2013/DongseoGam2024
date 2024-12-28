using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class CutSceneData
{
    public int ID;
    public TimelineAsset timelineClip;
}

public class CutScenemanager : Singleton<CutScenemanager>
{
    public float fastForwardSpeed = 3.0f; // 빨리 감기 속도
    private float normalSpeed = 1.0f; // 기본 속도
    public PlayableDirector playableDirector;
    public List<CutSceneData> cutSceneDatas;  // 컷씬 데이터를 저장할 리스트


    public bool IsCutEnd
    {
        get
        {
            return playableDirector.time <= playableDirector.duration - 0.1f;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // 스페이스 키가 눌렸는지 확인
        {
            SetTimelineSpeed(fastForwardSpeed);
        }
        else
        {
            SetTimelineSpeed(normalSpeed);
        }
    }

    void SetTimelineSpeed(float speed)
    {
        if (playableDirector != null)
        {
            var graph = playableDirector.playableGraph;
            graph.GetRootPlayable(0).SetSpeed(speed);
        }
    }

    public void PlayCutScene(int ID)
    {
        Utils.GetUI<PlayerInputHandle>().IsinputAble = false;

        CutSceneData cutSceneData = cutSceneDatas.Find(data => data.ID == ID);
        if (cutSceneData != null)
        {
            playableDirector.playableAsset = cutSceneData.timelineClip;
            playableDirector.time = 0;
            playableDirector.Play();
            Debug.Log("Playing Cutscene: " + ID);
        }
        else
        {
            Debug.LogWarning("CutScene with ID " + ID + " not found!");
        }
        
    }
    public void OnCutSceneEnd()
    {
        Utils.GetUI<PlayerInputHandle>().IsinputAble = true;
    }
}
