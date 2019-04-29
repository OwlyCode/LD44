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
    }
}
