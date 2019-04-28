using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    float translationSpeed = 20f;

    void Update()
    {
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
