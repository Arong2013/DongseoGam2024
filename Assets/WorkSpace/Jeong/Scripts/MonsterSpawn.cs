using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

    [SerializeField] GameObject Prins;
    public Field field;
    public GameObject[] monsterPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 0.5f;            //기본 소환 간격
    public float minSpawnInterval = 0.5f;         //최소 소환 간격
    public float spawnSpeedIncrease = 0.05f;    //소환 주기 감소율

    private float currentSpawnInterval;         //현재 소환 간격

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

        if(Prins != null && TimeManager.Instance.timeRemaining < 10)
        {
            GameObject mob = Instantiate(Prins.gameObject, transform);
            mob.transform.position = spawnPoints[0].position;
            Prins = null;
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
