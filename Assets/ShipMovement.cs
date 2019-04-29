using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    float translationSpeed = 25f;

    void Start()
    {
        if (GlobalState.hasMk1Upgrade)
        {
            translationSpeed = 35f;
        }

        if (GlobalState.hasMk2Upgrade)
        {
            translationSpeed = 45f;
        }
    }

    void Update()
    {

        transform.position = transform.position + Vector3.up * Input.GetAxis("Vertical") * translationSpeed;
        transform.position = transform.position + Vector3.right * Input.GetAxis("Horizontal") * translationSpeed;

        return;
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
