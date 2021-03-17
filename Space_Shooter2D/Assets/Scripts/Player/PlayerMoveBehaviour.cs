using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void Start()
    {
        _playerController = new PlayerController(_playerMoveData, this.transform, _rigidbody);
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis(HorizontalInput);

        _playerController.ApplyPlayerMovement(horizontalMovement);
    }
}
