using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPrefab;
    private BoxCollider2D _collider;
    private Vector3 _randomLocation = new Vector3();
    private Bounds _bounds;
    private Vector3 _minBounds;
    private Vector3 _maxBounds;
    [SerializeField] private int _minPrefabs = 15;
    [SerializeField] private int _maxPrefabs = 50;
    private int _amount = 0;
    // private int _count = 0;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _bounds = _collider.bounds;
        _minBounds = _bounds.min;
        _maxBounds = _bounds.max;

        StartSpawning();
    }

    private void StartSpawning()
    {
        SetPrefabsToSpawnAmount();
        for (int i = 0; i < _amount; ++i)
        {
            SpawnPrefab();
        }

        //InvokeRepeating("SpawnPrefab", 0.001f, 0.001f);
    }

    private void SetPrefabsToSpawnAmount()
    {
        _amount = Random.Range(_minPrefabs, _maxPrefabs);
    }

    private Vector3 GetRandomLocation()
    {
        _randomLocation.x = Random.Range(_minBounds.x, _maxBounds.x);
        _randomLocation.y = Random.Range(_minBounds.y, _maxBounds.y);
        _randomLocation.z = Random.Range(_minBounds.z, _maxBounds.z);

        return _randomLocation;
    }

    private void SpawnPrefab()
    {
        GetRandomLocation();
        Instantiate(_spawnPrefab, _randomLocation, Quaternion.identity);
        // ++_count;
        // if (_count >= _amount)
        // {
        //     CancelInvoke("SpawnPrefab");
        // }
    }
}
