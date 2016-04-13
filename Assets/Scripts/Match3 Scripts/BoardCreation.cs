using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BoardCreation : MonoBehaviour
{
    // Variables used for initialization, game tracking
    public GameObject puzzlePiecePrefab;
    public bool dragging = false;
    public bool spawning = false;

    public Sprite ukiyoOne;
    public Sprite ukiyoTwo;
    public Sprite ukiyoThree;
    public Sprite ukiyoFour;
    public Sprite ukiyoFive;

    public Sprite surrealOne;
    public Sprite surrealTwo;
    public Sprite surrealThree;
    public Sprite surrealFour;
    public Sprite surrealFive;

    public Sprite baroqueOne;
    public Sprite baroqueTwo;
    public Sprite baroqueThree;
    public Sprite baroqueFour;
    public Sprite baroqueFive;

    public Scene currentScene;

    private float deltaTime = 0.0f;
    private float timeSinceSpawned = 0.0f;
    private List<GameObject> allPieces = new List<GameObject>();
    private List<GameObject> markedPieces = new List<GameObject>();
    private GameObject puzzleObject;

    // Timer variables for setting time
    public float seconds = 90;

    private float warningSec;

    public Text timer;

    // Variables for keeping track of score
    public Text redScore;
    public Text yellowScore;
    public Text blueScore;
    public Text greenScore;
    public Text magentaScore;

    private int setRedValue = 0;
    private int setGreenValue = 0;
    private int setBlueValue = 0;
    private int setYellowValue = 0;
    private int setMagentaValue = 0;

    private int redHit = 0;
    private int yellowHit = 0;
    private int greenHit = 0;
    private int blueHit = 0;
    private int magentaHit = 0;

    // Set specified totals for each color on each level
    public Text redTotal;
    public Text yellowTotal;
    public Text blueTotal;
    public Text greenTotal;
    public Text magentaTotal;

    private int setRedTotal;
    private int setGreenTotal;
    private int setBlueTotal;
    private int setYellowTotal;
    private int setMagentaTotal;

    private string setRed;
    private string setGreen;
    private string setBlue;
    private string setYellow;
    private string setMagenta;

    public float dragPenalty;

    public Text warningText;

    public PersistVars match3;

    void Update()
    {
        seconds -= Time.deltaTime;
        timer.text = seconds.ToString("0");

        deltaTime = (Time.deltaTime - deltaTime) * 0.1f;
        //		Debug.Log("FPS = " + 1.0f/deltaTime);
        if (timeSinceSpawned > 0.0f)
        {
            if (!dragging)
            {
                timeSinceSpawned -= Time.deltaTime;
                if (timeSinceSpawned <= 0.0f)
                {
                    spawning = false;
                    PopMatches();
                }
            }
        }
        if (!dragging)
        {
            bool falling = false;
            UpdateAllPieces();
            for (int i = 0; i < allPieces.Count; i++)
            {
                allPieces[i].GetComponent<PuzzlePiece>().FallDown();
                if (allPieces[i].GetComponent<PuzzlePiece>().falling)
                {
                    falling = true;
                }
            }
            if (!falling && !spawning)
            {
                NewPieces();
            }
        }

        if(seconds <= 0)
        {
            dragging = true;
            spawning = true;
            timer.color = Color.red;
            timer.text = "Time's Up!";

            TallyScore();
            GameObject.Find("Next Button").GetComponent<Button>().interactable = true;
        } 

        if(dragging && seconds > 0)
        {
            warningSec = seconds;

            /*if(warningSec >= 3)
            {
                warningText.text = "Warning: Dragging for too long will incur a score penalty!.......";
            }*/
            //warningSec = 3;
        }
    }

    // Use this for initialization
    void Start()
    {
        // Disable the UI's canvas
        if(GameObject.Find("GENERALUI"))
        {
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
        }
        match3 = GameObject.Find("GENERALUI").GetComponent<PersistVars>();

        match3.ukiyoe = true; //make sure to remove once the game gets going

        if(match3.ukiyoe)
        {
            setRed = "Flower: ";
            setGreen = "Frog: ";
            setBlue = "Fish: ";
            setYellow = "Octopus: ";
            setMagenta = "Coin: ";

            switch(match3.previousScene.name)
            {
                case "U_O":
                    setRedTotal = 25;
                    setYellowTotal = 25;
                    setGreenTotal = 50;
                    setBlueTotal = 80;
                    setMagentaTotal = 1;
                    break;
                case "U_1":
                    setRedTotal = 20;
                    setYellowTotal = 20;
                    setGreenTotal = 20;
                    setBlueTotal = 20;
                    setMagentaTotal = 20;
                    break;
                case "U_2":
                    setRedTotal = 50;
                    setYellowTotal = 1;
                    setGreenTotal = 1;
                    setBlueTotal = 1;
                    setMagentaTotal = 50;
                    break;
                case "U_3":
                    setRedTotal = 1;
                    setYellowTotal = 50;
                    setGreenTotal = 1;
                    setBlueTotal = 1;
                    setMagentaTotal = 50;
                    break;
                case "U_4":
                    setRedTotal = 20;
                    setYellowTotal = 1;
                    setGreenTotal = 1;
                    setBlueTotal = 80;
                    setMagentaTotal = 1;
                    break;
                case "U_5":
                    setRedTotal = 60;
                    setYellowTotal = 1;
                    setGreenTotal = 40;
                    setBlueTotal = 1;
                    setMagentaTotal = 1;
                    break;
                default:
                    print("did not find a valid studio for match3 ukiyo-e variables");
                    setRedTotal = 100;
                    setYellowTotal = 100;
                    setGreenTotal = 100;
                    setBlueTotal = 100;
                    setMagentaTotal = 100;
                    break;
            }
        }

        redTotal.text = "/" + setRedTotal + "|";
        yellowTotal.text = "/" + setYellowTotal + "|";
        greenTotal.text = "/" + setGreenTotal + "|";
        blueTotal.text = "/" + setBlueTotal + "|";
        magentaTotal.text = "/" + setMagentaTotal;

        redScore.text =  setRed + "0";
        yellowScore.text = setYellow + "0";
        greenScore.text = setGreen + "0";
        blueScore.text = setBlue + "0";
        magentaScore.text = setMagenta + "0";

        puzzleObject = GameObject.Find("PuzzleObject");
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                // Look into giving priority to other pieces
                GameObject newPiece = Instantiate(puzzlePiecePrefab, new Vector2(-2.2f + i * 0.87f, -4.5f + j * 0.87f), Quaternion.identity) as GameObject;
                newPiece.transform.SetParent(puzzleObject.transform);
                if (match3.ukiyoe)
                {
                    switch (Random.Range(0, 5))
                    {
                        case 0:
                            newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoOne;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                            break;
                        case 1:
                            newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoTwo;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                            break;
                        case 2:
                            newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoThree;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                            break;
                        case 3:
                            newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoFour;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                            break;
                        case 4:
                            newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoFive;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                            break;
                    }
                }
            }
        }
    }

    public void NewPieces()
    {
        for (int i = 5; i >= 0; i--)
        {
            for (int j = 5; j >= 0; j--)
            {
                if (Physics2D.Raycast(new Vector2(-2.2f + i * 0.87f, -4.5f + j * 0.87f), Vector3.down, 0.01f).collider == null)
                {
                    spawning = true;
                    GameObject newPiece = Instantiate(puzzlePiecePrefab, new Vector2(-2.2f + i * 0.87f, -4.5f + j * 0.87f), Quaternion.identity) as GameObject;
                    newPiece.transform.SetParent(puzzleObject.transform);
                    newPiece.GetComponent<PuzzlePiece>().baseX = -2.2f + i * 0.87f;
                    newPiece.GetComponent<PuzzlePiece>().baseY = -4.5f + j * 0.87f;
                    if (match3.ukiyoe)
                    {
                        switch (Random.Range(0, 5))
                        {
                            case 0:
                                newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoOne;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                                break;
                            case 1:
                                newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoTwo;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                                break;
                            case 2:
                                newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoThree;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                                break;
                            case 3:
                                newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoFour;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                                break;
                            case 4:
                                newPiece.GetComponent<SpriteRenderer>().sprite = ukiyoFive;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                                break;
                        }
                    }
                }
            }
        }
        timeSinceSpawned = 1.0f;
    }

    public void UpdateAllPieces()
    {
        allPieces = GameObject.FindGameObjectsWithTag("PuzzlePiece").ToList();
    }

    public void PopMatches()
    {
        UpdateAllPieces();
        for (int i = 0; i < allPieces.Count; i++)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(allPieces[i].transform.position, Vector2.right, 1.7f);
            if (hits.Length > 2)
            {
                if (hits[0].transform.gameObject.GetComponent<PuzzlePiece>().color == hits[1].transform.gameObject.GetComponent<PuzzlePiece>().color && hits[0].transform.gameObject.GetComponent<PuzzlePiece>().color == hits[2].transform.gameObject.GetComponent<PuzzlePiece>().color)
                {
                    hits[0].transform.gameObject.GetComponent<PuzzlePiece>().popped = true;
                    hits[1].transform.gameObject.GetComponent<PuzzlePiece>().popped = true;
                    hits[2].transform.gameObject.GetComponent<PuzzlePiece>().popped = true;
                    Color color = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().color;
                    Sprite sprite = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                    if (color == Color.red || sprite == ukiyoOne || sprite == surrealOne || sprite == baroqueOne)
                    {
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = setRed + setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green || sprite == ukiyoTwo || sprite == surrealTwo || sprite == baroqueTwo)
                    {
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = setGreen + setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue || sprite == ukiyoThree || sprite == surrealThree || sprite == baroqueThree)
                    {
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = setBlue + setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow || sprite == ukiyoFour || sprite == surrealFour || sprite == baroqueFour)
                    {
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = setYellow + setYellowValue.ToString();
                        yellowHit = 0;
                    }
                    if (color == Color.magenta || sprite == ukiyoFive || sprite == surrealFive || sprite == baroqueFive)
                    {
                        magentaHit = hits.Length;
                        setMagentaValue += magentaHit;
                        magentaScore.text = setMagenta + setMagentaValue.ToString();
                        magentaHit = 0;
                    }
                }
            }
            hits = Physics2D.RaycastAll(allPieces[i].transform.position, Vector2.down, 1.7f);
            if (hits.Length > 2)
            {
                if (hits[0].transform.gameObject.GetComponent<PuzzlePiece>().color == hits[1].transform.gameObject.GetComponent<PuzzlePiece>().color && hits[0].transform.gameObject.GetComponent<PuzzlePiece>().color == hits[2].transform.gameObject.GetComponent<PuzzlePiece>().color)
                {
                    hits[0].transform.gameObject.GetComponent<PuzzlePiece>().popped = true;
                    hits[1].transform.gameObject.GetComponent<PuzzlePiece>().popped = true;
                    hits[2].transform.gameObject.GetComponent<PuzzlePiece>().popped = true;
                    Color color = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().color;
                    Sprite sprite = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                    if (color == Color.red || sprite == ukiyoOne || sprite == surrealOne || sprite == baroqueOne)
                    {
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = setRed + setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green || sprite == ukiyoTwo || sprite == surrealTwo || sprite == baroqueTwo)
                    {
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = setGreen + setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue || sprite == ukiyoThree || sprite == surrealThree || sprite == baroqueThree)
                    {
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = setBlue + setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow || sprite == ukiyoFour || sprite == surrealFour || sprite == baroqueFour)
                    {
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = setYellow + setYellowValue.ToString();
                        yellowHit = 0;
                    }
                    if (color == Color.magenta || sprite == ukiyoFive || sprite == surrealFive || sprite == baroqueFive)
                    {
                        magentaHit = hits.Length;
                        setMagentaValue += magentaHit;
                        magentaScore.text = setMagenta + setMagentaValue.ToString();
                        magentaHit = 0;
                    }
                }
            }
        }
        for (int i = 0; i < allPieces.Count; i++)
        {
            if (allPieces[i].GetComponent<PuzzlePiece>().popped == true)
            {
                allPieces[i].GetComponent<PuzzlePiece>().CallDestruction();
            }
        }
    }

    void TallyScore()
    {
        // Determine if the player reached the necessary score
        if (setYellowValue >= setYellowTotal && setBlueValue >= setBlueTotal && setGreenValue >= setGreenTotal && setRedValue >= setRedTotal && setMagentaValue >= setMagentaTotal)
        {
            int percentage = (setYellowValue % setYellowTotal + setBlueValue % setYellowTotal + setGreenValue % setGreenTotal + setRedValue % setRedTotal + setMagentaValue % setMagentaTotal) / 5;
            float match3Return;

            if (percentage <= 1)
            {
                print("winnning: " + percentage);
                match3Return = (1 - dragPenalty) * 100;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
            }

            if (percentage <= 2 && percentage > 1)
            {
                print("winnning: " + percentage);
                match3Return = (.9f - dragPenalty) * 100;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
            }

            if (percentage <= 3 && percentage > 2)
            {
                print("winnning: " + percentage);
                match3Return = (.8f - dragPenalty) * 100;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
            }

            if (percentage >= 4 && percentage > 3)
            {
                print("winnning: " + percentage);
                match3Return = (.7f - dragPenalty) * 100;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
            }

            if (percentage > 4)
            {
                print("winnning: " + percentage);
                match3Return = (.6f - dragPenalty) * 100;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
            }
        }

        else
        {
            print("losing");
        }
    }
}
