using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelInfoDisplay : MonoBehaviour
{
    [Header("Level Types")]
    [SerializeField]
    private List<LevelInfoData> _levelInfo;
    [Space]
    [Header("Level Display Components")]
    [SerializeField]
    private Button _levelButtonPrefab;
    [SerializeField]
    private RectTransform _levelButtonHolder;
    [SerializeField]
    private GameObject _infoPanel;
    [SerializeField]
    private TextMeshProUGUI _levelName;
    [SerializeField]
    private TextMeshProUGUI _levelObjective;
    [SerializeField]
    private Button _closeInfoPanelButton;
    [SerializeField]
    private Button _startLevelButton;

    [SerializeField]
    private PlayerProgress _progressData;

    private int _currentLevelIndex;

    private void Start()
    {
        InitializeLevelDisplay();
    }

    private void InitializeLevelDisplay()
    {
        if (_progressData.ProgressData == null)
        {
            _progressData.ProgressData = new PlayerProgressData();
        }

        for (int i = 0; i < _levelInfo.Count; i++)
        {
            InitializeEachButton(i);
        }

        _startLevelButton.onClick.AddListener(() => LoadLevelScene());
        _closeInfoPanelButton.onClick.AddListener(() => _infoPanel.SetActive(false));
    }

    private void InitializeEachButton(int atIndex)
    {
        _levelInfo[atIndex].CurrentPointsCount = _progressData.ProgressData.TotalScore;
        Button button = Instantiate(_levelButtonPrefab, _levelButtonHolder);
        button.onClick.AddListener(() => _infoPanel.SetActive(true));
        button.onClick.AddListener(() => _levelInfo[atIndex].DisplayLevelInfo(_levelName, _levelObjective));
        button.onClick.AddListener(() => SetCurrentLevelIndex(atIndex));
        _levelInfo[atIndex].DisplayButtonName(button.GetComponentInChildren<TextMeshProUGUI>());
        _levelInfo[atIndex].IsOpened = _progressData.ProgressData.TotalScore >= _levelInfo[atIndex].PointsNeeded;
        button.enabled = _levelInfo[atIndex].IsOpened;
    }

    private void SetCurrentLevelIndex(int index)
    {
        _currentLevelIndex = index;
    }

    private void LoadLevelScene()
    {
        PlayerPrefs.SetInt("CurrentLevelID", _levelInfo[_currentLevelIndex].LevelID);
        SceneEvents.OnLoadLevelScene(_levelInfo[_currentLevelIndex].LevelName);
    }
}
