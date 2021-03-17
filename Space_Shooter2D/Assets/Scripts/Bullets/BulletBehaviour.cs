using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";

    [SerializeField]
    private BulletData _bulletData;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        _rigidbody.velocity = Vector2.up * _bulletData.BulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObstacleTag))
        {
            //Do Particle
            // Return Obstacle To Pool
            ObjectPoolEvents.OnReturnToPool(this.gameObject);
        } 
    }
}
