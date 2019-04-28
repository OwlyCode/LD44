using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject box;
    public GameObject text;

    public float lifetime = 10f;
    float currentLife = 0f;

    Queue<string> messages;
    string currentMessage = null;


	// Use this for initialization
	void Start () {
        messages = new Queue<string>();

        box.GetComponent<Animator>().SetBool("isOpen", false);
	}
	
    public void Enqueue(string message)
    {
        messages.Enqueue(message);
    }

    IEnumerator TypeSentence()
    {
        text.GetComponent<Text>().text = "";
        int i = 0;

        foreach (char letter in currentMessage.ToCharArray())
        {
            text.GetComponent<Text>().text += letter;
            if (i%3 == 0)
            {
                yield return null;
            }

            i++;
        }
    }

    public void EndAllDialogs()
    {
        currentLife = -1;
    }

    void Update () {
        currentLife -= Time.deltaTime;

        if (currentLife < 0)
        {
            if (messages.Count == 0)
            {
                box.GetComponent<Animator>().SetBool("isOpen", false);
            } else {
                currentLife = lifetime;
                box.GetComponent<Animator>().SetBool("isOpen", true);
                currentMessage = messages.Dequeue();
                StartCoroutine(TypeSentence());
            }
        }
    }
}
