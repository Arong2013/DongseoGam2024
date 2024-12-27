using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFadeUI : MonoBehaviour
{
    public FieldParent fieldParent;

    public void MapChangeEvent() 
    {
        fieldParent.ChangeMapStart();
    }

    public void GameStartEvent()
    {
        fieldParent.MapStart();
        gameObject.SetActive(false);
    }

    public void OpenUI()
    {
        gameObject.SetActive(true);
    }
}