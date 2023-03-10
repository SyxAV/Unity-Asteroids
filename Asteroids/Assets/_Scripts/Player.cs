using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb2D;

    private bool _moving;
    private float _movingSpeed = 2.5f;
    private float _turningDir;
    private float _turningSpeed = 1f;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

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
    }

    void FixedUpdate()
    {
        if (_moving)
        {
            _rb2D.AddForce(transform.up * _movingSpeed);
        }

        if (_turningDir != 0)
        {
            _rb2D.AddTorque(_turningDir * _turningSpeed);
        }
    }
}
