using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [SerializeField] GameObject player;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform enemy2;
        public int count;
       // public float rate = 0.5f;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBewteenWaves;
    public float waveCountdown;

    private float searchCountdown = 1f;
    //private int v = 5;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBewteenWaves;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted(waves[nextWave]);    
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave ( waves [nextWave] ) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted(Wave _wave)
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBewteenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Complete! Looping...");
        }
        else
        {
            nextWave++;
            _wave.count = _wave.count + 2;

        }

    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(timeBewteenWaves > 1 )
            {
                return false;
            } 
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log ("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy, _wave.enemy2);
            //yield return new WaitForSeconds( 1f/ _wave.rate);
        }

        state = SpawnState.WAITING;


        yield break;
    }

    void SpawnEnemy (Transform _enemy,Transform _enemy2)
    {
        Debug.Log("Spawning enemy:" + _enemy.name); 
        Vector3 spawnPosition = Random.insideUnitCircle.normalized * 5;
        Vector3 spawnPosition2 = Random.insideUnitCircle.normalized * 6;
        spawnPosition += player.transform.position;
        spawnPosition2 += player.transform.position;
        Instantiate(_enemy, spawnPosition, Quaternion.identity);
        Instantiate(_enemy2, spawnPosition2, Quaternion.identity);
    }
}
