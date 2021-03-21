using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressController : MonoBehaviour
{
    private const string TotalScorePath = "TotalScore";

    private int _targetPoints = 0;
    private int _currentPoints = 0;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PlayerEvents.NewScoreApplied += CheckWinCondition;
        PlayerEvents.SetTargetPoints += SetTargetPoints;
    }

    private void CheckWinCondition(int score)
    {
        _currentPoints += score;
        if (_currentPoints >= _targetPoints)
        {
            SaveTotalPoints();
            PlayerEvents.OnPlayerWin();
        }
    }

    private void SetTargetPoints(int target)
    {
        _targetPoints = target;
    }

    private void SaveTotalPoints()
    {
        PlayerPrefs.SetInt(TotalScorePath, _currentPoints);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        PlayerEvents.NewScoreApplied -= CheckWinCondition;
        PlayerEvents.SetTargetPoints -= SetTargetPoints;
    }
}
