using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PersistVars : MonoBehaviour {
    //this script is attached to the UI so
    //all variables stored in here will persist
    //across scene changes
    public float match3Score;
    public float rotatoScore;
    public float pipeDreamScore;
    public float tracerScore;
    public float findDiffScore;
    public float mastermindScore;

    public Scene currentScene;
    public Scene previousScene;

    private static GameObject clue = null;

    public static string ggScrub = "This will be the best art theft game ever made.  No doubt about it!";

    public GameObject clueOne;
    public GameObject clueTwo;
    public GameObject clueThree;
    public GameObject clueFour;
    public GameObject clueFive;
    public GameObject clueSix;

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
    public static bool[] BaroqeuFour = { false, false, false, false, false, false };
    public static bool[] BaroqueFive = { false, false, false, false, false, false };
    public static bool[] BaroqueSix = { false, false, false, false, false, false };


    void Update()
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
                }
            }
        }
    }

    void clearVars()
    {
        // Use to clear variables once a painting has been sold
        // Should be flexible, allow for two paintings to be stored at once?? Need twice as many variables then, and lots of work in other scripts
        match3Score = 0f;
        rotatoScore = 0f;
        pipeDreamScore = 0f;
        tracerScore = 0f;
        findDiffScore = 0f;
        mastermindScore = 0f;
    }
}
