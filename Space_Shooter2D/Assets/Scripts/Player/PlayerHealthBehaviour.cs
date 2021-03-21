using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";

    [Header("Health Data")]
    [SerializeField]
    private PlayerHealthData _healthData;

    private int _currentHealthCount;

    private void Start()
    {
        InitializePlayerHealth();
        CreateTriggerStream();
    }

    private void InitializePlayerHealth()
    {
        _currentHealthCount = _healthData.PlayerMaxHealth;
        HUDEvents.OnUpdateHealthHUD(_currentHealthCount);
    }

    private void CreateTriggerStream()
    {
        this.OnTriggerEnter2DAsObservable().Where(collision => collision.CompareTag(ObstacleTag)).Subscribe(collision => TriggerCollisionWithObstacle(collision)).AddTo(this);
    }

    private void TriggerCollisionWithObstacle(Collider2D collision)
    {
        DecreaseHealthCount();
        ObjectPoolEvents.OnReturnObstacleToPool(collision.gameObject);
    }

    private void DecreaseHealthCount()
    {
        _currentHealthCount--;

        if (_currentHealthCount >= 0)
        {
            HUDEvents.OnUpdateHealthHUD(_currentHealthCount);
        }
        else
        {
            PlayerEvents.OnPlayerDied();
        }
    }
}
