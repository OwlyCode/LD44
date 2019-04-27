using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    float agitation = 5f;
    float rotation = 10f;

    // Use this for initialization
    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(Random.Range(-rotation, rotation), Random.Range(-rotation, rotation), Random.Range(-rotation, rotation)) * rotation);
        rb.AddForce(new Vector3(Random.Range(-agitation, agitation), Random.Range(-agitation, agitation), Random.Range(-agitation, 0)), ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
