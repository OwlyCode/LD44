using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour {

    [TextAreaAttribute(3, 10)]
    public string[] messages;
    Queue<string> queue;

    public GameObject text;
    string currentMessage = null;

    public GameObject nextButton;
    public GameObject leaveButton;
    public GameObject engineUpgradeMk1;
    public GameObject engineUpgradeMk2;
    public GameObject emergencyShild;
    public GameObject deflector;

    public int level = 1;

    // Use this for initialization
    void Start () {
        queue = new Queue<string>(messages);
        ShowMessage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowMessage()
    {
        if (queue.Count > 0)
        {
            currentMessage = queue.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence());
            leaveButton.GetComponent<Button>().interactable = false;
        } else {
            nextButton.GetComponent<Button>().interactable = false;
            leaveButton.GetComponent<Button>().interactable = true;

            engineUpgradeMk1.SetActive(!GlobalState.hasMk1Upgrade && level > 0);
            engineUpgradeMk2.SetActive(!GlobalState.hasMk2Upgrade && level > 1);
            emergencyShild.SetActive(!GlobalState.hasEmergencyShieldUpgrade && level > 2);
            deflector.SetActive(!GlobalState.hasDeflector && level > 3);
        }
    }

    IEnumerator TypeSentence()
    {
        text.GetComponent<Text>().text = "";
        int i = 0;

        foreach (char letter in currentMessage.ToCharArray())
        {
            text.GetComponent<Text>().text += letter;
            if (i % 3 == 0)
            {
                yield return null;
            }

            i++;
        }
    }
}
