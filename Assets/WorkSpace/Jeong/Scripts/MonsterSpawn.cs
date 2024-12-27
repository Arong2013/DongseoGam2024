using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public Field field;
    public GameObject[] monsterPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 2f;            //�⺻ ��ȯ ����
    public float minSpawnInterval = 1f;         //�ּ� ��ȯ ����
    public float spawnSpeedIncrease = 0.05f;    //��ȯ �ֱ� ������

    private float currentSpawnInterval;         //���� ��ȯ ����

    void Start()
    {
        currentSpawnInterval = spawnInterval;
    }

    private void Update()
    {
        if (TimeManager.Instance.timeRemaining > 0)
        {
            currentSpawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - (spawnSpeedIncrease * (field.MapTime - TimeManager.Instance.timeRemaining)));
        }
        else
        {
            currentSpawnInterval = minSpawnInterval;
        }

        if (TimeManager.Instance.timeRemaining > 0 && Time.time % currentSpawnInterval < Time.deltaTime)
        {
            Spawn();
            //Debug.Log(currentSpawnInterval);
        }
    }

    void Spawn()
    {
        int ranMonster = Random.Range(0, monsterPrefab.Length);
        int ranPoint = Random.Range(0, spawnPoints.Length);
        GameObject mob = Instantiate(monsterPrefab[ranMonster], transform);
        mob.transform.position = spawnPoints[ranPoint].position;
        //monsters.Add(monster);
    }
}
