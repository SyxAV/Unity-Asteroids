using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager Instance {get; private set;}

    [SerializeField] private Asteroid[] _asteroidPrefab;
    [SerializeField] private Asteroid[] _smallAsteroidPrefab;

    private float _spawnTime = 2f;
    private float _spawnDistance = 15f;
    private float _trajectoryVariance = 15f;

    void Awake()
    {
        Instance = this;
    }

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

    public void SplitAsteroid(Asteroid asteroid)
    {
        int asteroidIndex = Random.Range(0, _smallAsteroidPrefab.Length);

        for (int i = 0; i < 2; i++)
        {
            Asteroid smallAsteroid = Instantiate(_smallAsteroidPrefab[asteroidIndex], asteroid.transform.position, asteroid.transform.rotation);
            smallAsteroid.SetIsBig(false);
            smallAsteroid.SetTrajectory(Random.insideUnitCircle * _spawnDistance);
        }
    }
}
