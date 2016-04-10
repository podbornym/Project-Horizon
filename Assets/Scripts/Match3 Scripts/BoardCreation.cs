using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoardCreation : MonoBehaviour
{
    // Variables used for initialization, game tracking
    public GameObject puzzlePiecePrefab;
    public bool dragging = false;
    public bool spawning = false;

    private float deltaTime = 0.0f;
    private float timeSinceSpawned = 0.0f;
    private List<GameObject> allPieces = new List<GameObject>();
    private List<GameObject> markedPieces = new List<GameObject>();
    private GameObject puzzleObject;

    // Timer variables for setting time
    public float seconds = 90;

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

    private int setRedTotal = 10;
    private int setGreenTotal = 10;
    private int setBlueTotal = 10;
    private int setYellowTotal = 10;
    private int setMagentaTotal = 10;

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
            timer.text = "Time's Up!";

            TallyScore();
            GameObject.Find("Next Button").GetComponent<Button>().interactable = true;
        } 
    }

    // Use this for initialization
    void Start()
    {
        // Disable the UI's canvas
        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
        // set the eventsystem to the parent of the game's ui 
        //GameObject.Find("GENERALUI").GetComponent<EventSystem>().enabled = false;//.transform.parent = GameObject.Find("Canvas").transform;
        // remember to reassign this back to the UI

        // Use bool in persist vars
            // if zone
                // if level
                    // set initial values, colors
        redScore.text = "Red: 0";
        yellowScore.text = "Yellow: 0";
        greenScore.text = "Green: 0";
        blueScore.text = "Blue: 0";
        magentaScore.text = "Magenta: 0";

        // Use bool in persist vars
        // if zone
            // if level
                // set total
        redTotal.text = "/" + setRedTotal;
        yellowTotal.text = "/" + setYellowTotal;
        greenTotal.text = "/" + setGreenTotal;
        blueTotal.text = "/" + setBlueTotal;
        magentaTotal.text = "/" + setMagentaTotal;

        puzzleObject = GameObject.Find("PuzzleObject");
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                // Look into giving priority to other pieces - first need different available pieces!!
                GameObject newPiece = Instantiate(puzzlePiecePrefab, new Vector2(-2.2f + i * 0.87f, -4.5f + j * 0.87f), Quaternion.identity) as GameObject;
                newPiece.transform.SetParent(puzzleObject.transform);
                switch (Random.Range(0, 5))
                {
                    case 0:
                        newPiece.GetComponent<SpriteRenderer>().color = Color.green;
                        newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                        break;
                    case 1:
                        newPiece.GetComponent<SpriteRenderer>().color = Color.red;
                        newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                        break;
                    case 2:
                        newPiece.GetComponent<SpriteRenderer>().color = Color.blue;
                        newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                        break;
                    case 3:
                        newPiece.GetComponent<SpriteRenderer>().color = Color.yellow;
                        newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                        break;
                    case 4:
                        newPiece.GetComponent<SpriteRenderer>().color = Color.magenta;
                        newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                        break;
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
                    switch (Random.Range(0, 5))
                    {
                        case 0:
                            newPiece.GetComponent<SpriteRenderer>().color = Color.green;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                            break;
                        case 1:
                            newPiece.GetComponent<SpriteRenderer>().color = Color.red;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                            break;
                        case 2:
                            newPiece.GetComponent<SpriteRenderer>().color = Color.blue;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                            break;
                        case 3:
                            newPiece.GetComponent<SpriteRenderer>().color = Color.yellow;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                            break;
                        case 4:
                            newPiece.GetComponent<SpriteRenderer>().color = Color.magenta;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                            break;
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
                    if (color == Color.red)
                    {
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = "Red: " + setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green)
                    {
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = "Green: " + setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue)
                    {
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = "Blue: " + setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow)
                    {
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = "Yellow: " + setYellowValue.ToString();
                        yellowHit = 0;
                    }
                    if (color == Color.magenta)
                    {
                        magentaHit = hits.Length;
                        setMagentaValue += magentaHit;
                        magentaScore.text = "Magenta: " + setMagentaValue.ToString();
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
                    if (color == Color.red)
                    {
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = "Red: " + setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green)
                    {
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = "Green: " + setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue)
                    {
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = "Blue: " + setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow)
                    {
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = "Yellow: " + setYellowValue.ToString();
                        yellowHit = 0;
                    }
                    if (color == Color.magenta)
                    {
                        magentaHit = hits.Length;
                        setMagentaValue += magentaHit;
                        magentaScore.text = "Magenta: " + setMagentaValue.ToString();
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
