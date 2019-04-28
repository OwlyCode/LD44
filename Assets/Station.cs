using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Station : MonoBehaviour {

    float rotationSpeed = 0.05f;
    public string nextLevel;

	// Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(-25f, Random.Range(0f, 365f), 10f));
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ship>() != null)
        {
            Debug.Log("Level ended");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
