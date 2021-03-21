using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private PlayerMoveData _playerMoveData;
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;

    public PlayerController(PlayerMoveData playerMoveData, Transform playerTransform, Rigidbody2D rigidbody)
    {
        _playerMoveData = playerMoveData;
        _playerTransform = playerTransform;
        _rigidbody = rigidbody;
    }

    public void ApplyPlayerMovement(float horizontalInput)
    {
        _rigidbody.MovePosition(new Vector2(_playerTransform.position.x + horizontalInput * _playerMoveData.SideMoveSpeed * Time.deltaTime, _playerTransform.position.y));
    }
}
