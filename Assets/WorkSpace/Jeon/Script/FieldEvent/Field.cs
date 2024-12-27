using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
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
        GameManager.Instance.playerMarcine.GameStart();
        GameManager.Instance.playerMarcine.transform.position = Vector3.zero;
        Spawner.gameObject.SetActive(true);
        TimeManager.Instance.TimeReStart(MapTime);
        
    }
}
