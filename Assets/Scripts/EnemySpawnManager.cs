using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 3;
    [SerializeField] private PawnBase pawnBase;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            if (spawnPoint.IsFreeToSpawn())
            {
                Instantiate(pawnBase, spawnPoint.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
            else
            {
                yield return null;
            }
        }
    }
}
