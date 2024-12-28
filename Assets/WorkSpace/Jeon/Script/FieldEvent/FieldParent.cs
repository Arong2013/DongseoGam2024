using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldParent : MonoBehaviour
{
    public  int currentID = -1;
    [SerializeField] List<Field> Maps;

    public void ChangeMap()
    {
        Utils.GetUI<ChangeFadeUI>().OpenUI();
    }
    public void ChangeMapStart()
    {
        if(currentID >= 0)
            Maps[currentID].gameObject.SetActive(false);
        Maps[currentID + 1].gameObject.SetActive(true);
        currentID++;

    }

    public void MapStart()
    {
        if (currentID >= Maps.Count-1)
        {
            StartCoroutine(StartTimeLine());
            return;
        }
            
        Maps[currentID].GameStart();
    }
    private void FixedUpdate()
    {
        if (currentID >= Maps.Count - 1)
        {
            GameManager.Instance.playerMarcine.transform.position = Vector3.zero;
            Utils.GetUI<PlayerInputHandle>().IsinputAble = false;
            GameManager.Instance.playerMarcine.SetAnimatorValue(CharacterAnimeBoolName.CanWalk, false);
            GameManager.Instance.playerMarcine.SetDir(new Vector2(0, -1));
            GameManager.Instance.playerMarcine.transform.GetComponent<Animator>().enabled = false;
        }
    }

    IEnumerator StartTimeLine()
    {

        yield return new WaitForSeconds(2f);
        CutScenemanager.Instance.PlayCutScene(100);
       
    }
}
