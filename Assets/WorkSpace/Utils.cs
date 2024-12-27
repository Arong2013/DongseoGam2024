using System;
using System.Collections.Generic;
using UnityEngine;

public enum BehaviorState
{
    SUCCESS,
    RUNNING,
    FAILURE
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers();
}
public interface IObserver
{
    void UpdateObserver();
}

public interface IPlayerUesableUI
{
    void Initialize(CharacterMarcine playerMarcine);
}
public interface IHarvestable
{
    bool CanBeHarvested(); // ������ �������� Ȯ��
    void StartHarvest();   // ������ ����
    void EndHarvest();     // ������ ����
    int GetHarvestReward(); // �������� ��� ���� (��: ��� ����)
}



public static class Utils
{
    
    public static T GetUI<T>(string _name = null) where T : MonoBehaviour
    {
        T component = null;
        if (component == null)
        {
            component = FindInCanvasChildren<T>();
        }
        else if (component == null)
        {
            Debug.Log(component.name + " found in the current scene.");

        }
        return component;
    }
    private static T FindInCanvasChildren<T>() where T : MonoBehaviour
    {
        T component = null;
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            component = canvas.GetComponentInChildren<T>(true);
        }

        return component;
    }

    public static List<IPlayerUesableUI> SetPlayerMarcineOnUI()
    {
        var list = new List<IPlayerUesableUI>();
        GameObject canvas = GameObject.Find("Canvas");
        foreach (Transform child in canvas.GetComponentsInChildren<Transform>(true))
        {
            IPlayerUesableUI usableUI = child.GetComponent<IPlayerUesableUI>();
            if (usableUI != null)
            {
                Debug.Log(child.name);
                list.Add(usableUI);
            }
        }
        return list;
    }

}