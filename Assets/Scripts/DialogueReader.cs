using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueReader : MonoBehaviour
{
    public string[] entries;
    private int lineNum = 0;
    private string option;
    private string[] choiceActions = new string[6];
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
    public Text currentText;

    // Use this for initialization
    void Start ()
    {
        entries = dialogue.text.Split('\n');
        for (int i = 0; i < entries.Length; i++)
        {
            Debug.Log(entries[i]);
            if(entries[i] == null)
            {
                Debug.Log("not a string");
            }
        }
        NextLine();
    }

    void Update ()
    {

    }

    public void NextLine()
    {
        message.text = "";
        option1.text = "";
        option2.text = "";
        option3.text = "";
        option4.text = "";
        option5.text = "";
        option6.text = "";
        if (entries[lineNum].IndexOf("@") == 0)
        {
            lineNum++;
            NextLine();
            return;
        }
        else
        {
            string[] currentLine = entries[lineNum].Split(' ');
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
                        option1.gameObject.SetActive(true);
                        choiceActions[0] = currentLine[i + 1];
                        i++;
                        break;
                    case "#option2":
                        option2.gameObject.SetActive(true);
                        choiceActions[1] = currentLine[i + 1];
                        i++;
                        break;
                    case "#option3":
                        option3.gameObject.SetActive(true);
                        choiceActions[2] = currentLine[i + 1];
                        i++;
                        break;
                    case "#option4":
                        option4.gameObject.SetActive(true);
                        choiceActions[3] = currentLine[i + 1];
                        i++;
                        break;
                    case "#option5":
                        option5.gameObject.SetActive(true);
                        choiceActions[4] = currentLine[i + 1];
                        i++;
                        break;
                    case "#option6":
                        option6.gameObject.SetActive(true);
                        choiceActions[5] = currentLine[i + 1];
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
