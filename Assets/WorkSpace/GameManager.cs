using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : Singleton<GameManager>
{
    public CharacterMarcine playerMarcine;

    public Action ItemEnable;
    public Action SetTrueNextStage;

    public void GameEnd()
    {
        Utils.GetUI<PlayerInputHandle>().IsinputAble = false;
        Utils.GetUI<GameOverUI>().gameObject.SetActive(true);
    }
}
