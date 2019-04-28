using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerV2 : MonoBehaviour {

    public GameObject[] asteroidPrefabs;
    public Vector3 sampleRegionSize = Vector3.one;
    public int rejectionSamples = 30;

    List<Vector3> points;

    public float speed = 0f;

    public void SpawnAsteroids(float spacing, float scale, float agitation)
    {
        points = PoissonSphere.GeneratePoints(spacing, sampleRegionSize, rejectionSamples);

        foreach (Vector3 point in points)
        {
            GameObject instance = Instantiate(asteroidPrefabs[0], transform.position - sampleRegionSize / 2 + point, Quaternion.identity);

            instance.transform.localScale = new Vector3(scale, scale, scale);
            instance.GetComponent<Asteroid>().Stimulate(agitation);
            instance.transform.parent = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.back * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, sampleRegionSize);
    }
}
