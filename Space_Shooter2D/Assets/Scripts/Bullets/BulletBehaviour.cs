using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";

    [SerializeField]
    private BulletData _bulletData;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CreateTriggerStream();
        CreateFixedUpdateStream();
    }

    private void CreateTriggerStream()
    {
        this.OnTriggerEnter2DAsObservable().Where(collision => collision.CompareTag(ObstacleTag)).Subscribe(collision => TriggerCollisionWithObstacle(collision)).AddTo(this);
    }

    private void CreateFixedUpdateStream()
    {
        Observable.EveryFixedUpdate().Subscribe(_ => MoveBullet()).AddTo(this);
    }

    private void MoveBullet()
    {
        _rigidbody.velocity = Vector2.up * _bulletData.BulletSpeed;
    }

    private void TriggerCollisionWithObstacle(Collider2D collision)
    {
        ObjectPoolEvents.OnSpawnParticle(transform.position);
        HUDEvents.OnApplyNewScore(transform.position);
        ObjectPoolEvents.OnReturnObstacleToPool(collision.gameObject);
        ObjectPoolEvents.OnReturnBulletToPool(gameObject);
    }
}
