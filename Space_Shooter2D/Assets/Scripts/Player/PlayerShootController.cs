using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController 
{
    private PlayerShootData _shootData;

    public PlayerShootController(PlayerShootData shootData)
    {
        _shootData = shootData;
    }

    public void ShootBullet(Queue<GameObject> bulletPool)
    {
        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.position = _shootData.PlayerShootPosition.position;
        bullet.SetActive(true);
        bullet.transform.SetParent(null);
    }
}
