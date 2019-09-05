using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform ennemyPrefab;

    [SerializeField] public float timeBetweenWaves;
    private float countdown;

    void Update()
    {
        if(countdown <= 0f)
        {
            spawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    void spawnWave()
    {

    }
}
