using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject[] asteroidPrefabs;

    public GameObject ship;

    private float wideness = 1000f;
    private float initialDepth = 2500f;

    private int maxSmallInstances = 3000;
    private int maxBigInstances = 40;

    private List<GameObject> smallInstances;
    private List<GameObject> bigInstances;

    // Use this for initialization
    void Start () {
        smallInstances = new List<GameObject>();
        bigInstances = new List<GameObject>();

        Refill(smallInstances, maxSmallInstances, false);
        RefillBig(bigInstances, maxBigInstances, false);
    }
	
    void Refill(List<GameObject> instances, int amount, bool fixedDepth)
    {
        for (int i = instances.Count; i < amount; i++)
        {
            float depth = fixedDepth ? Random.Range(initialDepth, initialDepth * 2) : Random.Range(0f, initialDepth);

            GameObject asteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length - 1)];
            Quaternion quaternion = new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector3 position = ship.transform.position + new Vector3(Random.Range(-wideness, wideness), Random.Range(-wideness, wideness), depth);

            GameObject instance = Instantiate(asteroid, position, quaternion);

            float scale = Random.Range(4, 10);
            instance.transform.localScale = new Vector3(scale, scale, scale);
            instance.GetComponent<Rigidbody>().mass = scale;

            instances.Add(instance);
        }
    }

    void RefillBig(List<GameObject> instances, int amount, bool fixedDepth)
    {
        for (int i = instances.Count; i < amount; i++)
        {
            float depth = fixedDepth ? Random.Range(initialDepth, initialDepth * 2) : Random.Range(0f, initialDepth);

            GameObject asteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length - 1)];
            Quaternion quaternion = new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector3 position = ship.transform.position + new Vector3(Random.Range(-wideness/2, wideness / 2), Random.Range(-wideness / 2, wideness / 2), depth);

            GameObject instance = Instantiate(asteroid, position, quaternion);

            float scale = Random.Range(20, 50);
            instance.transform.localScale = new Vector3(scale, scale, scale);
            instance.GetComponent<Rigidbody>().mass = scale;

            instances.Add(instance);
        }
    }

	// Update is called once per frame
	void Update () {
		foreach (GameObject instance in smallInstances.ToArray())
        {
            if (instance.transform.position.z < (ship.transform.position.z - 10f))
            {
                smallInstances.Remove(instance);
                Destroy(instance);
            }
        }

        foreach (GameObject instance in bigInstances.ToArray())
        {
            if (instance.transform.position.z < (ship.transform.position.z - 10f))
            {
                bigInstances.Remove(instance);
                Destroy(instance);
            }
        }

        Refill(smallInstances, maxSmallInstances, true);
        RefillBig(bigInstances, maxBigInstances, true);
    }
}
