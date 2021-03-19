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
    private PlayerProgressData _progressData;

    private int _currentLevelIndex;

    private void Start()
    {
        InitializeLevelDisplay();
    }

    private void InitializeLevelDisplay()
    {
        for (int i = 0; i < _levelInfo.Count; i++)
        {
            _levelInfo[i].CurrentPointsCount = _progressData.CurrentScore;
            int index = i;
            Button button = Instantiate(_levelButtonPrefab, _levelButtonHolder);
            button.onClick.AddListener(() => _infoPanel.SetActive(true));
            button.onClick.AddListener(() => _levelInfo[index].DisplayLevelInfo(_levelName, _levelObjective));
            button.onClick.AddListener(() => SetCurrentLevelIndex(index));
            _levelInfo[index].DisplayButtonName(button.GetComponentInChildren<TextMeshProUGUI>());
            button.enabled = _levelInfo[index].IsOpened;
        }

        _startLevelButton.onClick.AddListener(() => LoadLevelScene());
        _closeInfoPanelButton.onClick.AddListener(() => _infoPanel.SetActive(false));
    }

    private void SetCurrentLevelIndex(int index)
    {
        _currentLevelIndex = index;
    }

    private void LoadLevelScene()
    {
        GameEvents.OnSpawnLevel(_levelInfo[_currentLevelIndex].LevelID);
        SceneEvents.OnLoadLevelScene(_levelInfo[_currentLevelIndex].LevelName);
    }
}
