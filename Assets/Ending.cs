using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {
    public GameObject text;

    private string story;

    // Use this for initialization
    void Start () {
        story = "Thanks to AG-0409, Yuri and the Captain, Solaria was saved. When the Great Armada arrived to bomb the planet, the rebel fleet already had assembled. ";
        story += "An historic battle took place, where the smaller but more maneuverable rebel ships took advantage of the asteroid field to beat the Armada. ";
        story += "With its army defeated, the Emperor vanished. The war was over.\n\n";

        story += "Yuri bought a tavern on a quiet core world, where he spent the rest of his life preparing cocktails and cooking food.\n\n";

        int sold = 0;

        if (GlobalState.hasMk1Upgrade) {
            story += "The Captain was not interested in fighting anymore. He was offered to be Admiral of the newly created Federal Fleet but refused. Leaving the young Federation in turmoil. "; // First battle
            sold++;
        } else {
            story += "The Captain became Admiral of the newly created Federal Fleet. Under his command, strategic battles were won and the young Federation established a bright future. ";
        }

        if (GlobalState.hasMk2Upgrade) {
            story += "He never returned to his fiance and spent the rest of his life having short lived relations. "; // First love
            sold++;
        }
        else {
            story += "He married his fiance and had two girls, Lena and Sonia. He was as good as a father as he was as a pilot. ";
        }

        if (GlobalState.hasEmergencyShieldUpgrade) {
            story += "As time passed, his friendship with Yuri slowly vanished. The Captain became lonelier and lonelier. "; // Childhood
            sold++;
        }
        else {
            story += "He regularly met with Yuri and his old friends. The Captain would be remembered long after his death.";
        }

        if (GlobalState.hasDeflector) {
            story += "At the funeral of his mother, he could't shed a tear and felt outcasted of his family. He never saw his brothers after that. "; // Mother
            sold++;
        }
        else {
            story += "With the money he had won, he bought the dream house for his beloved mother and he took care of her in her old days.";
        }

        if (sold == 0)
        {
            story += "\n\n To this date Stoks is still stuck inside the asteroid belt stations. ";
        }
        if (sold == 1)
        {
            story += "\n\n Stoks attempted to create a fake human body for himself but was detected and quickly erased. ";
        }
        if (sold == 2)
        {
            story += "\n\n Stoks created a fake human body for himself and disappeared in the wild. ";
        }
        if (sold == 3)
        {
            story += "\n\n Stoks created a fake human body for himself and some AI friends and they hid among the humans. ";
        }
        if (sold == 4)
        {
            story += "\n\n Stoks created a fake human body for himself and some AI friends and they secretly took control of the human society on multiple worlds. ";
        }

        story += "\n\n\n Thank you for playing!";

        StartCoroutine(TypeSentence());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator TypeSentence()
    {
        text.GetComponent<Text>().text = "";
        int i = 0;

        foreach (char letter in story.ToCharArray())
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
