using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _quitButton;

    [SerializeField]
    private GameObject _startUIPanel;
    [SerializeField]
    private GameObject _levelSellectionPanel;

    private void Awake()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        _startButton.onClick.AddListener(() => StartButtonPressed());
        _quitButton.onClick.AddListener(() => Application.Quit());
    }

    private void StartButtonPressed()
    {
        _startUIPanel.SetActive(false);
        _levelSellectionPanel.SetActive(true);
    }
}
