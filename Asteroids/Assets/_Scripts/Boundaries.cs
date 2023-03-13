using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            Destroy(asteroid.gameObject);
        }

        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
        }
    }
}
