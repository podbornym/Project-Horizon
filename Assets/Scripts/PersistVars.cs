using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistVars : MonoBehaviour {
    //this script is attached to the UI so
    //all variables stored in here will persist
    //across scene changes
    //public GameObject UIRef;

    public float match3Score;
    public float rotatoScore;
    public float pipeDreamScore;
    public float tracerScore;
    public float findDiffScore;
    public float mastermindScore;
	public int currentMoney;
	public int strikes;
	public bool freePass = false;

    public int knowledgeCount = 0; 

	public static string currentScene = null;
    public static string previousScene = null;
    public bool ukiyoe = false;
    public bool baroque = false;
    public bool surrealism = false;

    private static GameObject clue = null;

    public static string ggScrub = "This will be the best art theft game ever made.  No doubt about it!";

    public static bool returningToHome = false;

    public GameObject UI;
    public GameObject clueOne;
    public GameObject clueTwo;
    public GameObject clueThree;
    public GameObject clueFour;
    public GameObject clueFive;
    public GameObject clueSix;

    //Painting Number
    //This is a number between 1-18, which determines what painting you're working on.
    //1-6 is Ukiyo, 7-12 is Surreal, 13-18 is Baroque
    public static int paintingNum = 1;

	// Painting Max Value
	public static int[] maxValue = new int[18];

    //Locations
    public static bool Ukiyo = false;
    public static bool Surreal = false;
    public static bool Baroque = false;
    //Paintings
    public static bool[] painting = { false, false, false, false, false, false };
    //If a painting is true, use the location + the painting number. EX: If Ukiyo = true and using painting[2], location = "Ukiyo", clue set = location + "Three"
    //Ukiyo-e Clues
    public static bool[] UkiyoOne = { false, false, false, false, false, false };
    public static bool[] UkiyoTwo = { false, false, false, false, false, false };
    public static bool[] UkiyoThree = { false, false, false, false, false, false };
    public static bool[] UkiyoFour = { false, false, false, false, false, false };
    public static bool[] UkiyoFive = { false, false, false, false, false, false };
    public static bool[] UkiyoSix = { false, false, false, false, false, false };
    //Surreal Clues
    public static bool[] SurrealOne = { false, false, false, false, false, false };
    public static bool[] SurrealTwo = { false, false, false, false, false, false };
    public static bool[] SurrealThree = { false, false, false, false, false, false };
    public static bool[] SurrealFour = { false, false, false, false, false, false };
    public static bool[] SurrealFive = { false, false, false, false, false, false };
    public static bool[] SurrealSix = { false, false, false, false, false, false };
    //Baroque Clues
    public static bool[] BaroqueOne = { false, false, false, false, false, false };
    public static bool[] BaroqueTwo = { false, false, false, false, false, false };
    public static bool[] BaroqueThree = { false, false, false, false, false, false };
    public static bool[] BaroqueFour = { false, false, false, false, false, false };
    public static bool[] BaroqueFive = { false, false, false, false, false, false };
    public static bool[] BaroqueSix = { false, false, false, false, false, false };

    void Start()
    {
        DialogueReader.paintNum = paintingNum;
        UI.GetComponent<DialogueReader>().nextButton.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().option1.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().option2.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().option3.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().option4.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().option5.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().option6.gameObject.SetActive(false);
        UI.GetComponent<DialogueReader>().quit.gameObject.SetActive(false);

		for (int i=0; i<18; i++)
		{
			maxValue [i] = 1000000 * (i + 1);
		}
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            FindClue();
        }*/

        /*// These cases are to be handled by OnLevelWasLoaded()
        switch(SceneManager.GetActiveScene().name)
        {
            // Switch cases for Ukiyo-e zone
            case "Ukiyo-eZone":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            case "U_0":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            case "U_1":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            case "U_2":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            case "U_3":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            case "U_4":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            case "U_5":
                ukiyoe = true;
                currentScene = SceneManager.GetActiveScene();
                break;
            // Default case
            default:
                //print("did not get a valid scene");
                ukiyoe = true;
                break;
            //ONLOADEDLEVEL
        }*/
    }

    /*void FindClue()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if (hit)
        {
            if (SceneManager.GetActiveScene().name == "S_0" || SceneManager.GetActiveScene().name == "S_1" || SceneManager.GetActiveScene().name == "S_2" || SceneManager.GetActiveScene().name == "S_3" || SceneManager.GetActiveScene().name == "S_4"
                || SceneManager.GetActiveScene().name == "U_0" || SceneManager.GetActiveScene().name == "U_1" || SceneManager.GetActiveScene().name == "U_2" || SceneManager.GetActiveScene().name == "U_3" || SceneManager.GetActiveScene().name == "U_4"
                || SceneManager.GetActiveScene().name == "B_0" || SceneManager.GetActiveScene().name == "B_1" || SceneManager.GetActiveScene().name == "B_2" || SceneManager.GetActiveScene().name == "B_3" || SceneManager.GetActiveScene().name == "B_4")
            {
                if (hit.collider.gameObject.tag == "clue")
                {
                    if (hit.collider.gameObject == clueOne)
                    {
                        painting[0] = true;
                        Debug.Log("Found Clue 1");
                    }
                    if (hit.collider.gameObject == clueTwo)
                    {
                        painting[1] = true;
                        Debug.Log("Found Clue 2");
                    }
                    if (hit.collider.gameObject == clueThree)
                    {
                        painting[2] = true;
                        Debug.Log("Found Clue 3");
                    }
                    if (hit.collider.gameObject == clueFour)
                    {
                        painting[3] = true;
                        Debug.Log("Found Clue 4");
                    }
                    if (hit.collider.gameObject == clueFive)
                    {
                        painting[4] = true;
                        Debug.Log("Found Clue 5");
                    }
                    if (hit.collider.gameObject == clueSix)
                    {
                        painting[5] = true;
                        Debug.Log("Found Clue 6");
                    }
                //}
            }
        }
    }*/

    // Use to clear variables once a painting has been sold
    void ClearVars()
    {
        match3Score = 0f;
        rotatoScore = 0f;
        pipeDreamScore = 0f;
        tracerScore = 0f;
        findDiffScore = 0f;
        mastermindScore = 0f;

        knowledgeCount = 0;
        for (int i = 0; i < 6; i++)
        {
            UI.GetComponent<DialogueReader>().ClueFound[i] = false;
        }
    }

    // Use to get all total inherited scores, then evaluate the player on their painting replication
    void CalculateEvaluation()
    {
        
    }

    // Allow other scripts to access the arrays defined here
    public void ArrayAccess(string array, int index)
    {
        switch(array)
        {
            case "UOne":
                UkiyoOne[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "UTwo":
                UkiyoTwo[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "UThree":
                UkiyoThree[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "UFour":
                UkiyoFour[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "UFive":
                UkiyoFive[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "USix":
                UkiyoSix[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "SOne":
                SurrealOne[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "STwo":
                SurrealTwo[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "SThree":
                SurrealThree[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "SFour":
                SurrealFour[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "SFive":
                SurrealFive[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "SSix":
                SurrealSix[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "BOne":
                BaroqueOne[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "BTwo":
                BaroqueTwo[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "BThree":
                BaroqueThree[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "BFour":
                BaroqueFour[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "BFive":
                BaroqueFive[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            case "BSix":
                BaroqueSix[index] = true;
                UI.GetComponent<DialogueReader>().ClueFound[index] = true;
                break;
            default:
                print("did not assign valid array");
                break;
        }
    }

    // Increment the knowledge meter on the UI
    public void KnowledgeIncrement()
    {
        knowledgeCount++;

        switch(knowledgeCount)
        {
            case 1:
                GameObject.Find("light_0").GetComponent<Image>().enabled = true;
                break;
            case 2:
                GameObject.Find("light_1").GetComponent<Image>().enabled = true;
                break;
            case 3:
                GameObject.Find("light_2").GetComponent<Image>().enabled = true;
                break;
            case 4:
                GameObject.Find("light_3").GetComponent<Image>().enabled = true;
                break;
            case 5:
                GameObject.Find("light_4").GetComponent<Image>().enabled = true;
                break;
            case 6:
                GameObject.Find("light_5").GetComponent<Image>().enabled = true;
                break;
        }
    }
}
