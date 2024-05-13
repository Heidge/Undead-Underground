using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public int waveNumber = 1;
    public int zombieNumber = 1;
    public GameObject[] zombiesPrefab;
    public GameObject[] spawnPoints;
    public static Waves instance;

    void Awake()
    {
		if (instance == null)
			instance = this;
	}

    void Start()
    {
        waveNumber = 1;
        zombieNumber = 1;
        StartCoroutine(WavesTransition());
    }

    public IEnumerator WavesTransition()
	{
        zombieNumber = 0 + 1 * waveNumber;
		yield return new WaitForSeconds(1.0f);
		StartWave();
	}

    void StartWave()
    {
        for (int i = 0; i < zombieNumber; i++)
        {
			int randomZombie = Random.Range(0, zombiesPrefab.Length);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(zombiesPrefab[randomZombie], spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
		}
		waveNumber++;
	}

}
