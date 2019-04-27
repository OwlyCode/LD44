using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    LevelController level;
    ShipMovement ship;

	// Use this for initialization
	void Start () {
        level = GetComponent<LevelController>();
        ship = level.ship.GetComponent<ShipMovement>();

        level.agitation = 2f;
        level.spacing = 1600f;
        level.scale = 100f;
        ship.speed = 10f;

        level.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        ship.speed = Mathf.Clamp(10f + Mathf.Round(level.GetDistance() / 1000f), 10f, 45f);
        level.agitation = level.GetDistance() / 15000f;

        if (level.chunkCrossed > 1)
        {
            level.spacing = 1550f;
        }

        if (level.chunkCrossed > 2)
        {
            level.spacing = 1500f;
        }

        if (level.chunkCrossed > 2)
        {
            level.spacing = 1400f;
        }

        if (level.chunkCrossed > 4)
        {
            level.spacing = 1300f;
        }

        if (level.chunkCrossed > 6)
        {
            level.spacing = 2000f;
        }
    }
}
