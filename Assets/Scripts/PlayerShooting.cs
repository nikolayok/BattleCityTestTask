using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _barrelTransform;
    [SerializeField] private GameObject _bulletPrefab;
    private float _bulletSpeed = 10;
    private float _reloadTime = 1;

    private bool _isAllowShooting = true;

    void Update()
    {
        ShootIfKeyPressed();
    }

    private void Reload()
    {
        _isAllowShooting = true;
    }

    private void NotAllowShootingUntilReload()
    {
        _isAllowShooting = false;
    }


    private void ShootIfKeyPressed()
    {
        if (Input.GetKey(KeyCode.Space) && _isAllowShooting)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _barrelTransform.position, _barrelTransform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = _barrelTransform.up * _bulletSpeed;
        CancelInvoke("Reload");
        NotAllowShootingUntilReload();
        Invoke("Reload", _reloadTime);
    }
}
