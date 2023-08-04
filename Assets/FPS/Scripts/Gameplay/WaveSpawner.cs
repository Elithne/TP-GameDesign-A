using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    
    [SerializeField] public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave {
        [SerializeField] public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    [SerializeField] public Transform[] spawnPoints;

    [SerializeField] public float timeBetweenWaves = 5f;
    [SerializeField] public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0) {
            Debug.LogError("No spawn points referenced.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!VillagersAreAlive()) {
            if (state == SpawnState.WAITING) {
                if (!EnemyIsAlive()) {
                    WaveCompleted();
                    Debug.Log("Wave completed!");
                    //state = SpawnState.WAITING; // Vuelve a esperar antes de iniciar la siguiente oleada
                    return;
                } else {
                    return;
                }
            }
        }

        if (!VillagersAreAlive()) {
            if (waveCountdown <= 0) {
                if (state != SpawnState.SPAWNING) {
                    Debug.Log("Spawn de nuevo");
                    StartCoroutine( SpawnWave ( waves[nextWave]));
                    }
                } else {
                    waveCountdown -= Time.deltaTime;
                    }
                }
    }

    void WaveCompleted() {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) {
            nextWave = 0;
            Debug.Log("All waves completed!");
        } else {
            nextWave++;
        }

    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                return false;
            }
        }
        return true;
    }

    bool VillagersAreAlive() {
        if (GameObject.FindGameObjectWithTag("Villagers") == null) {
            return false;
    }
        return true;
}



    IEnumerator SpawnWave(Wave _wave) {

        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        //Spawn
        for (int i = 0; i < _wave.count; i++) {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate );
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy) {

        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}//FIN
