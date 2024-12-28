using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;  // SceneManager를 사용하기 위한 네임스페이스 추가


public class GameOverUI : MonoBehaviour
{
    public Button ExitBtn, ExitBtn2;
    public string sceneName = "GameScene";  // 이동할 씬 이름을 지정하는 변수


    public void Start()
    {
        SoundManager.Instance.StopAllSounds();
        SoundManager.Instance.PlaySFX(7);
        ExitBtn.onClick.AddListener(() => { SceneManager.LoadScene(sceneName); });
        ExitBtn2.onClick.AddListener(() => { SceneManager.LoadScene(sceneName); });
    }
}