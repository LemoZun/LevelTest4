using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController : MonoBehaviour
{
    [SerializeField] ObjectPool monsterPool;
    [SerializeField] PooledObject monsterPrefab;
    [SerializeField] MonsterController6 monster;
    [SerializeField] float spawnTime;
    Coroutine SpawnCoRoutine;

    private void Start()
    {
        monster.OnDied += StartSpawn;
    }

    private void OnDestroy()
    {
        monster.OnDied -= StartSpawn;
    }

    private void StartSpawn()
    {
        if(SpawnCoRoutine == null)
            SpawnCoRoutine = StartCoroutine(SpawnMonsterRoutine());
    }

    private void StopSpawn()
    {
        if(SpawnCoRoutine != null)
            StopCoroutine(SpawnCoRoutine);
    }

    IEnumerator SpawnMonsterRoutine()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnMonster();
    }

    private void SpawnMonster()
    {
         
    }

}
