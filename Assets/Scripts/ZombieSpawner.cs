using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    int nextWavelimit = 10, numberWave = 1, killCounter;
    float spawnRate = 2.5f;
    public Transform[] positions;
    public GameObject[] enemies;
    GameObject waveCounter;

    void Start()
    {
        StartCoroutine(SpawnZombie(Random.Range(0, 2), Random.Range(0, positions.Length)));
        waveCounter = GameObject.Find("Wave Counter");
        Events.OnEnemyKilled.AddListener(WavesCounter); 
    }

    
    public IEnumerator SpawnZombie(int typeOfMonster, int numberPosition)
    {
        yield return new WaitForSeconds(spawnRate - 0.1f * numberWave);
        Instantiate(enemies[typeOfMonster], positions[numberPosition]);

        StartCoroutine(SpawnZombie(Random.Range(0, 2), Random.Range(0, positions.Length)));
    }
    
    void WavesCounter()
    {
        killCounter++;
        Debug.Log("Kill Counter: " + killCounter);
        Debug.Log("Next Wave Limit: " + nextWavelimit);
        Debug.Log("Spawn rate: " + spawnRate);
        waveCounter.GetComponent<TMP_Text>().text = "Wave: " + numberWave;
        if (killCounter == nextWavelimit * numberWave && numberWave < 21)
        {
            killCounter = 0;
            numberWave++;
            Debug.Log("Current wave: " + numberWave);
        }
    }
}
