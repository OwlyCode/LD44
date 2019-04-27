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
        level.spacing = 800f;
        level.scale = 100f;
        ship.speed = 10f;

        level.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        ship.speed = Mathf.Clamp(10f + Mathf.Round(level.GetDistance() / 1000f), 10f, 45f);
        level.agitation = level.GetDistance() / 15000f;
	}
}
