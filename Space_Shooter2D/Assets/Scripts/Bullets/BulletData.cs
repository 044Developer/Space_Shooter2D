using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BulletData 
{
    [Header("Bullet Data Values")]
    [SerializeField]
    private float _bulletSpeed;

    public float BulletSpeed { get => _bulletSpeed; }
}
