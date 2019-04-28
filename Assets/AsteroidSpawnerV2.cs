using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerV2 : MonoBehaviour {

    public GameObject[] asteroidPrefabs;
    public Vector3 sampleRegionSize = Vector3.one;
    public int rejectionSamples = 30;

    public float speed = 0f;

    public IEnumerator SpawnAsteroids(float spacing, float scale, float agitation)
    {
        List<Vector3> points = PoissonSphere.GeneratePoints(spacing, sampleRegionSize, rejectionSamples);

        yield return SpawnAsteroids(points, scale, agitation);
    }

    public IEnumerator SpawnAsteroids(List<Vector3> points, float scale, float agitation)
    {
        foreach (Vector3 point in points)
        {
            GameObject instance = Instantiate(asteroidPrefabs[0], transform.position - sampleRegionSize / 2 + point, Quaternion.identity);

            instance.transform.localScale = new Vector3(scale, scale, scale);
            instance.GetComponent<Asteroid>().Stimulate(agitation);
            instance.transform.parent = transform;
        }

        yield return null;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
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
