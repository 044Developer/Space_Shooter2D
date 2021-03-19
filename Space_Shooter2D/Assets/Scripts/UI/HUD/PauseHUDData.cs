using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[Serializable]
public class PauseHUDData
{
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _backToMenuButton;
    [SerializeField]
    private Button _reloadSceneButton;

    public Button PauseButton { get => _pauseButton; }
    public GameObject PausePanel { get => _pausePanel; }
    public Button ResumeButton { get => _resumeButton; }
    public Button BackToMenuButton { get => _backToMenuButton; }
    public Button ReloadSceneButton { get => _reloadSceneButton; }
}
