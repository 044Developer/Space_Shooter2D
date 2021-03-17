using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class HealthHUDData
{
    [SerializeField]
    private TextMeshProUGUI _healthText;
    [SerializeField]
    private Animator _healthIconAnimator;

    public TextMeshProUGUI HealthText { get => _healthText; }
    public Animator HealthIconAnimator { get => _healthIconAnimator; }
}
