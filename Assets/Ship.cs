using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    // Update is called once per frame

    public GameObject brokenVersion;

    public AudioClip explosion;
    public AudioClip shield;

    private void OnCollisionEnter(Collision collision)
    {
        if (GlobalState.hasEmergencyShieldUpgrade && (GlobalState.emergencyShieldLife > 0))
        {
            GlobalState.emergencyShieldLife--;
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f, transform.position, 5000f);
            GetComponentInParent<AudioSource>().clip = shield;
            GetComponentInParent<AudioSource>().Play();


            return;
        }

        GameObject destroyed = Instantiate(brokenVersion, transform.position, transform.rotation);
        destroyed.transform.parent = transform.parent;

        AudioSource s = GetComponentInParent<AudioSource>();

        if (s != null)
        {
            s.clip = explosion;
            s.Play();
        }
        Destroy(gameObject);

        GameObject.Find("LevelController").GetComponent<LevelController>().alive = false;
    }

    void Update () {
        float verticalAngle = transform.eulerAngles.x;
        float horizontalAngle = transform.eulerAngles.y;
        bool rollbackVertical = true;
        bool rollbackHorizontal= true;


        verticalAngle = Input.GetAxis("Vertical") * -10f;
        horizontalAngle = Input.GetAxis("Horizontal") * 10f;

        transform.eulerAngles = new Vector3(verticalAngle, horizontalAngle, 0);

        return;

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
