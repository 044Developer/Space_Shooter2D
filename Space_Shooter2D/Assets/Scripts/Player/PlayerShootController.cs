using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController 
{
    private PlayerShootData _shootData;
    private float _timer;

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

        _timer = 0f;
    }

    public bool CanShoot()
    {
        if (_timer < _shootData.PlayerShootRate)
        {
            _timer += Time.deltaTime;
            return false;
        }
        return true;
    }
}
