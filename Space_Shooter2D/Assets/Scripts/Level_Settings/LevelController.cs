using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoints;

    private LevelSettingsData _currentLevelSettings = new LevelSettingsData();
    private List<GameObject> _levelObstacles;
    private Queue<GameObject> _shuffledObstaclePool = new Queue<GameObject>();
    private Queue<Transform> _spawnPointPool = new Queue<Transform>();

    private void OnEnable()
    {
        ObjectPoolEvents.ReturnObstacleToPool += ReturnObstacleToPool;
    }

    private void Start()
    {
        CacheSpawnPointsPool();
    }

    private void CacheSpawnPointsPool()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _spawnPointPool.Enqueue(_spawnPoints[i]);
        }
    }

    public void SetLevelSettings(LevelSettingsData levelData)
    {
        _currentLevelSettings.InitializeLevelSettings(levelData);
        CreateObstacleList();
        ShuffleObstaclesToPool();

        StartGameLoop();
    }

    private void StartGameLoop()
    {
        StartCoroutine(GameLevelLoop());
    }

    private IEnumerator GameLevelLoop()
    {
        var randomSpawnCount = UnityEngine.Random.Range(1, 4);
        for (int i = 0; i < randomSpawnCount; i++)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(_currentLevelSettings.DelayBetweenObstacles);
        }

        yield return new WaitForSeconds(_currentLevelSettings.DelayBetweenSpawns);

        StartCoroutine(GameLevelLoop());
    }

    private void CreateObstacleList()
    {
        _levelObstacles = new List<GameObject>();

        for (int i = 0; i < _currentLevelSettings.SlowObstacleCount; i++)
        {
            GameObject obstacle = Instantiate(_currentLevelSettings.SlowObstacle, transform);
            obstacle.SetActive(false);
            _levelObstacles.Add(obstacle);
        }

        for (int i = 0; i < _currentLevelSettings.NormalObstacleCount; i++)
        {
            GameObject obstacle = Instantiate(_currentLevelSettings.NormalObstacle, transform);
            obstacle.SetActive(false);
            _levelObstacles.Add(obstacle);
        }

        for (int i = 0; i < _currentLevelSettings.SlowObstacleCount; i++)
        {
            GameObject obstacle = Instantiate(_currentLevelSettings.FastObstacle, transform);
            obstacle.SetActive(false);
            _levelObstacles.Add(obstacle);
        }
    }

    private void ShuffleObstaclesToPool()
    {
        var obstacleCount = _levelObstacles.Count;

        var shuffledList = _levelObstacles.OrderBy(a => Guid.NewGuid()).ToList();

        for (int i = 0; i < obstacleCount; i++)
        {
            _shuffledObstaclePool.Enqueue(shuffledList[i]);
        }
    }

    private void ReturnObstacleToPool(GameObject obstacle)
    {
        obstacle.SetActive(false);
        _shuffledObstaclePool.Enqueue(obstacle);
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = _shuffledObstaclePool.Dequeue();
        obstacle.SetActive(true);

        Transform nextSpawnPoint = _spawnPointPool.Dequeue();
        obstacle.transform.position = nextSpawnPoint.position;
        _spawnPointPool.Enqueue(nextSpawnPoint);
    }

    private void OnDisable()
    {
        ObjectPoolEvents.ReturnObstacleToPool -= ReturnObstacleToPool;
    }
}
