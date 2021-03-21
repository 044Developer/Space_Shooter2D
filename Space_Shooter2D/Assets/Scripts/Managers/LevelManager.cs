using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<LevelSettingsData> _levelSettings;

    [SerializeField]
    private LevelController _levelController;
    private int _currentLevelID;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        GameEvents.StartGame += StartGame;
    }

    private void StartGame()
    {
        _currentLevelID = PlayerPrefs.GetInt("CurrentLevelID");

        _levelController.SetLevelSettings(_levelSettings[_currentLevelID]);
        PlayerEvents.OnSetTargetPoints(_levelSettings[_currentLevelID].PointsToWin);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        GameEvents.StartGame -= StartGame;
    }
}
