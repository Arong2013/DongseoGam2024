using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;  // PlayableDirector 사용을 위해 추가

public class Field : MonoBehaviour
{
    [SerializeField] int CutID;
    [SerializeField] GameObject ItemOBJ;
    [SerializeField] GameObject Spawner;


    public float MapTime;

    public void Start()
    {
        GameManager.Instance.ItemEnable += SetTrueNextGame;
    }

    public void SetTrueNextGame()
    {
        ItemOBJ.gameObject.SetActive(true);
        Spawner.gameObject.SetActive(false);
    }

    public void GameStart()
    {
        StartCoroutine(WaitForTimelineEnd());
    }

    IEnumerator WaitForTimelineEnd()
    {
        if(CutID != 0)
        {
            Utils.GetUI<PlayerInputHandle>().IsinputAble = false;
            CutScenemanager.Instance.PlayCutScene(CutID);
            yield return new WaitForSeconds(1f);
            while (CutScenemanager.Instance.IsCutEnd)
            {
                yield return null;
            }
        }
        StartWaitForTimelineEnd();
    }
    public void StartWaitForTimelineEnd()
    {
        if(CutID != 4)
        {
            Utils.GetUI<PlayerInputHandle>().IsinputAble = true;
            GameManager.Instance.playerMarcine.GameStart();
            TimeManager.Instance.TimeReStart(MapTime);
            GameManager.Instance.playerMarcine.transform.position = Vector3.zero;
            Spawner.gameObject.SetActive(true);
        }

    }

}
