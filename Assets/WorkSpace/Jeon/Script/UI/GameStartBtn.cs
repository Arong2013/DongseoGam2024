using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;  // SceneManager를 사용하기 위한 네임스페이스 추가

public class GameStartBtn : MonoBehaviour, IPointerDownHandler
{
    public string sceneName = "GameScene";  // 이동할 씬 이름을 지정하는 변수

    public void OnPointerDown(PointerEventData eventData)
    {
        // 버튼이 클릭되면 지정한 씬으로 이동
        SceneManager.LoadScene(sceneName);
    }
}
