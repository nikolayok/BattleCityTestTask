using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform _barrelTransform;
    [SerializeField] private GameObject _bulletPrefab;
    private float _bulletSpeed = 10;
    // private float _reloadTime = 1;

    // private bool _isAllowShooting = true;

    private void Start() 
    {
        InvokeRepeating("Shoot", 1, 1);
    }

    // private void Reload()
    // {
    //     _isAllowShooting = true;
    // }

    // private void NotAllowShootingUntilReload()
    // {
    //     _isAllowShooting = false;
    // }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _barrelTransform.position, _barrelTransform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = _barrelTransform.up * _bulletSpeed;
        // CancelInvoke("Reload");
        // NotAllowShootingUntilReload();
        // Invoke("Reload", _reloadTime);
    }
}
