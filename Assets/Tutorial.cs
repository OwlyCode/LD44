using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    LevelController level;
    ShipMovement ship;
    public Dialog[] dialogs;
    Queue<Dialog> dialogsQueue;
    Dialog stagedDialog = null;
    bool ending = false;

	// Use this for initialization
	void Start () {
        dialogsQueue = new Queue<Dialog>(dialogs);
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
        if (!ending)
        {
            ship.speed = Mathf.Clamp(5f + Mathf.Round(level.GetDistance() / 1000f), 10f, 45f);
        } else {
            ship.speed = 45f * (180000f - level.GetDistance())/(180000f - 160000f);
        }

        level.agitation = level.GetDistance() / 15000f;

        if (dialogsQueue.Count > 0 && stagedDialog == null)
        {
            stagedDialog = dialogsQueue.Dequeue();
        }

        if (stagedDialog != null && stagedDialog.distance < level.GetDistance())
        {
            GetComponent<DialogManager>().Enqueue(stagedDialog.content);
            stagedDialog = null;
        }

        if (level.GetDistance() > 20000)
        {
            level.spacing = 1550f;
        }

        if (level.GetDistance() > 40000)
        {
            level.spacing = 1500f;
        }

        if (level.GetDistance() > 60000)
        {
            level.spacing = 1400f;
        }

        if (level.GetDistance() > 100000)
        {
            level.spacing = 1300f;
        }

        if (level.GetDistance() > 120000)
        {
            level.spacing = 2000f;
        }

        if (level.GetDistance() > 160000)
        {
            ending = true;
            level.spacing = 200000f;
        }
    }
}
