using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerMoveData 
{
    [Header("Player Move Data")]
    [SerializeField]
    private float _sideMoveSpeed;

    public float SideMoveSpeed { get => _sideMoveSpeed; }
}
