using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    // Update is called once per frame
    
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);

        //GameObject.Find("LevelController").GetComponent<LevelController>().alive = false;

        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10f, transform.position, 1000f);
    }

    void Update () {

        float verticalAngle = transform.eulerAngles.x;
        float horizontalAngle = transform.eulerAngles.y;
        bool rollbackVertical = true;
        bool rollbackHorizontal= true;


        if (Input.GetKey("up"))
        {
            verticalAngle = Mathf.MoveTowardsAngle(verticalAngle, -10f, Time.deltaTime * 50f);
            rollbackVertical = false;
        }

        if (Input.GetKey("down"))
        {
            verticalAngle = Mathf.MoveTowardsAngle(verticalAngle, 10f, Time.deltaTime * 50f);
            rollbackVertical = false;
        }
 

        if (Input.GetKey("left"))
        {
            horizontalAngle = Mathf.MoveTowardsAngle(horizontalAngle, -10f, Time.deltaTime * 50f);
            rollbackHorizontal = false;
        }

        if (Input.GetKey("right"))
        {
            horizontalAngle = Mathf.MoveTowardsAngle(horizontalAngle, 10f, Time.deltaTime * 50f);
            rollbackHorizontal = false;
        }

        if (rollbackVertical)
        {
            verticalAngle = Mathf.MoveTowardsAngle(verticalAngle, 0, Time.deltaTime * 50f);
        }

        if (rollbackHorizontal)
        {
            horizontalAngle = Mathf.MoveTowardsAngle(horizontalAngle, 0, Time.deltaTime * 50f);
        }

        transform.eulerAngles = new Vector3(verticalAngle, horizontalAngle, 0);
    }
}
