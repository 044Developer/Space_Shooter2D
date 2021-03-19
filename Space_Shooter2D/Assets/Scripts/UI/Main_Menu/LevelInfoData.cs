using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class LevelInfoData
{
    [SerializeField]
    private int _levelID;
    [SerializeField]
    private string _levelName;
    [SerializeField]
    private string _levelObjective;
    [SerializeField]
    private int _pointsNeeded;
    [SerializeField]
    private bool _isOpened;

    public int CurrentPointsCount { get; set; }
    public int LevelID { get => _levelID; }
    public string LevelName { get => _levelName; }
    public bool IsOpened { get => _isOpened = CurrentPointsCount == _pointsNeeded; }

    public void DisplayButtonName(TextMeshProUGUI buttonName)
    {
        buttonName.text = _levelName;
    }

    public void DisplayLevelInfo(TextMeshProUGUI levelName, TextMeshProUGUI levelObjective)
    {
        levelName.text = _levelName;
        levelObjective.text = _levelObjective;
    }
}
