using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    [SerializeField] int id; // Sound ID
    [SerializeField] AudioClip data; // Sound clip 데이터

    public int ID => id;
    public AudioClip Data => data;
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] List<SoundData> soundDatas; // 사운드 데이터 목록
    private AudioSource bgmAudioSource; // BGM을 위한 AudioSource
    private List<AudioSource> sfxAudioSources; // SFX를 위한 여러 AudioSource

    private void Start()
    {
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true; // BGM은 반복되도록 설정

        // SFX AudioSource들을 위한 리스트 초기화
        sfxAudioSources = new List<AudioSource>();

        // 최대 SFX 수 설정 (예시: 최대 5개)
        for (int i = 0; i < 5; i++)
        {
            AudioSource sfxSource = gameObject.AddComponent<AudioSource>();
            sfxAudioSources.Add(sfxSource);
            sfxSource.playOnAwake = false; // SFX는 자동 재생되지 않도록 설정
        }
    }
    public void PlayBGM(int soundID)
    {
        // SoundData 목록에서 해당 ID를 가진 SoundData 찾기
        SoundData soundData = soundDatas.Find(sound => sound.ID == soundID);

        if (soundData != null)
        {
            // BGM을 설정하고 재생
            bgmAudioSource.clip = soundData.Data;
            bgmAudioSource.Play();
        }
        else
        {
            Debug.LogWarning($"Sound ID {soundID} not found for BGM.");
        }
    }
    public void PlaySFX(int soundID)
    {
        // SoundData 목록에서 해당 ID를 가진 SoundData 찾기
        SoundData soundData = soundDatas.Find(sound => sound.ID == soundID);

        if (soundData != null)
        {
            // 사용 가능한 SFX AudioSource를 찾아서 재생
            foreach (var sfxSource in sfxAudioSources)
            {
                if (!sfxSource.isPlaying)
                {
                    sfxSource.clip = soundData.Data;
                    sfxSource.Play();
                    return;
                }
            }
            Debug.LogWarning("No available SFX audio sources.");
        }
        else
        {
            Debug.LogWarning($"Sound ID {soundID} not found for SFX.");
        }
    }
    public void StopAllSounds()
    {
        bgmAudioSource.Stop(); // BGM 정지
        foreach (var sfxSource in sfxAudioSources)
        {
            sfxSource.Stop(); // 모든 SFX 정지
        }
    }
    public void PauseBGM()
    {
        bgmAudioSource.Pause();
    }
    public void ResumeBGM()
    {
        bgmAudioSource.UnPause();
    }
    public void StopSFX(int soundID)
    {
        SoundData soundData = soundDatas.Find(sound => sound.ID == soundID);

        if (soundData != null)
        {
            foreach (var sfxSource in sfxAudioSources)
            {
                if (sfxSource.clip == soundData.Data && sfxSource.isPlaying)
                {
                    sfxSource.Stop();
                    return;
                }
            }
        }
    }
}
