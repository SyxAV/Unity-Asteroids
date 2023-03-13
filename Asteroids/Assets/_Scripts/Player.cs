using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}

    public static event Action OnHit; 

    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private Bullet _bullet;

    private Rigidbody2D _rb2D;
    private bool _isMoving;
    private bool _isImmune = false;
    private int _lives = 3;
    private float _movingSpeed = 2.5f;
    private float _turningDir;
    private float _turningSpeed = 1f;
    private float _immuneTimer;
    private float _immuneTimerMax = 1f;

    void Awake()
    {
        Instance = this;

        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turningDir = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turningDir = -1f;
        }
        else
        {
            _turningDir = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (_isImmune)
        {
            _immuneTimer += Time.deltaTime;
            if (_immuneTimer >= _immuneTimerMax)
            {
                _isImmune = false;
                _immuneTimer = 0;
            }
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bullet, _gunBarrel.position, Quaternion.identity);
        bullet.SetDirection(transform.up);
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            _rb2D.AddForce(transform.up * _movingSpeed);
        }

        if (_turningDir != 0)
        {
            _rb2D.AddTorque(_turningDir * _turningSpeed);
        }
    }

    public void Hit()
    {
        if (!_isImmune)
        {
            _lives--;
            OnHit?.Invoke();
            _isImmune = true;
        }
    }

    public bool IsImmune()
    {
        return _isImmune;
    }

    public int GetLives()
    {
        return _lives;
    }
}
