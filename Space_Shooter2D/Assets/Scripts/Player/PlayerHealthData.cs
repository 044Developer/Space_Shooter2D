using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerHealthData 
{
    [SerializeField]
    private int _playerMaxHealth;

    public int PlayerMaxHealth { get => _playerMaxHealth; }
}
