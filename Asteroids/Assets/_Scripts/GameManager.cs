using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

        var asteroid = Instantiate(_asteroidPrefab[asteroidIndex], GetSpawnPos(), GetTrajectory());
    }

    private Vector3 GetSpawnPos()
    {
        Vector3 spawnDir = Random.insideUnitCircle.normalized * _spawnDistance;
        Vector3 spawnPos = transform.position + spawnDir;
        return spawnPos;
    }

    private Quaternion GetTrajectory()
    {
        float variance = Random.Range(-_trajectoryVariance, _trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
        return rotation;
    }
}
