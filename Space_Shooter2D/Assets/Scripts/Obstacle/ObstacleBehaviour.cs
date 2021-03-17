using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField]
    private ObsctacleData _obstacleData;

    private float _currentRotation;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InitializeRotationSpeed();
    }

    private void InitializeRotationSpeed()
    {
        _currentRotation = _obstacleData.RotationSpeed;
    }

    private void FixedUpdate()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        _rigidbody.velocity = Vector2.down * _obstacleData.ObstacleSpeed;
        transform.Rotate(Vector3.forward * _currentRotation * Time.deltaTime);
    }
}
