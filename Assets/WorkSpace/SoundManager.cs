using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    [SerializeField] int id; // Sound ID
    [SerializeField] AudioClip data; // Sound clip ������

    public int ID => id;
    public AudioClip Data => data;
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] List<SoundData> soundDatas; // ���� ������ ���
    private AudioSource bgmAudioSource; // BGM�� ���� AudioSource
    private List<AudioSource> sfxAudioSources; // SFX�� ���� ���� AudioSource

    private void Start()
    {
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true; // BGM�� �ݺ��ǵ��� ����

        // SFX AudioSource���� ���� ����Ʈ �ʱ�ȭ
        sfxAudioSources = new List<AudioSource>();

        // �ִ� SFX �� ���� (����: �ִ� 5��)
        for (int i = 0; i < 5; i++)
        {
            AudioSource sfxSource = gameObject.AddComponent<AudioSource>();
            sfxAudioSources.Add(sfxSource);
            sfxSource.playOnAwake = false; // SFX�� �ڵ� ������� �ʵ��� ����
        }
    }
    public void PlayBGM(int soundID)
    {
        // SoundData ��Ͽ��� �ش� ID�� ���� SoundData ã��
        SoundData soundData = soundDatas.Find(sound => sound.ID == soundID);

        if (soundData != null)
        {
            // BGM�� �����ϰ� ���
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
        // SoundData ��Ͽ��� �ش� ID�� ���� SoundData ã��
        SoundData soundData = soundDatas.Find(sound => sound.ID == soundID);

        if (soundData != null)
        {
            // ��� ������ SFX AudioSource�� ã�Ƽ� ���
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
        bgmAudioSource.Stop(); // BGM ����
        foreach (var sfxSource in sfxAudioSources)
        {
            sfxSource.Stop(); // ��� SFX ����
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
