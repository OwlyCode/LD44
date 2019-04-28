using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    LevelController level;
    ShipMovement ship;
    public Dialog[] dialogs;

    Queue<Dialog> dialogsQueue;
    Dialog stagedDialog = null;

	// Use this for initialization
	void Start () {
        dialogsQueue = new Queue<Dialog>(dialogs);
	}
}
