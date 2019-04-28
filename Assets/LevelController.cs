using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public GameObject asteroidSpawner;
    public GameObject ship;
    public GameObject stationPrefab;
    public string nextLevel;

    GameObject oldSpawner;
    GameObject currentSpawner;

    public ChunkSettings[] chunkSettings;
    List<ChunkSettings> expandedChunkList;

    public Dialog[] dialogs;

    Queue<Dialog> dialogsQueue;
    Dialog stagedDialog = null;

    float startingPosition;

    int chunkCrossed = 0;

    public float speed = 0f;

    public bool alive = true;

    public float GetDistance()
    {
        return enabled ? ship.transform.position.z - startingPosition : 0f;
    }

    void SpawnChunk(int offset)
    {
        if (expandedChunkList.Count - 1 < offset)
        {
            return;
        }

        if (oldSpawner != null)
        {
            Destroy(oldSpawner);
        }

        oldSpawner = currentSpawner;

        Vector3 position = Vector3.zero;

        if (oldSpawner != null)
        {
            position = new Vector3(0, 0, oldSpawner.transform.position.z);
        }

        float spacing = expandedChunkList[offset].spacing;
        float scale = expandedChunkList[offset].scale;
        float agitation = expandedChunkList[offset].agitation;

        currentSpawner = Instantiate(asteroidSpawner, position + new Vector3(ship.transform.position.x, ship.transform.position.y, asteroidSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z), Quaternion.identity);
        currentSpawner.GetComponent<AsteroidSpawnerV2>().SpawnAsteroids(spacing, scale, agitation);
    }

    void SpawnStation(float z)
    {
        Vector3 position = new Vector3(0, 0, z) + new Vector3(ship.transform.position.x, ship.transform.position.y, asteroidSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z);
        GameObject station = Instantiate(stationPrefab, position, Quaternion.identity);

        station.transform.parent = currentSpawner.transform;
        station.GetComponent<Station>().nextLevel = nextLevel;
    }

    void Start ()
    {
        dialogsQueue = new Queue<Dialog>(dialogs);
        expandedChunkList = new List<ChunkSettings>();

        foreach (ChunkSettings settings in chunkSettings)
        {
            for (int i = 0; i < settings.repeat; i++)
            {
                expandedChunkList.Add(settings);
            }
        }

        startingPosition = ship.transform.position.z;
        SpawnChunk(0);
    }

    void Update () {

        float chunkSize = asteroidSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z;
        float chunkZ = currentSpawner.transform.position.z - chunkSize / 2;
        float chunkProgression = 1f - (chunkZ - ship.transform.position.z) / chunkSize;

        if (alive && (dialogsQueue.Count > 0 && stagedDialog == null))
        {
            stagedDialog = dialogsQueue.Dequeue();
        }

        if ((stagedDialog != null) && stagedDialog.chunk <= chunkCrossed)
        {
            GetComponent<DialogManager>().Enqueue(stagedDialog.content);
            stagedDialog = null;
        }

        if (expandedChunkList.Count > chunkCrossed)
        {
            float oldSpeed = 0f;

            if (chunkCrossed > 0) {
                oldSpeed = expandedChunkList[chunkCrossed - 1].targetSpeed;
            }

            speed = Mathf.Lerp(oldSpeed, expandedChunkList[chunkCrossed].targetSpeed, chunkProgression);
        }

        if (!alive)
        {
            GetComponent<DialogManager>().EndAllDialogs();
            speed = -0.2f;
        }


        if (oldSpawner != null)
        {
            oldSpawner.GetComponent<AsteroidSpawnerV2>().speed = speed;
        }

        currentSpawner.GetComponent<AsteroidSpawnerV2>().speed = speed;

        if ((currentSpawner.transform.position.z - asteroidSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z/2) < ship.transform.position.z)
        {
            chunkCrossed++;
            SpawnChunk(chunkCrossed);
            if (chunkCrossed == expandedChunkList.Count - 1)
            {
                SpawnStation(currentSpawner.transform.position.z - asteroidSpawner.GetComponent<AsteroidSpawnerV2>().sampleRegionSize.z);
            }
        }
	}
}
