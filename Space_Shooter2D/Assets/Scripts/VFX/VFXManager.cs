using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField]
    private GameObject _obstacleParticle;
    [SerializeField]
    private int _particlesPoolCount;

    [Header("VFX Holder")]
    [SerializeField]
    private Transform _vfxHolder;

    private Queue<GameObject> _obstacleVFXPool = new Queue<GameObject>();

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        ObjectPoolEvents.SpawnParticle += SpawnVFXAtPosition;
        ObjectPoolEvents.ReturnVFXObstacle += ReturnVFXToPool;
    }

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < _particlesPoolCount; i++)
        {
            GameObject particle = Instantiate(_obstacleParticle, _vfxHolder);
            _obstacleVFXPool.Enqueue(particle);
        }
    }

    private void SpawnVFXAtPosition(Vector2 position)
    {
        GameObject particle = _obstacleVFXPool.Dequeue();
        particle.transform.position = position;
        particle.SetActive(true);
    }

    private void ReturnVFXToPool(GameObject particle)
    {
        _obstacleVFXPool.Enqueue(particle);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        ObjectPoolEvents.SpawnParticle -= SpawnVFXAtPosition;
        ObjectPoolEvents.ReturnVFXObstacle -= ReturnVFXToPool;
    }
}
