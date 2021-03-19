using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private List<LevelSettingsData> _levelSettings;

    [SerializeField]
    private LevelController _levelController;

    private void OnEnable()
    {
        GameEvents.StartGame += StartGame;
    }

    private void StartGame()
    {
        _levelController.SetLevelSettings(_levelSettings[_gameManager.GetCurrentLevelID()]);
    }

    private void OnDisable()
    {
        GameEvents.StartGame -= StartGame;
    }
}
