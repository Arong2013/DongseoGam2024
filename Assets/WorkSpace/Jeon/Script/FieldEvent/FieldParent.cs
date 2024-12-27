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
        Maps[currentID].GameStart();
    }
}
