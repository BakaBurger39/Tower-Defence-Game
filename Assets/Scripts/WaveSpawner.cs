using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveNumber = 0;

    private void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    //WaveSpawner Class    
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];
        for (int z = 0; z < wave.enemies.Length; z++)
        {
            for (int i = 0; i < wave.enemies[z].count; i++)
            {
                SpawnEnemy(wave.enemies[z].enemy);
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
            if (waveNumber == waves.Length)
            {
                Debug.Log("TODO - End Level");
                this.enabled = false;
            }
        }
        waveNumber++;
    }
    //Wave Class
    [System.Serializable]
    public class Wave
    {
        public float spawnRate;
        public WaveGroup[] enemies;
        [System.Serializable]
        public class WaveGroup
        {
            public GameObject enemy;
            public int count;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }

}
