using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObsctacleData 
{
    private const int LeftRotation = -1;
    private const int RightRotation = 2;

    [Header("Obstacle Data Values")]
    [SerializeField]
    private float _obstacleSpeed;
    [SerializeField]
    private float _rotationSpeed;

    public float ObstacleSpeed { get => _obstacleSpeed; }
    public float RotationSpeed { get => _rotationSpeed * RandomRotationSide(); }

    private int RandomRotationSide()
    {
        return Random.Range(LeftRotation, RightRotation);
    }
}
