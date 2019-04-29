using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    float translationSpeed = 25 * 60f;

    void Start()
    {
        if (GlobalState.hasMk1Upgrade)
        {
            translationSpeed = 35 * 50f;
        }

        if (GlobalState.hasMk2Upgrade)
        {
            translationSpeed = 45 * 50f;
        }
    }

    void Update()
    {

        transform.position = transform.position + Vector3.up * Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime;
        transform.position = transform.position + Vector3.right * Input.GetAxis("Horizontal") * translationSpeed* Time.deltaTime;
    }
}
