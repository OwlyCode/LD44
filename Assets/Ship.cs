using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    private float speed = 1f;
    private float translationSpeed = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.forward * speed;

        if (Input.GetKey("up"))
        {
            transform.position = transform.position + Vector3.up * translationSpeed;
        }

        if (Input.GetKey("down"))
        {
            transform.position = transform.position + Vector3.down * translationSpeed;
        }
   
        if (Input.GetKey("left"))
        {
            transform.position = transform.position + Vector3.left * translationSpeed;
        }

        if (Input.GetKey("right"))
        {
            transform.position = transform.position + Vector3.right * translationSpeed;
        }
    }
}
