using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class DialogueReader : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        entries = dialogue.text.Split('\n');
        //NextLine();
        for (int i = 0; i < entries.Length; i++)
        {
            Debug.Log(entries[i]);
        }
    }

    void Update ()
    {

    }

    private string[] entries;
    private string[] currentLine;
    private int lineNum = 0;
    private string option;
    public string[] choiceActions;
    public int selected = 0;
    public TextAsset dialogue;
    public GameObject dialogueContainer;
    public GameObject nextButton;
    public bool clueOneFound = false;
    public bool clueTwoFound = false;
    public bool clueThreeFound = false;
    public bool clueFourFound = false;
    public bool clueFiveFound = false;
    public bool clueSixFound = false;
    public Text message;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    public Text option5;
    public Text option6;
    private Text currentText;

    public void NextLine()
    {
        message.text = "";
        option1.text = "";
        option2.text = "";
        option3.text = "";
        option4.text = "";
        option5.text = "";
        option6.text = "";
        currentLine = entries[lineNum].Split(' ');
        if (currentLine[lineNum].IndexOf("@") == 0)
        {
            lineNum++;
            NextLine();
            return;
        }
        else
        {
            for (int i = 0; i < currentLine.Length; i++)
            {
                switch (currentLine[i])
                {

                    case "#SetDialogue":
                        message.gameObject.SetActive(true);
                        option1.gameObject.SetActive(false);
                        option2.gameObject.SetActive(false);
                        option3.gameObject.SetActive(false);
                        option4.gameObject.SetActive(false);
                        option5.gameObject.SetActive(false);
                        option6.gameObject.SetActive(false);
                        currentText = message;
                        nextButton.SetActive(true);
                        break;
                    case "#SetOptions":
                        message.gameObject.SetActive(false);
                        nextButton.SetActive(false);
                        break;
                    case "#option1":
                        choiceActions[0] = currentLine[i + 1];
                        option1.gameObject.SetActive(true);
                        i++;
                        break;
                    case "#option2":
                        choiceActions[1] = currentLine[i + 1];
                        option2.gameObject.SetActive(true);
                        i++;
                        break;
                    case "#option3":
                        choiceActions[2] = currentLine[i + 1];
                        option3.gameObject.SetActive(true);
                        i++;
                        break;
                    case "#option4":
                        choiceActions[3] = currentLine[i + 1];
                        option4.gameObject.SetActive(true);
                        i++;
                        break;
                    case "#option5":
                        choiceActions[4] = currentLine[i + 1];
                        option5.gameObject.SetActive(true);
                        i++;
                        break;
                    case "#option6":
                        choiceActions[5] = currentLine[i + 1];
                        option6.gameObject.SetActive(true);
                        i++;
                        break;
                    case "#clueonefound":
                        if (clueOneFound)
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#yes")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#no")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        break;
                    case "#cluetwofound":
                        if (clueTwoFound)
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#yes")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#no")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        break;
                    case "#cluethreefound":
                        if (clueThreeFound)
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#yes")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#no")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        break;
                    case "#cluefourfound":
                        if (clueFourFound)
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#yes")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#no")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        break;
                    case "#cluefivefound":
                        if (clueFiveFound)
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#yes")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#no")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        break;
                    case "#cluesixfound":
                        if (clueSixFound)
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#yes")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < currentLine.Length; j++)
                            {
                                if (currentLine[j] == "#no")
                                {
                                    i = j - 1;
                                }
                            }
                        }
                        break;
                    case "#yes":
                        break;
                    case "#no":
                        break;
                    case "#option1Text":
                        currentText = option1;
                        break;
                    case "#option2Text":
                        currentText = option2;
                        break;
                    case "#option3Text":
                        currentText = option3;
                        break;
                    case "#option4Text":
                        currentText = option4;
                        break;
                    case "#option5Text":
                        currentText = option5;
                        break;
                    case "#option6Text":
                        currentText = option6;
                        break;
                    case "#quit":
                        EndDialogue();
                        break;
                    default:
                        if (currentLine[i].Contains("#goto"))
                        {
                            string location = currentLine[i].Split(':')[1];
                            GoTo(location);
                        }
                        else
                        {
                            if(i == 0)
                            {
                                Debug.Log(currentLine[i]);
                            }
                            else
                            {
                                Debug.Log(" " + currentLine[i]);
                            }
                        }
                        break;
                }
            }
            lineNum += 1;
        }
        if (message.text == "" && option1.text == "" && option2.text == "" && option3.text == "" && option4.text == "" && option5.text == "" && option6.text == "")
        {
            NextLine();
            return;
        }
    }

    private void GoTo(string location)
    {
        for(int i = 0; i < entries.Length; i++)
        {
            if(entries[i] == "@" + location)
            {
                lineNum = i;
                break;
            }
        }
        NextLine();
    }

    public void EndDialogue()
    {
        dialogueContainer.SetActive(false);
    }

    public void StartDialogue()
    {
        lineNum = 0;
        message.text = "";
        option1.text = "";
        option2.text = "";
        option3.text = "";
        option4.text = "";
        option5.text = "";
        option6.text = "";
        currentText = message;
        dialogueContainer.SetActive(true);
        message.gameObject.SetActive(true);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        option5.gameObject.SetActive(false);
        option6.gameObject.SetActive(false);
        nextButton.SetActive(true);
        NextLine();
    }

    public void ChooseOption(int optionNumber)
    {
        if (choiceActions[optionNumber].Contains("#goto:"))
        {
            string locationName = choiceActions[optionNumber].Split(':')[1];
            GoTo(locationName);
        }
    }

    private void Quit()
    {

    }
}
