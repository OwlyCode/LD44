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

        if (GlobalState.respawning)
        {
            GlobalState.respawning = false;
            queue = new Queue<string>();
            queue.Enqueue("AG-0409: Ship is ready for flight.");
        }

        ShowMessage();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void buyEngineMk1()
    {
        GlobalState.hasMk1Upgrade = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember... It was... exciting. That feel, to be alive. After the battle we were just happy to breathe.");
        queue.Enqueue("Stokes: Process complete!");

        ShowMessage();
        RefreshButtons();
    }

    public void buyEngineMk2()
    {
        GlobalState.hasMk2Upgrade = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember... Her... Her perfume, her voice. How would I forget that? We met at the military school, she became flight instructor. I would have sold the world for her.");
        queue.Enqueue("Stokes: Process complete!");

        ShowMessage();
        RefreshButtons();
    }

    public void buyEmergency()
    {
        GlobalState.hasEmergencyShieldUpgrade = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember... We were happy. The sun of the Earth summer, the smell of the wheat before the harvest. We used to build wooden huts and swords in the garden.");
        queue.Enqueue("Stokes: Process complete!");

        ShowMessage();
        RefreshButtons();
    }

    public void buyDeflector()
    {
        GlobalState.hasDeflector = true;

        queue.Enqueue("Stokes: Wonderful! Let me plug this here, and that here.");
        queue.Enqueue("Captain: I remember... Mother. She gave life to me, taught me to walk, speak and behave. When I left for the navy she cried for weeks. I'm scared I'll never see her again.");
        queue.Enqueue("Stokes: Process complete!");

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
        deflector.SetActive(queue.Count == 0 && GlobalState.hasEmergencyShieldUpgrade && !GlobalState.hasDeflector && level > 3);
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
            nextButton.GetComponent<Button>().Select();
        }

        if (queue.Count == 0)
        {
            leaveButton.GetComponent<Button>().interactable = true;
            leaveButton.GetComponent<Button>().Select();
            nextButton.GetComponent<Button>().interactable = false;
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
