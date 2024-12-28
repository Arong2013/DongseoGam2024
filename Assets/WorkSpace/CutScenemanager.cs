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
    public PlayableDirector playableDirector;
    public List<CutSceneData> cutSceneDatas;  // 컷씬 데이터를 저장할 리스트

    // 타임라인 종료 여부 확인
    public bool IsCutEnd
    {
        get
        {
            return playableDirector.time <= playableDirector.duration - 0.1f;
        }
    }

    // 컷씬 재생
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
    public void Update()
    {
        if (IsCutEnd)
        {
            OnCutSceneEnd();
        }
    }
}
