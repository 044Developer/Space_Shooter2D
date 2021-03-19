using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerShootData _shootData;

    private PlayerShootController _shootController;
    private Queue<GameObject> _bulletsPool = new Queue<GameObject>();

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        ObjectPoolEvents.ReturnBulletToPool += ReturnBulletToPool;
    }

    private void Start()
    {
        InitializeBulletPool();
        _shootController = new PlayerShootController(_shootData);
    }

    private void InitializeBulletPool()
    {
        for (int i = 0; i < _shootData.BulletPoolCount; i++)
        {
            GameObject bullet = Instantiate(_shootData.BulletPrefab, _shootData.BulletsPoolHolder);
            bullet.SetActive(false);
            _bulletsPool.Enqueue(bullet);
        }
    }

    private void Update()
    {
        if (_shootController.CanShoot() && Input.GetMouseButtonDown(0))
        {
            _shootController.ShootBullet(_bulletsPool);
        }
    }

    private void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(_shootData.BulletsPoolHolder);
        _bulletsPool.Enqueue(bullet);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        ObjectPoolEvents.ReturnBulletToPool -= ReturnBulletToPool;
    }
}
