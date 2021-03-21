using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    private const int LeftMouseClick = 0;

    [SerializeField]
    private PlayerShootData _shootData;

    private PlayerShootController _shootController;
    private Queue<GameObject> _bulletsPool = new Queue<GameObject>();

    private DateTimeOffset _lastFired;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        ObjectPoolEvents.ReturnBulletToPool += ReturnBulletToPool;
    }

    private void Awake()
    {
        InitializeComponents();
    }

    private void Start()
    {
        CreateInputStream();
    }

    private void CreateInputStream()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(LeftMouseClick))
            .Timestamp()
            .Where(x => x.Timestamp > _lastFired.AddSeconds(_shootData.PlayerShootRate))
            .Subscribe(x =>
            {
                _shootController.ShootBullet(_bulletsPool);
                _lastFired = x.Timestamp;
            }).AddTo(this);
    }

    private void InitializeComponents()
    {
        InitializeBulletPool();
        _shootController = new PlayerShootController(_shootData);
    }

    private void InitializeBulletPool()
    {
        _bulletsPool.Clear();
        for (int i = 0; i < _shootData.BulletPoolCount; i++)
        {
            GameObject bullet = Instantiate(_shootData.BulletPrefab, _shootData.BulletsPoolHolder);
            bullet.SetActive(false);
            _bulletsPool.Enqueue(bullet);
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
