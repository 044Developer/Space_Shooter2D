using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelSettingsData 
{
    [SerializeField]
    private int _levelID;
    [SerializeField]
    private int _pointsToWin;

    [Space]
    [Header("Obstacle Types")]
    [SerializeField]
    private GameObject _slowObstacle;
    [SerializeField]
    private GameObject _normalObstacle;
    [SerializeField]
    private GameObject _fastObstacle;

    [Space]
    [Header("Level Obstacle Count")]
    [SerializeField]
    private int _slowObstacleCount;
    [SerializeField]
    private int _normalObstacleCount;
    [SerializeField]
    private int _fastObstacleCount;

    [Space]
    [Header("Spawn Settings")]
    [SerializeField]
    private int _maxObjectsSpawnedPerPool;
    [SerializeField]
    private float _delayBetweenObstacles;
    [SerializeField]
    private float _delayBetweenSpawns;

    public int LevelID { get => _levelID; }
    public int PointsToWin { get => _pointsToWin; }
    public GameObject SlowObstacle { get => _slowObstacle; }
    public GameObject NormalObstacle { get => _normalObstacle; }
    public GameObject FastObstacle { get => _fastObstacle; }
    public int SlowObstacleCount { get => _slowObstacleCount; }
    public int NormalObstacleCount { get => _normalObstacleCount; }
    public int FastObstacleCount { get => _fastObstacleCount; }
    public int MaxObjectsSpawnedPerPool { get => _maxObjectsSpawnedPerPool; }
    public float DelayBetweenObstacles { get => _delayBetweenObstacles; }
    public float DelayBetweenSpawns { get => _delayBetweenSpawns; }

    public void InitializeLevelSettings(LevelSettingsData currentSettings)
    {
        _slowObstacle = currentSettings.SlowObstacle;
        _normalObstacle = currentSettings.NormalObstacle;
        _fastObstacle = currentSettings.FastObstacle;
        _slowObstacleCount = currentSettings.SlowObstacleCount;
        _normalObstacleCount = currentSettings.NormalObstacleCount;
        _fastObstacleCount = currentSettings.FastObstacleCount;
        _maxObjectsSpawnedPerPool = currentSettings.MaxObjectsSpawnedPerPool;
        _delayBetweenObstacles = currentSettings.DelayBetweenObstacles;
        _delayBetweenSpawns = currentSettings.DelayBetweenSpawns;
    }
}
