using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    	
    public void Stimulate(float strength)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        float rotation = strength / 2f;
        float agitation = strength * 20f;

        rb.AddTorque(new Vector3(Random.Range(-rotation, rotation), Random.Range(-rotation, rotation), Random.Range(-rotation, rotation)) * rotation);
        rb.AddForce(new Vector3(Random.Range(-agitation, agitation), Random.Range(-agitation, agitation), Random.Range(-agitation, 0)), ForceMode.Impulse);
    }


    private void Start()
    {
        transform.localEulerAngles = new Vector3(Random.Range(0, 365), Random.Range(0, 365), Random.Range(0, 365));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
