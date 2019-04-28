using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    float translationSpeed = 20f;

    void Start()
    {
        if (GlobalState.hasMk1Upgrade)
        {
            translationSpeed = 25f;
        }

        if (GlobalState.hasMk2Upgrade)
        {
            translationSpeed = 40f;
        }
    }

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
