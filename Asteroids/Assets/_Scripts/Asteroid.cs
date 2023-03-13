using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private float speed = 7f;
    private bool _isBig = true;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            if (!player.IsImmune())
            {
                if (this._isBig)
                {
                    SplitSelf();
                }
                else
                {
                    DestroySelf();
                }
    
                player.Hit();
            }
        }
    }

    public void SetTrajectory(Vector3 direction)
    {
        _rb2D.AddForce(direction * speed);
    }

    public void SplitSelf()
    {
        AsteroidManager.Instance.SplitAsteroid(this);
        DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetIsBig(bool isBig)
    {
        _isBig = isBig;
    }

    public bool IsBig()
    {
        return _isBig;
    }
}
