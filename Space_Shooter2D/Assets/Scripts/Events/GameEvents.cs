using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public delegate void GameStatus();
    public static event GameStatus StartGame;
    public static event GameStatus ResumeGame;
    public static event GameStatus PauseGame;

    public static void OnStartGame()
    {
        StartGame?.Invoke();
    }

    public static void OnResumeGame()
    {
        ResumeGame?.Invoke();
    }

    public static void OnPauseGame()
    {
        PauseGame?.Invoke();
    }
}

public static class SceneEvents
{
    public delegate void SceneEvent();
    public static event SceneEvent ReloadScene;
    public static event SceneEvent LoadMainMenu;

    public delegate void LoadScene(string sceneName);
    public static event LoadScene LoadLevelScene;

    public static void OnReloadScene()
    {
        ReloadScene?.Invoke();
    }

    public static void OnLoadMainMenu()
    {
        LoadMainMenu?.Invoke();
    }

    public static void OnLoadLevelScene(string sceneName)
    {
        LoadLevelScene?.Invoke(sceneName);
    }
}

public static class PlayerEvents
{
    public delegate void PlayerEvent();
    public static event PlayerEvent PlayerDied;
    public static event PlayerEvent PlayerWin;

    public delegate void SaveProgress();
    public static event SaveProgress SaveProgressData;

    public delegate void PlayerScoreEvent(int score);
    public static event PlayerScoreEvent NewScoreApplied;
    public static event PlayerScoreEvent SetTargetPoints;

    public static void OnPlayerWin()
    {
        PlayerWin?.Invoke();
    }

    public static void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }

    public static void OnSaveProgressData()
    {
        SaveProgressData?.Invoke();
    }

    public static void OnNewScoreApplied(int score)
    {
        NewScoreApplied?.Invoke(score);
    }

    public static void OnSetTargetPoints(int score)
    {
        SetTargetPoints?.Invoke(score);
    }
}

public static class ObjectPoolEvents
{
    public delegate void BulletPoolEvent(GameObject bullet);
    public static event BulletPoolEvent ReturnBulletToPool;

    public delegate void ObstaclePoolEvent(GameObject obstacle);
    public static event ObstaclePoolEvent ReturnObstacleToPool;

    public delegate void VFXSpawnEvent(Vector2 position);
    public static event VFXSpawnEvent SpawnParticle;
    public delegate void VFXReturnEvent(GameObject particle);
    public static event VFXReturnEvent ReturnVFXObstacle;

    public static void OnSpawnParticle(Vector2 position)
    {
        SpawnParticle?.Invoke(position);
    }

    public static void OnReturnParticle(GameObject particle)
    {
        ReturnVFXObstacle?.Invoke(particle);
    }

    public static void OnReturnBulletToPool(GameObject bullet)
    {
        ReturnBulletToPool?.Invoke(bullet);
    }

    public static void OnReturnObstacleToPool(GameObject obstacle)
    {
        ReturnObstacleToPool?.Invoke(obstacle);
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
