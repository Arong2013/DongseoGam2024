using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public MonsterSpawn monsterSpawn;
    public GameObject portalPrefab;

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
        if(portalPrefab != null)
        {
            Instantiate(portalPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
