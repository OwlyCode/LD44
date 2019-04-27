using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public GameObject asteroidSpawner;
    public GameObject ship;

    GameObject oldSpawner;
    GameObject currentSpawner;

    public float spacing = 800f;
    public float scale = 100f;
    public float agitation = 80f;

    float startingPosition;

    public int chunkCrossed = 0;

    public float GetDistance()
    {
        return enabled ? ship.transform.position.z - startingPosition : 0f;
    }

    // Use this for initialization
    void Start ()
    {
        startingPosition = ship.transform.position.z;

        oldSpawner = Instantiate(asteroidSpawner, Vector3.zero, Quaternion.identity);
        currentSpawner = Instantiate(asteroidSpawner, Vector3.zero + new Vector3(0, 0, oldSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z), Quaternion.identity);

        oldSpawner.GetComponent<AsteroidSpawnerV2>().SpawnAsteroids(spacing, scale, agitation);
        currentSpawner.GetComponent<AsteroidSpawnerV2>().SpawnAsteroids(spacing, scale, agitation);
    }

    // Update is called once per frame
    void Update () {
		if (currentSpawner.transform.position.z < ship.transform.position.z)
        {
            chunkCrossed++;
            Destroy(oldSpawner);
            oldSpawner = currentSpawner;
            currentSpawner = Instantiate(asteroidSpawner, oldSpawner.transform.position + new Vector3(0,0, oldSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z), Quaternion.identity);
            currentSpawner.GetComponent<AsteroidSpawnerV2>().SpawnAsteroids(spacing, scale, agitation);
        }
	}
}
