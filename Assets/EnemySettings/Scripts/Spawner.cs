using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int EnemiesCountInSpawnPoint = 3;

    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    [SerializeField] private List<OrkConfig> _orkConfigs;
    [SerializeField] private List<ElfConfig> _elfConfigs;
    [SerializeField] private List<DragonConfig> _dragonConfigs;

    private void Awake()
    {
        CreateEnemies(_orkPrefab, _orkConfigs);
        CreateEnemies(_elfPrefab, _elfConfigs);
        CreateEnemies(_dragonPrefab, _dragonConfigs);
    }

    private void CreateEnemies<T>(Enemy enemyPrefab, List<T> enemyConfigList) where T : EnemyConfig
    {
        Transform randompoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        int iteration = 0;

        while (iteration < EnemiesCountInSpawnPoint)
        {
            Enemy enemy = Instantiate(enemyPrefab, randompoint.position, Quaternion.identity, null);

            T enemyConfig = enemyConfigList[Random.Range(0, enemyConfigList.Count)];

            enemy.Initialize(enemyConfig);
            enemy.GetInfo(enemyConfig);

            enemyConfigList.Remove(enemyConfig);
            iteration++;
        }

        _spawnPoints.Remove(randompoint);
    }
}