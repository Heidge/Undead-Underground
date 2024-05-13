using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public int waveNumber = 1;
    public int zombieNumber = 10;
    public GameObject[] zombiesPrefab;
    public GameObject[] spawnPoints;
    public static Waves instance;
    private AudioSource audioSource;

    void Awake()
    {
		if (instance == null)
			instance = this;
        audioSource = GetComponent<AudioSource>();
	}

    void Start()
    {
        waveNumber = 1;
        zombieNumber = 10;
        StartCoroutine(WavesTransition());
    }

    public IEnumerator WavesTransition()
	{
        zombieNumber = 5 + 5 * waveNumber;
		yield return new WaitForSeconds(20.0f);
		StartWave();
	}

    void StartWave()
    {
                if (audioSource.isPlaying == false)
            audioSource.Play();
        for (int i = 0; i < zombieNumber; i++)
        {
			int randomZombie = Random.Range(0, zombiesPrefab.Length);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(zombiesPrefab[randomZombie], spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
		}
		waveNumber++;
	}

}
