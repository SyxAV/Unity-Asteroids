using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private float speed = 7f;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetTrajectory(Vector3 direction)
    {
        _rb2D.AddForce(direction * speed);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
