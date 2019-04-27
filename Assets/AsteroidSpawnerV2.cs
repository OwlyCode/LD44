using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerV2 : MonoBehaviour {

    public float radius = 2;
    public Vector3 sampleRegionSize = Vector3.one;
    public int rejectionSamples = 30;
    public float displayRadius = 0.1f;

    List<Vector3> points;

    // Use this for initialization
    void Start () {
       points = PoissonSphere.GeneratePoints(radius, sampleRegionSize, rejectionSamples);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnValidate()
    {
        points = PoissonSphere.GeneratePoints(radius, sampleRegionSize, rejectionSamples);
    }

    private void OnDrawGizmos()
    {
        return;
        Gizmos.DrawWireCube(sampleRegionSize/2, sampleRegionSize);
        if (points != null)
        {
            foreach (Vector3 point in points)
            {
                Gizmos.DrawSphere(point, displayRadius);
            }
        }
    }
}
