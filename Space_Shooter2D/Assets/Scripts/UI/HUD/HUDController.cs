using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField]
    private ScoreHUDData _scoreData;
    [Space]
    [Header("Health Settings")]
    [SerializeField]
    private HealthHUDData _healthData;

    private HealthDisplayController _healthController;
    private ScoreController _scoreController;
    private Queue<Image> _animatedScorePool = new Queue<Image>();

    private void OnEnable()
    {
        SubscribeOnEvents();
    }

    private void SubscribeOnEvents()
    {
        HUDEvents.ApplyNewScore += ApplyNewScore;
        HUDEvents.UpdateHealthHUD += UpdateHealth;
    }

    private void Awake()
    {
        _scoreController = new ScoreController(_scoreData);
        _healthController = new HealthDisplayController(_healthData);
    }

    private void Start()
    {
        CachObjectsPool();
    }

    private void CachObjectsPool()
    {
        for (int i = 0; i < _scoreData.CachedObjectsInPool; i++)
        {
            Image scoreImage = Instantiate(_scoreData.AnimatedScorePrefab, _scoreData.ScorePoolHolder);
            scoreImage.gameObject.SetActive(false);
            _animatedScorePool.Enqueue(scoreImage);
        }
    }

    private void ApplyNewScore(Vector2 fromPosition)
    {
        _scoreController.AnimateScore(fromPosition, ref _animatedScorePool);
    }

    private void UpdateHealth(int healthCount)
    {
        _healthController.UpdateHealthText(healthCount);
    }

    private void OnDisable()
    {
        UnscubscribeOfEvents();
    }

    private void UnscubscribeOfEvents()
    {
        HUDEvents.ApplyNewScore -= ApplyNewScore;
        HUDEvents.UpdateHealthHUD -= UpdateHealth;
    }
}
