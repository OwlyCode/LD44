using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public GameObject asteroidSpawner;
    public GameObject ship;

    GameObject oldSpawner;
    GameObject currentSpawner;

    // Use this for initialization
    void Start ()
    {
        oldSpawner = Instantiate(asteroidSpawner, Vector3.zero, Quaternion.identity);
        currentSpawner = Instantiate(asteroidSpawner, Vector3.zero + new Vector3(0, 0, oldSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		if (currentSpawner.transform.position.z < ship.transform.position.z)
        {
            Destroy(oldSpawner);
            oldSpawner = currentSpawner;
            currentSpawner = Instantiate(asteroidSpawner, oldSpawner.transform.position + new Vector3(0,0, oldSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z), Quaternion.identity);
        }
	}
}
