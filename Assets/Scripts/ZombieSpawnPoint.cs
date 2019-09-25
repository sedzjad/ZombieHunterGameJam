using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieSpawnPoint : MonoBehaviour
{

    public GameObject Zombie;
	public Action<GameObject> ZombieSpawned;

    public float SpawnInterval;
    public float NextSpawn;

    void Start()
    {
        NextSpawn = Time.time + SpawnInterval;
    }

    void Update()
    {
        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnInterval;
            SpawnZombie();
        }
    }

    public void SpawnZombie()
    {
		GameObject spawnedZombie = Instantiate(Zombie, transform.position, transform.rotation);
		if (ZombieSpawned != null) {
			ZombieSpawned(spawnedZombie);
		}

	}
}
