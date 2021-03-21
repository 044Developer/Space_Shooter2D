using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BordersCleanerBehaviour : MonoBehaviour
{
    private const string BulletTag = "Bullet";
    private const string ObstacleTag = "Obstacle";

    private void Start()
    {
        CreateTriggerStream();
    }

    private void CreateTriggerStream()
    {
        this.OnTriggerEnter2DAsObservable().Subscribe(collision => ReactOnTriggerCollision(collision)).AddTo(this);
    }

    private void ReactOnTriggerCollision(Collider2D collision)
    {
        if (collision.CompareTag(BulletTag))
        {
            ObjectPoolEvents.OnReturnBulletToPool(collision.gameObject);
        }

        if (collision.CompareTag(ObstacleTag))
        {
            ObjectPoolEvents.OnReturnObstacleToPool(collision.gameObject);
        }
    }
}
