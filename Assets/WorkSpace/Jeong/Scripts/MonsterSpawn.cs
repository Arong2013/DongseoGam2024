using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public TimeManager timeManager;

    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    public List<GameObject> monsters = new List<GameObject>();

    public float spawnInterval = 2f;            //기본 소환 간격
    public float minSpawnInterval = 1f;         //최소 소환 간격
    public float spawnSpeedIncrease = 0.05f;    //소환 주기 감소율

    private float currentSpawnInterval;         //현재 소환 간격

    private void Start()
    {
        currentSpawnInterval = spawnInterval;
    }

    private void Update()
    {
        if (timeManager.timeRemaining > 0)
        {
            currentSpawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - (spawnSpeedIncrease * (timeManager.startTime - timeManager.timeRemaining)));
        }
        else
        {
            currentSpawnInterval = minSpawnInterval;
        }

        if (timeManager.timeRemaining > 0 && Time.time % currentSpawnInterval < Time.deltaTime)
        {
            Spawn();
            Debug.Log(currentSpawnInterval);
        }
    }

    void Spawn()
    {
        int ranPoint = Random.Range(0, 4);
        GameObject monster = Instantiate(monsterPrefab, spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
        monsters.Add(monster);
    }
}
