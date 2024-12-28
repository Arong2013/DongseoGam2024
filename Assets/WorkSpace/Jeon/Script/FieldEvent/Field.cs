using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;  // PlayableDirector 사용을 위해 추가

public class Field : MonoBehaviour
{
    public FieldParent fieldParent;
    [SerializeField] int CutID;
    [SerializeField] GameObject ItemOBJ;
    [SerializeField] GameObject Spawner;
    [SerializeField] int soundID;

    public float MapTime;

    public void Start()
    {
        SoundManager.Instance.PlayBGM(soundID);
        GameManager.Instance.ItemEnable += SetTrueNextGame;
    }

    public void SetTrueNextGame()
    {
        if (ItemOBJ.gameObject != null)
        {
            ItemOBJ.gameObject.SetActive(true);
        }
        else
        {
            CutScenemanager.Instance.PlayCutScene(100);
            Utils.GetUI<PlayerInputHandle>().IsinputAble = false;
            GameManager.Instance.playerMarcine.SetDir(new Vector2(0, -1));
            GameManager.Instance.playerMarcine.ChangePlayerState(new IdleState(GameManager.Instance.playerMarcine, GameManager.Instance.playerMarcine.GetComponent<Animator>()));
            GameManager.Instance.playerMarcine.SetAnimatorValue(CharacterAnimeBoolName.CanWalk, false);
        }
        
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
        Utils.GetUI<PlayerInputHandle>().IsinputAble = true;
        GameManager.Instance.playerMarcine.GameStart();
        TimeManager.Instance.TimeReStart(MapTime);
        GameManager.Instance.playerMarcine.transform.position = Vector3.zero;
        Spawner.gameObject.SetActive(true);
    }

}
