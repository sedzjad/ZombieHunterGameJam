using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
	// Timers.
	private float timer = 0;
	private float zombieSpawnTime = 5;
	private float spawnRateMultiplier = 0.8f;

    private float maxZombiesSpawns = 0;
    private bool _stopSpawn = false;
	// Components.
	public GameObject zombie; // Drag into inspector.
	private Playtime _pt;

    public List<GameObject> ZombieList;

	private void Start() {
		_pt = FindObjectOfType<Playtime>();
		_pt.TimeAnnouncer += IncreaseSpawnRate;
        ZombieList = new List<GameObject>();
    }

	void Update()
    {
		timer = timer + 1 * Time.deltaTime;

        if (timer - zombieSpawnTime == 0) {
            if(maxZombiesSpawns <= 5)
            {
                maxZombiesSpawns++;
                if (!_stopSpawn)
                {
                    SpawnZombie();
                }
                
            }
			
		}

      
	}

	private void SpawnZombie() {
		Instantiate(zombie);
        ZombieList.Add(zombie);
	}

	private void IncreaseSpawnRate(int x) {
		zombieSpawnTime *= spawnRateMultiplier;
	}
   
}
