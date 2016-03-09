using UnityEngine;
using System.Collections;

public class DialogueTest : MonoBehaviour {

    public string[,] dialogue1 = { { "hello", "goodbye" }, { "hey", "bye"} };
    public string[,] dialogue2 = { { "what's up", "see ya" }, { "what", "go away" } };
    public string[,] dialogue3 = { { "I found it", "here ya go" }, { "Really?", "thanks" } };
    public GameObject testClue;
    bool testClueFound = false;
    string[,] currentDialogue;

    // Use this for initialization
    void Start ()
    {
        currentDialogue = dialogue1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int test = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(currentDialogue[0,0]);
            Debug.Log(currentDialogue[1, 0]);
            for (int i = 0; i < currentDialogue.GetLength(0); i++)
            {
                if(dialogue1[i,0] == currentDialogue[i,0] && test == 0)
                {
                    if (testClueFound)
                        currentDialogue = dialogue3;
                    else
                        currentDialogue = dialogue2;
                    test++;
                }
                else if (dialogue2[i, 0] == currentDialogue[i, 0] && test == 0)
                {
                    currentDialogue = dialogue1;
                    test++;
                }
                else if (dialogue3[i, 1] == currentDialogue[i, 1] && test == 0)
                {
                    currentDialogue = dialogue1;
                    test++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(currentDialogue[0, 1]);
            Debug.Log(currentDialogue[1, 1]);
            for (int i = 0; i < currentDialogue.GetLength(0); i++)
            {
                if (dialogue1[i, 1] == currentDialogue[i, 1] && test == 0)
                {

                    if (testClueFound)
                        currentDialogue = dialogue3;
                    else
                        currentDialogue = dialogue2;
                    test++;
                }
                else if (dialogue2[i, 1] == currentDialogue[i, 1] && test == 0)
                {
                    currentDialogue = dialogue1;
                    test++;
                }
                else if (dialogue3[i, 1] == currentDialogue[i, 1] && test == 0)
                {
                    currentDialogue = dialogue1;
                    test++;
                }
            }
        }
    }
    
}
