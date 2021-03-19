using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersCleanerBehaviour : MonoBehaviour
{
    private const string BulletTag = "Bullet";
    private const string ObstacleTag = "Obstacle";

    private void OnTriggerEnter2D(Collider2D collision)
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
