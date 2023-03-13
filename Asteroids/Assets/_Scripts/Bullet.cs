using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private float speed = 150f;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector3 direction)
    {
        _rb2D.AddForce(direction * speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            if (asteroid.IsBig())
            {
                asteroid.SplitSelf();
            }
            else
            {
                asteroid.DestroySelf();
            }

            Destroy(gameObject);
        }
    }
}
