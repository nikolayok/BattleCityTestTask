using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _speed = 5;
    private float _horizontalInput = 0;
    private float _verticalInput = 0;

    private Vector3 _rightRotation = new Vector3(0, 0, -90);
    private Vector3 _leftRotation = new Vector3(0, 0, 90);
    private Vector3 _upRotation = new Vector3(0, 0, 0);
    private Vector3 _downRotation = new Vector3(0, 0, 180);

    private void Start() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void Update() 
    {
        GetInput();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");    
        _verticalInput = Input.GetAxisRaw("Vertical");    
    }

    private void Move()
    {
        if (_verticalInput == 0 && _horizontalInput == 0)
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }

        if (_verticalInput == 0)
        {
            LeftRightRotation();
            _rigidbody2D.velocity = new Vector2(_horizontalInput * _speed, 0);
        }
        else if (_horizontalInput == 0)
        {
            UpDownRotation();
            _rigidbody2D.velocity = new Vector2(0, _verticalInput * _speed);
        }
    }

    private void LeftRightRotation()
    {
        if (_horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(_rightRotation);
        }
        else if (_horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(_leftRotation);
        }
    }

    private void UpDownRotation()
    {
        if (_verticalInput > 0)
        {
            transform.rotation = Quaternion.Euler(_upRotation);
        }
        else if (_verticalInput < 0)
        {
            transform.rotation = Quaternion.Euler(_downRotation);
        }
    }
}
