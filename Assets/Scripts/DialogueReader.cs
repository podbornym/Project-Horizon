using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Collections.Generic;

public class DialogueReader : MonoBehaviour
{
    public static int paintNum;
    public List<string> entries = new List<string>();
    private int lineNum = 0;
    private string option;
    private string[] choiceActions = new string[6];
    public StreamReader sr;
    public GameObject UI;
    public TextAsset dialogue;
    public GameObject dialogueContainer;
    public GameObject nextButton;
    public GameObject clueOne;
    public GameObject clueTwo;
    public GameObject clueThree;
    public GameObject clueFour;
    public GameObject clueFive;
    public GameObject clueSix;
    public GameObject quit;
    public GameObject muse;
	public SellingController SellCont;
	public SellingLogic SLog;
    public bool[] ClueFound = { false, false, false, false, false, false };
    public Text message;
    public Text textbox;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    public Text option5;
    public Text option6;
    private Text currentText;
    public bool isTalking = false;
	public int questCount = 1;
    public bool intro_speech_ukiyo = true;
    public bool finished_intro = false;
	public bool cAnswer;
	public int blkPrice;

    // Use this for initialization
    void Start ()
    {
        ReadFile("./Assets/Dialogue/Three Beauties.txt");
        nextButton.gameObject.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        option5.gameObject.SetActive(false);
        option6.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    void Update ()
    {
        for (int i = 0; i < 6; i++)
        {
            if(ClueFound[i])
            {
                Button b = GameObject.Find("Button (" + (i + 1) + ")").GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f ,1);
                b.colors = cb;
            }
            if(!ClueFound[i])
            {
                Button b = GameObject.Find("Button (" + (i + 1) + ")").GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                b.colors = cb;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            FindClue();
        }
        if (clueOne == null || clueTwo == null || clueThree == null || clueFour == null || clueFive == null || clueSix == null)
        {
            SetClue();
        }
        if (intro_speech_ukiyo && PersistVars.currentScene == "Ukiyo-eZone")
        {
            intro_speech_ukiyo = false;
            ReadFile("./Assets/Dialogue/ukiyo intro.txt");
            NextLine();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clueOne = null;
            clueTwo = null;
            clueThree = null;
            clueFour = null;
            clueFive = null;
            clueSix = null;
            muse = null;
        }
       
    }

    void SetClue()
    {
        for(int i = 1; i < 7; i++)
        {
            if (i == 1)
            {
                clueOne = GameObject.Find("clue" + (i + (paintNum - 1) * 6).ToString());
                if(clueOne != null)
                    clueOne.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            if (i == 2)
            {
                clueTwo = GameObject.Find("clue" + (i + (paintNum - 1) * 6).ToString());
                if (clueTwo != null)
                    clueTwo.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            if (i == 3)
            {
                clueThree = GameObject.Find("clue" + (i + (paintNum - 1) * 6).ToString());
                if (clueThree != null)
                    clueThree.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            if (i == 4)
            {
                clueFour = GameObject.Find("clue" + (i + (paintNum - 1) * 6).ToString());
                if(clueFour != null)
                    clueFour.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            if (i == 5)
            {
                clueFive = GameObject.Find("clue" + (i + (paintNum - 1) * 6).ToString());
                if(clueFive != null)
                    clueFive.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            if (i == 6)
            {
                clueSix = GameObject.Find("clue" + (i + (paintNum - 1) * 6).ToString());
                if(clueSix != null)
                    clueSix.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        muse = GameObject.FindGameObjectWithTag("muse");
        if(muse != null)
            muse.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    void FindClue()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if (hit)
        {
            if(hit.collider.tag == "muse")
            {
                //muse = hit.collider.gameObject;
                muse.GetComponent<BoxCollider2D>().enabled = false;
                dialogueContainer.SetActive(true);
                isTalking = true;
                if(PersistVars.currentScene.Contains(((paintNum - 1) % 6).ToString()))
                {
                    NextLine();
                }
                else
                {
                    GoTo("change");
                    NextLine();
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
                for (int j = 0; j < word.Length; j++)
                {
                    currentWord += word[j];
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
                        quit.gameObject.SetActive(true);
                        break;
                    case "#SetPlayer":
                        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = true;
                        GameObject.Find("DragPort").GetComponent<Image>().enabled = false;
                        GameObject.Find("SurrealMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("BaroqueMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("WoodStock").GetComponent<Image>().enabled = false;
                        break;
                    case "#SetUkiyoMuse":
                        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = false;
                        GameObject.Find("DragPort").GetComponent<Image>().enabled = true;
                        GameObject.Find("SurrealMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("BaroqueMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("WoodStock").GetComponent<Image>().enabled = false;
                        break;
                    case "#SetBaroqueMuse":
                        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = false;
                        GameObject.Find("DragPort").GetComponent<Image>().enabled = false;
                        GameObject.Find("SurrealMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("BaroqueMuse").GetComponent<Image>().enabled = true;
                        GameObject.Find("WoodStock").GetComponent<Image>().enabled = false;
                        break;
                    case "#SetSurrealMuse":
                        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = false;
                        GameObject.Find("DragPort").GetComponent<Image>().enabled = false;
                        GameObject.Find("SurrealMuse").GetComponent<Image>().enabled = true;
                        GameObject.Find("BaroqueMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("WoodStock").GetComponent<Image>().enabled = false;
                        break;
                    case "#SetWoodStock":
                        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = false;
                        GameObject.Find("DragPort").GetComponent<Image>().enabled = false;
                        GameObject.Find("SurrealMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("BaroqueMuse").GetComponent<Image>().enabled = false;
                        GameObject.Find("WoodStock").GetComponent<Image>().enabled = true;
                        break;
                    case "#activateClue1":
                        clueOne.gameObject.GetComponent<Collider2D>().enabled = true;
                        break;
                    case "#activateClue2":
                        clueTwo.gameObject.GetComponent<Collider2D>().enabled = true;
                        break;
                    case "#activateClue3":
                        clueThree.gameObject.GetComponent<Collider2D>().enabled = true;
                        break;
                    case "#activateClue4":
                        clueFour.gameObject.GetComponent<Collider2D>().enabled = true;
                        break;
                    case "#activateClue5":
                        clueFive.gameObject.GetComponent<Collider2D>().enabled = true;
                        break;
                    case "#activateClue6":
                        clueSix.gameObject.GetComponent<Collider2D>().enabled = true;
                        break;
                    case "#option1":
                        option1.gameObject.SetActive(true);
                        if(i + 1 == currentLine.Length - 1)
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
                        if (ClueFound[0])
                        {
                            GoTo("yes1");
                        }
                        else
                        {
                            GoTo("no1");
                        }
                        break;
                    case "#cluetwofound":
                        if (ClueFound[1])
                        {
                            GoTo("yes2");
                        }
                        else
                        {
                            GoTo("no2");
                        }
                        break;
                    case "#cluethreefound":
                        if (ClueFound[2])
                        {
                            GoTo("yes3");
                        }
                        else
                        {
                            GoTo("no3");
                        }
                        break;
                    case "#cluefourfound":
                        if (ClueFound[3])
                        {
                            GoTo("yes4");
                        }
                        else
                        {
                            GoTo("no4");
                        }
                        break;
                    case "#cluefivefound":
                        if (ClueFound[4])
                        {
                            GoTo("yes5");
                        }
                        else
                        {
                            GoTo("no5");
                        }
                        break;
                    case "#cluesixfound":
                        if (ClueFound[5])
                        {
                            GoTo("yes6");
                        }
                        else
                        {
                            GoTo("no6");
                        }
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
					case "#ysell":
						if(SellCont.check==true)
						{
							if (SellCont.buyer=="blk")
							{
								GoTo ("blkClient");
							}
							else
							{
								GoTo ("pass1");
							}
							
						}
						else if(SellCont.check==false)
						{
							gameObject.GetComponent<PersistVars> ().strikes += 1;
							if (gameObject.GetComponent<PersistVars> ().strikes < 3 && gameObject.GetComponent<PersistVars> ().freePass == false) 
							{
								GoTo ("fail1");
								gameObject.GetComponent<PersistVars> ().freePass = true;
							} 
							else if (gameObject.GetComponent<PersistVars> ().strikes < 3 && gameObject.GetComponent<PersistVars> ().freePass == true) 
							{
								GoTo ("fail2");
							} 
							else if (gameObject.GetComponent<PersistVars> ().strikes == 3) 
							{
								GoTo ("fail3");
							}
						}
						break;
					case "#nsell":
						currentText.text = "Please select another client.";
						SellCont.bReset ();
						GoTo ("Start");
						break;
					case "#passed1":
						currentText.text = "Congradulations! You sold the forgery for $" + SellCont.Pay;
						PersistVars.currentMoney += SellCont.Pay;
						GoTo ("Continue");
						break;
					case "#failed2":
						currentText.text = "You have been caught\n." +
							"You recieve ONE STRIKE, and you you will not be able to sell to this client next time.\n" +
							"Three strikes and your forgery career is over.\n" +
						"You currently have " + gameObject.GetComponent<PersistVars> ().strikes + " strike(s).";
						GoTo ("Continue");
						break;
					case "#Continue":
						SceneManager.LoadScene ("mansion");
						EndDialogue();
						break;
					case "#GContinue":
						SceneManager.LoadScene ("GameOver");
						EndDialogue();
						break;
					case "#blkbegin":
						GoTo ("blkQuestion1");
						break;
					case "#quest1":
						if (PersistVars.paintingNum == 4) // Shoki Striding
						{
							cAnswer = false;
							GoTo ("ukiyo1_1");
						}
						else if (PersistVars.paintingNum == 6) // Otani Oniji III as Yakko Edobei
						{
							cAnswer = true;
							GoTo ("ukiyo2_1");
						}
						else if (PersistVars.paintingNum == 3) // The Great Wave off Kanagawa
						{
							cAnswer = false;
							GoTo ("ukiyo3_1");
						}
						else if (PersistVars.paintingNum == 1) // Three Beauties of the Present Day
						{
							cAnswer = false;
							GoTo ("ukiyo4_1");
						}
						else if (PersistVars.paintingNum == 2) // Waitress at an Inn at Akasaka
						{
							cAnswer = false;
							GoTo ("ukiyo5_1");
						}
						else if (PersistVars.paintingNum == 5) // Sudden Shower over Shin-Ōhashi Bridge and Atake
						{
							cAnswer = false;
							GoTo ("ukiyo6_1");
						}
						break;
					case "#quest2":
						if (PersistVars.paintingNum == 4) // Shoki Striding
						{
							cAnswer = false;
							GoTo ("ukiyo1_2");
						}
						else if (PersistVars.paintingNum == 6) // Otani Oniji III as Yakko Edobei
						{
							cAnswer = true;
							GoTo ("ukiyo2_2");
						}
						else if (PersistVars.paintingNum == 3) // The Great Wave off Kanagawa
						{
							cAnswer = false;
							GoTo ("ukiyo3_2");
						}
						else if (PersistVars.paintingNum == 1) // Three Beauties of the Present Day
						{
							cAnswer = true;
							GoTo ("ukiyo4_2");
						}
						else if (PersistVars.paintingNum == 2) // Waitress at an Inn at Akasaka
						{
							cAnswer = true;
							GoTo ("ukiyo5_2");
						}
						else if (PersistVars.paintingNum == 5) // Sudden Shower over Shin-Ōhashi Bridge and Atake
						{
							cAnswer = false;
							GoTo ("ukiyo6_2");
						}
						break;
					case "#quest3":
						if (PersistVars.paintingNum == 4) // Shoki Striding
						{
							cAnswer = true;
							GoTo ("ukiyo1_3");
						}
						else if (PersistVars.paintingNum == 6) // Otani Oniji III as Yakko Edobei
						{
							cAnswer = true;
							GoTo ("ukiyo2_3");
						}
						else if (PersistVars.paintingNum == 3) // The Great Wave off Kanagawa
						{
							cAnswer = false;
							GoTo ("ukiyo3_3");
						}
						else if (PersistVars.paintingNum == 1) // Three Beauties of the Present Day
						{
							cAnswer = false;
							GoTo ("ukiyo4_3");
						}
						else if (PersistVars.paintingNum == 2) // Waitress at an Inn at Akasaka
						{
							cAnswer = true;
							GoTo ("ukiyo5_3");
						}
						else if (PersistVars.paintingNum == 5) // Sudden Shower over Shin-Ōhashi Bridge and Atake
						{
							cAnswer = false;
							GoTo ("ukiyo6_3");
						}
						break;
					case "#blkTrue":
						if (cAnswer == true) {
							SellCont.correct += 1;
						}
						if (questCount == 1) {
							GoTo ("blkQuestion2");
						}
						if (questCount == 2) {
							GoTo ("blkQuestion3");
						}
						if (questCount == 3) {
							GoTo ("blkSell");
						}
						questCount++;
						break;
					case "#blkFalse":
						if (cAnswer == false) {
							SellCont.correct += 1;
						}
						if (questCount == 1) {
							GoTo ("blkQuestion2");
						}
						if (questCount == 2) {
							GoTo ("blkQuestion3");
						}
						if (questCount == 3) {
							GoTo ("blkSell");
						}
						questCount++;
						break;
					case "#blkresult":
						blkPrice = SLog.BkPay (SellCont.counter, SellCont.correct, SellCont.maxValue);
						currentText.text = "You got " + SellCont.correct + " questions correct\n"
						+ "You sold the forgery for $" + blkPrice;
						PersistVars.currentMoney += blkPrice;
						GoTo ("Continue");
						break;
                    case "#change":
                        if(PersistVars.currentScene.Contains("0"))
                        {
                            PersistVars.paintingNum = 1;
                        }
                        else if (PersistVars.currentScene.Contains("1"))
                        {
                            PersistVars.paintingNum = 2;
                        }
                        else if (PersistVars.currentScene.Contains("2"))
                        {
                            PersistVars.paintingNum = 3;
                        }
                        else if (PersistVars.currentScene.Contains("3"))
                        {
                            PersistVars.paintingNum = 4;
                        }
                        else if (PersistVars.currentScene.Contains("4"))
                        {
                            PersistVars.paintingNum = 5;
                        }
                        else if (PersistVars.currentScene.Contains("5"))
                        {
                            PersistVars.paintingNum = 6;
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            ClueFound[j] = false;
                        }
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
        for (int i = 0; i < entries.Count; i++)
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
        if(finished_intro == false)
        {
            finished_intro = true;
            ReadFile("./Assets/Dialogue/Three Beauties.txt");
        }
        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = true;
        GameObject.Find("DragPort").GetComponent<Image>().enabled = false;
        GameObject.Find("SurrealMuse").GetComponent<Image>().enabled = false;
        GameObject.Find("BaroqueMuse").GetComponent<Image>().enabled = false;
        GameObject.Find("WoodStock").GetComponent<Image>().enabled = false;
        lineNum = 0;
        textbox.text = "";
        for(int i = 0; i < choiceActions.Length; i++)
        {
            choiceActions[i] = "";
        }
        dialogueContainer.SetActive(false);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        option5.gameObject.SetActive(false);
        option6.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        muse.GetComponent<BoxCollider2D>().enabled = true;
        isTalking = false;
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
        else if(choiceActions[optionNumber].Contains("#play"))
        {
            if(choiceActions[optionNumber].Contains("1"))
            {
                SceneManager.LoadScene("Z1-TR" + PersistVars.paintingNum.ToString());
            }
            else if (choiceActions[optionNumber].Contains("2"))
            {
                SceneManager.LoadScene("Z1-SD" + PersistVars.paintingNum.ToString());
            }
            else if (choiceActions[optionNumber].Contains("3"))
            {
                SceneManager.LoadScene("Match3 Base");
            }
            else if (choiceActions[optionNumber].Contains("4"))
            {
                SceneManager.LoadScene("Z1-RT" + PersistVars.paintingNum.ToString());
            }
            else if (choiceActions[optionNumber].Contains("5"))
            {
                SceneManager.LoadScene("Z1-PD" + PersistVars.paintingNum.ToString());
            }
            else if (choiceActions[optionNumber].Contains("6"))
            {
                SceneManager.LoadScene("Mastermind Base");
            }
            EndDialogue();
        }
        else if (choiceActions[optionNumber].Contains("#change"))
        {
            if (PersistVars.currentScene == "U_0")
            {
                PersistVars.paintingNum = 1;
                paintNum = 1;
                ReadFile("./Assets/Dialogue/Three Beauties.txt");
            }
            else if (PersistVars.currentScene == "U_1")
            {
                PersistVars.paintingNum = 2;
                paintNum = 2;
            }
            else if (PersistVars.currentScene == "U_2")
            {
                PersistVars.paintingNum = 3;
                paintNum = 3;
                ReadFile("./Assets/Dialogue/Wave of Kanagawa.txt");
            }
            else if (PersistVars.currentScene == "U_3")
            {
                PersistVars.paintingNum = 4;
                paintNum = 4;
            }
            else if (PersistVars.currentScene == "U_4")
            {
                PersistVars.paintingNum = 5;
                paintNum = 5;
                ReadFile("./Assets/Dialogue/SuddenShowerDialogue.txt");
            }
            else if (PersistVars.currentScene == "U_5")
            {
                PersistVars.paintingNum = 6;
                paintNum = 6;
            }
			else if (PersistVars.currentScene == "SellingScene")
			{
				ReadFile("./Assets/Dialogue/sell.txt");
			}
            GoTo("Start");
            NextLine();
        }
        else if (choiceActions[optionNumber].Contains("#quit"))
        {
            EndDialogue();
        }
    }

	public void SellingStart()
	{
		ReadFile("./Assets/Dialogue/sell.txt");
		GoTo("Start");
		NextLine();
	}

    void ReadFile(string filepath)
    {
        sr = new StreamReader(filepath);
        textbox.text = "";
        entries.Clear();
        try
        {
            using (sr)
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    entries.Add(line);
                    i++;
                }
            }
        }
        catch (Exception e)
        {
            print("Exception: " + e);
        }
    }
}
