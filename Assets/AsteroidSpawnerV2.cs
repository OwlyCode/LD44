using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerV2 : MonoBehaviour {

    public GameObject[] asteroidPrefabs;

    public float radius = 8;
    public Vector3 sampleRegionSize = Vector3.one;
    public int rejectionSamples = 30;
    public float displayRadius = 0.1f;

    List<Vector3> points;

    // Use this for initialization
    void Start () {
        points = PoissonSphere.GeneratePoints(radius, sampleRegionSize, rejectionSamples);

        foreach(Vector3 point in points)
        {
            Instantiate(asteroidPrefabs[0], transform.position - sampleRegionSize/2 + point, Quaternion.identity);
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
