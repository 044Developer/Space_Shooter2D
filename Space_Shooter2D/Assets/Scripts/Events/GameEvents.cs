using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    
}

public static class ObjectPoolEvents
{
    public delegate void BulletPoolEvent(GameObject bullet);
    public static event BulletPoolEvent ReturnToPool;

    public static void OnReturnToPool(GameObject bullet)
    {
        ReturnToPool?.Invoke(bullet);
    }
}

public static class HUDEvents
{
    public delegate void ScoreEvent(Vector2 spawnPosition);
    public static event ScoreEvent ApplyNewScore;

    public delegate void HealthEvent(int healthCount);
    public static event HealthEvent UpdateHealthHUD;

    public static void OnApplyNewScore(Vector2 spawnPosition)
    {
        ApplyNewScore?.Invoke(spawnPosition);
    }

    public static void OnUpdateHealthHUD(int healthCount)
    {
        UpdateHealthHUD?.Invoke(healthCount);
    }
}
