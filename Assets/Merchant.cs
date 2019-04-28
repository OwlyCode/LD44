using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void buyEngineMk1()
    {
        GlobalState.hasMk1Upgrade = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember...");
        ShowMessage();
        RefreshButtons();
    }

    public void buyEngineMk2()
    {
        GlobalState.hasMk2Upgrade = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember...");
        ShowMessage();
        RefreshButtons();
    }

    public void buyEmergency()
    {
        GlobalState.hasEmergencyShieldUpgrade = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember...");
        ShowMessage();
        RefreshButtons();
    }

    public void buyDeflector()
    {
        GlobalState.hasDeflector = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember...");
        ShowMessage();
        RefreshButtons();
    }

    public void LeaveStation()
    {
        SceneManager.LoadScene("Level" + level);
    }


    void RefreshButtons()
    {
        engineUpgradeMk1.SetActive(queue.Count == 0 && !GlobalState.hasMk1Upgrade && level > 0);
        engineUpgradeMk2.SetActive(queue.Count == 0 && GlobalState.hasMk1Upgrade && !GlobalState.hasMk2Upgrade && level > 1);
        emergencyShild.SetActive(queue.Count == 0 && !GlobalState.hasEmergencyShieldUpgrade && level > 2);
        deflector.SetActive(queue.Count == 0 && !GlobalState.hasDeflector && level > 3);
    }

    public void ShowMessage()
    {
        if (queue.Count > 0)
        {
            currentMessage = queue.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence());
            leaveButton.GetComponent<Button>().interactable = false;
            nextButton.GetComponent<Button>().interactable = true;
        }
       
        if (queue.Count == 0)
        {
            nextButton.GetComponent<Button>().interactable = false;
            leaveButton.GetComponent<Button>().interactable = true;

            RefreshButtons();
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
