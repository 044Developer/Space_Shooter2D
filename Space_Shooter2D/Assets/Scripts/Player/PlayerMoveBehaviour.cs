using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";

    [SerializeField]
    private PlayerMoveData _playerMoveData;

    private Rigidbody2D _rigidbody;
    private PlayerController _playerController;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerController = new PlayerController(_playerMoveData, this.transform, _rigidbody);
    }

    private void Start()
    {
        CreateFixedUpdateStream();
    }

    private void CreateFixedUpdateStream()
    {
        Observable.EveryFixedUpdate().Select(_ => Input.GetAxis(HorizontalInput)).Subscribe(input => _playerController.ApplyPlayerMovement(input)).AddTo(this);
    }
}
