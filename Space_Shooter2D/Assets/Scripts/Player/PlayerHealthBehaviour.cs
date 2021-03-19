using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";

    [Header("Health Data")]
    [SerializeField]
    private PlayerHealthData _healthData;

    private int _currentHealthCount;

    private void Start()
    {
        _currentHealthCount = _healthData.PlayerMaxHealth;
        HUDEvents.OnUpdateHealthHUD(_currentHealthCount);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObstacleTag))
        {
            DecreaseHealthCount();
            ObjectPoolEvents.OnReturnObstacleToPool(collision.gameObject);
        }
    }
}
