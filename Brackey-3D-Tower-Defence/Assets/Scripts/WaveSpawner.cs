using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] public List<WaveConfig> waveConfigs;
    [SerializeField] public float timeBetweenWaves = 5f;

    private float initialCountdown = 3f;
    private float countdown = 0f;
    private int startingWave = 0;

    public bool startWave = false;
    public bool waveIsStarted = false;
    public bool waveEnd = true;

    // Update is called once per frame
    void Update()
    {
        if(startWave)
        {
            if (initialCountdown <= 0f && !waveIsStarted)
            {
                LaunchWaves();
                startWave = false;
                waveIsStarted = true;
            }
            initialCountdown -= Time.deltaTime;
        }
    }

    public void StartWave()
    {
        if(waveEnd)
        {
            startWave = true;
            waveEnd = false;
        }
    }

    void LaunchWaves()
    {
        StartCoroutine(SpawnLoopWave(2));
        //StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnLoopWave(int loopNumber)
    {
        for (int i = 0; i < loopNumber; i++)
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {
            Debug.Log(i);
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnnemiesInWave(WaveConfig waveConfig)
    {
        if(!waveEnd)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            for (int i = 0; i < waveConfig.GetNumberOfEnnemies(); i++)
            {
                Instantiate(
                    waveConfig.GetEnnemyPrefab(),
                    waveConfig.GetWaypoints()[0].transform.position,
                    Quaternion.identity);
                yield return new WaitForSeconds(waveConfig.GetSpawnRate());
            }
            waveEnd = true;
            waveIsStarted = false;
        }
    }
}
