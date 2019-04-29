using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StationContainer : MonoBehaviour {

    public string nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ship>() != null)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
