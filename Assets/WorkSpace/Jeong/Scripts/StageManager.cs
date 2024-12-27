using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public MonsterSpawn monsterSpawn;
    public GameObject portalPrefab;
    public GameObject[] stages;

    public int stageIndex;

    public void NextStage()
    {
        stages[stageIndex].SetActive(false);
        stageIndex++;
        stages[stageIndex].SetActive(true);
        PlayerRePosition();
    }

    void PlayerRePosition()
    {

    }

    public void KillMonster()
    {
        foreach (var monster in monsterSpawn.monsters)
        {
            if (monster != null)
            {
                Destroy(monster);
            }
        }
    }

    public void SpawnPortal()
    {
        if (portalPrefab != null)
        {
            Instantiate(portalPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
