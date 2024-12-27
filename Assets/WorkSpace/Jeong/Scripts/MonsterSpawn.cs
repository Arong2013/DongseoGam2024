using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public TimeText timeText;

    public GameObject monsterPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 5f;
    public float minSpawnInterval = 1f;
    public float spawnSpeedIncrease = 0.1f;

    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = spawnInterval;
    }

    private void Update()
    {
        if(timeText.timeRemaining > 0)
        {
            currentSpawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - (spawnSpeedIncrease * (timeText.startTime - timeText.timeRemaining)));
        }
        else
        {
            currentSpawnInterval = minSpawnInterval;
        }
        
        if (Time.time % currentSpawnInterval < Time.deltaTime)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int ranPoint = Random.Range(0, 9);
        Instantiate(monsterPrefab, spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
}
