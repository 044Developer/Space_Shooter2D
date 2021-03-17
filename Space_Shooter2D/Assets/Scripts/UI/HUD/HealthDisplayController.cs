using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplayController 
{
    private const string HealthIconAnim = "IsAnimated";

    private HealthHUDData _healthData;

    public HealthDisplayController(HealthHUDData healthData)
    {
        _healthData = healthData;
    }

    public void UpdateHealthText(int healthCount)
    {
        _healthData.HealthText.text = healthCount.ToString();
        AnimateHealthIcon();
    }

    private void AnimateHealthIcon()
    {
        _healthData.HealthIconAnimator.SetTrigger(HealthIconAnim);
    }
}
