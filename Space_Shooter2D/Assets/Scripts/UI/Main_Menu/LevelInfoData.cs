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

    public int CurrentPointsCount { get; set; }
    public int PointsNeeded { get => _pointsNeeded; }
    public int LevelID { get => _levelID; }
    public string LevelName { get => _levelName; }
    public bool IsOpened { get; set; }

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
