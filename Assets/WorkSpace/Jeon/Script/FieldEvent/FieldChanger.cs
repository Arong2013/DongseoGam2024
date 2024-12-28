using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldChanger : MonoBehaviour
{
    [SerializeField] FieldParent fieldParent;
    bool SetNextGame = false;


    public void Start()
    {
        GameManager.Instance.SetTrueNextStage += SetTrueNextGame;
    }

    public void SetTrueNextGame()
    {
        SetNextGame = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(SetNextGame && collision.GetComponent<PlayerMarcine>())
        {
            Utils.GetUI<PlayerInputHandle>().IsinputAble = false;
            fieldParent.ChangeMap();
        }
    }
}
