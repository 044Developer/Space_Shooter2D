using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHUDController
{
    private PauseHUDData _pauseData;

    public PauseHUDController(PauseHUDData pauseData)
    {
        _pauseData = pauseData;
        InitializeButtons();
    }

    public void OpenWinPanel()
    {
        _pauseData.PausePanel.SetActive(true);
        _pauseData.YouWonText.gameObject.SetActive(true);
        GameEvents.OnPauseGame();
    }

    public void OpenDiePanel()
    {
        _pauseData.PausePanel.SetActive(true);
        _pauseData.ReloadSceneButton.gameObject.SetActive(true);
        GameEvents.OnPauseGame();
    }

    private void CloseDiePanel()
    {
        _pauseData.PausePanel.SetActive(false);
        _pauseData.ReloadSceneButton.gameObject.SetActive(false);
        GameEvents.OnResumeGame();
    }

    private void InitializeButtons()
    {
        _pauseData.PauseButton.onClick.AddListener(() => OpenPausePanel());
        _pauseData.ResumeButton.onClick.AddListener(() => ClosePausePanel());
        _pauseData.BackToMenuButton.onClick.AddListener(() => ReturnToMainMenu());
        _pauseData.ReloadSceneButton.onClick.AddListener(() => ReloadScene());
    }

    private void OpenPausePanel()
    {
        _pauseData.PausePanel.SetActive(true);
        _pauseData.ResumeButton.gameObject.SetActive(true);
        GameEvents.OnPauseGame();
    }

    private void ClosePausePanel()
    {
        _pauseData.PausePanel.SetActive(false);
        _pauseData.YouWonText.gameObject.SetActive(false);
        _pauseData.ResumeButton.gameObject.SetActive(false);
        GameEvents.OnResumeGame();
    }

    private void ReloadScene()
    {
        CloseDiePanel();
        SceneEvents.OnReloadScene();
    }

    private void ReturnToMainMenu()
    {
        CloseDiePanel();
        ClosePausePanel();
        SceneEvents.OnLoadMainMenu();
    }
}
