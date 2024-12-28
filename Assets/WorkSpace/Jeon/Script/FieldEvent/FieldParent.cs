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
        if(currentID >= Maps.Count)
        {
            CutScenemanager.Instance.PlayCutScene(100);
            return;
        }

        if(currentID >= 0)
            Maps[currentID].gameObject.SetActive(false);
        Maps[currentID + 1].gameObject.SetActive(true);
        currentID++;

    }

    public void MapStart()
    {
        if (currentID >= Maps.Count)
            return;
        Maps[currentID].GameStart();
    }
}
