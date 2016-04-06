﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueReader : MonoBehaviour
{
    public string[] entries;
    private int lineNum = 0;
    private string option;
    private string[] choiceActions = new string[6];
    public TextAsset dialogue;
    public GameObject dialogueContainer;
    public GameObject nextButton;
    public GameObject clueOne;
    public GameObject clueTwo;
    public GameObject clueThree;
    public GameObject clueFour;
    public GameObject clueFive;
    public GameObject clueSix;
    bool[] ClueFound = { false, false, false, false, false, false };
    public Text message;
    public Text textbox;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    public Text option5;
    public Text option6;
    private Text currentText;

    // Use this for initialization
    void Start ()
    {
        textbox.text = "";
        entries = dialogue.text.Split('\n');
        NextLine();
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindClue();
        }
    }

    void FindClue()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if (hit)
        {
            if (hit.collider.gameObject.tag == "clue")
            {
                if (hit.collider.gameObject == clueOne)
                {
                    ClueFound[0] = true;
                    Debug.Log("Found Clue 1");
                }
                if (hit.collider.gameObject == clueTwo)
                {
                    ClueFound[1] = true;
                    Debug.Log("Found Clue 2");
                }
                if (hit.collider.gameObject == clueThree)
                {
                    ClueFound[2] = true;
                    Debug.Log("Found Clue 3");
                }
                if (hit.collider.gameObject == clueFour)
                {
                    ClueFound[3] = true;
                    Debug.Log("Found Clue 4");
                }
                if (hit.collider.gameObject == clueFive)
                {
                    ClueFound[4] = true;
                    Debug.Log("Found Clue 5");
                }
                if (hit.collider.gameObject == clueSix)
                {
                    ClueFound[5] = true;
                    Debug.Log("Found Clue 6");
                }
            }
        }
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
                string currentWord = "";
                string word = currentLine[i];
                if (i == currentLine.Length - 1)
                {
                    for (int j = 0; j < word.Length - 1; j++)
                    {
                        currentWord += word[j];
                    }
                }
                else
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        currentWord += word[j];
                    }
                }

                switch (currentWord)
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
                        if(i + 1 == currentLine.Length - 1)
                        {
                            string tempWord = currentLine[i + 1];
                            for(int j = 0; j < tempWord.Length - 1; j++)
                            {
                                choiceActions[0] += tempWord[j];
                            }
                        }
                        else
                        {
                            choiceActions[0] = currentLine[i + 1];
                        }
                        i++;
                        break;
                    case "#option2":
                        option2.gameObject.SetActive(true);
                        if (i + 1 == currentLine.Length - 1)
                        {
                            string tempWord = currentLine[i + 1];
                            for (int j = 0; j < tempWord.Length - 1; j++)
                            {
                                choiceActions[1] += tempWord[j];
                            }
                        }
                        else
                        {
                            choiceActions[1] = currentLine[i + 1];
                        }
                        i++;
                        break;
                    case "#option3":
                        option3.gameObject.SetActive(true);
                        if (i + 1 == currentLine.Length - 1)
                        {
                            string tempWord = currentLine[i + 1];
                            for (int j = 0; j < tempWord.Length - 1; j++)
                            {
                                choiceActions[2] += tempWord[j];
                            }
                        }
                        else
                        {
                            choiceActions[2] = currentLine[i + 1];
                        }
                        i++;
                        break;
                    case "#option4":
                        option4.gameObject.SetActive(true);
                        if (i + 1 == currentLine.Length - 1)
                        {
                            string tempWord = currentLine[i + 1];
                            for (int j = 0; j < tempWord.Length - 1; j++)
                            {
                                choiceActions[3] += tempWord[j];
                            }
                        }
                        else
                        {
                            choiceActions[3] = currentLine[i + 1];
                        }
                        i++;
                        break;
                    case "#option5":
                        option5.gameObject.SetActive(true);
                        if (i + 1 == currentLine.Length - 1)
                        {
                            string tempWord = currentLine[i + 1];
                            for (int j = 0; j < tempWord.Length - 1; j++)
                            {
                                choiceActions[4] += tempWord[j];
                            }
                        }
                        else
                        {
                            choiceActions[4] = currentLine[i + 1];
                        }
                        i++;
                        break;
                    case "#option6":
                        option6.gameObject.SetActive(true);
                        if (i + 1 == currentLine.Length - 1)
                        {
                            string tempWord = currentLine[i + 1];
                            for (int j = 0; j < tempWord.Length - 1; j++)
                            {
                                choiceActions[5] += tempWord[j];
                            }
                        }
                        else
                        {
                            choiceActions[5] = currentLine[i + 1];
                        }
                        i++;
                        break;
                    case "#clueonefound":
                        if (ClueFound[0])
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
                        if (ClueFound[1])
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
                        if (ClueFound[2])
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
                        if (ClueFound[3])
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
                        if (ClueFound[4])
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
                        if (ClueFound[5])
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
                        for(int j = i + 1;currentLine[j] != "#no"; j++)
                        {
                            if(j == i + 1)
                            {
                                currentText.text += currentLine[j];
                            }
                            else
                            {
                                currentText.text += " " + currentLine[j];
                            }
                        }
                        i = currentLine.Length - 1;
                        break;
                    case "#no":
                        for (int j = i + 1; j < currentLine.Length; j++)
                        {
                            if (j == i + 1)
                            {
                                currentText.text += currentLine[j];
                            }
                            else
                            {
                                currentText.text += " " + currentLine[j];
                            }
                        }
                        i = currentLine.Length - 1;
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
                                currentText.text += currentLine[i];
                            }
                            else
                            {
                                currentText.text += " " + currentLine[i];
                            }
                        }
                        break;
                }
            }
            lineNum += 1;
        }
        if(currentText == message && message.text != "")
        {
            if(textbox.text == "")
            {
                textbox.text += currentText.text;
            }
            else
            {
                textbox.text += "\n" + currentText.text;
            }
        }
        if (message.text == "" && option1.text == "" && option2.text == "" && option3.text == "" && option4.text == "" && option5.text == "" && option6.text == "")
        {
            NextLine();
            return;
        }
    }

    private void GoTo(string location)
    {
        string nextTopic = "@" + location;
        for (int i = 0; i < entries.Length; i++)
        {
            string temp = entries[i];
            string place = "";
            if (entries[i] == nextTopic)
            {
                lineNum = i;
                break;
            }
            else
            {
                for (int j = 0; j < temp.Length - 1; j++)
                {
                    place += temp[j];
                }
                if (place == nextTopic)
                {
                    lineNum = i;
                    break;
                }
            }
        }
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
            for(int i = 0; i < choiceActions.Length; i++)
            {
                choiceActions[i] = "";
            }
            NextLine();
        }
    }
}
