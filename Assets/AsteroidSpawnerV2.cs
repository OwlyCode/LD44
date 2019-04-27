using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerV2 : MonoBehaviour {

    public GameObject[] asteroidPrefabs;

    public float spacing = 200;
    public float scale = 10f;

    public Vector3 sampleRegionSize = Vector3.one;
    public int rejectionSamples = 30;
    public float displayRadius = 0.1f;

    List<Vector3> points;
    float agitation = 8f;

    // Use this for initialization
    void Start () {
        points = PoissonSphere.GeneratePoints(spacing, sampleRegionSize, rejectionSamples);

        foreach(Vector3 point in points)
        {
            GameObject instance = Instantiate(asteroidPrefabs[0], transform.position - sampleRegionSize/2 + point, Quaternion.identity);

            instance.transform.localScale = new Vector3(scale, scale, scale);
            instance.GetComponent<Asteroid>().Stimulate(agitation);
            instance.transform.parent = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, sampleRegionSize);
    }
}
