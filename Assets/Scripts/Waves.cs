using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public int waveNumber = 1;
    public int zombieNumber = 0;
    public GameObject[] zombiesPrefab;
    public GameObject[] spawnPoints;
    public static Waves instance;

    // Start is called before the first frame update
    void Start()
    {
        StartWave();
    }

    void Awake()
    {
		if (instance == null)
			instance = this;
	}

    // Update is called once per frame
    void Update()
    {
		
		if (zombieNumber == 0)
        {
			zombieNumber = 5 + 5 * waveNumber;
			StartCoroutine(WavesTransition());
		}
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

	public IEnumerator WavesTransition()
	{
		yield return new WaitForSeconds(1);
		StartWave();
	}

}
