using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public TimeManager timeManager;

    public GameObject monsterPrefab;
    public Transform[] spawnPoints;
    public List<GameObject> monsters = new List<GameObject>();

    public float spawnInterval = 2f;            //�⺻ ��ȯ ����
    public float minSpawnInterval = 1f;         //�ּ� ��ȯ ����
    public float spawnSpeedIncrease = 0.05f;    //��ȯ �ֱ� ������

    private float currentSpawnInterval;         //���� ��ȯ ����

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
