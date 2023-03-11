using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid[] _asteroidPrefab;

    private float _spawnTime = 2f;
    private float _spawnDistance = 15f;
    private float _trajectoryVariance = 15f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), _spawnTime, _spawnTime);
    }

    private void SpawnAsteroid()
    {
        int asteroidIndex = Random.Range(0, _asteroidPrefab.Length);
        Vector3 spawnDir = Random.insideUnitCircle.normalized * _spawnDistance;
        Vector3 spawnPos = transform.position + spawnDir;
        float variance = Random.Range(-_trajectoryVariance, _trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

        Asteroid asteroid = Instantiate(_asteroidPrefab[asteroidIndex], spawnPos, rotation);
        asteroid.SetTrajectory(rotation * -spawnDir);
    }
}
