using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BoardCreation : MonoBehaviour
{

    public GameObject puzzlePiecePrefab;
    public bool dragging = false;
    public bool spawning = false;

    private float deltaTime = 0.0f;
    private float timeSinceSpawned = 0.0f;
    private List<GameObject> allPieces = new List<GameObject>();
    private List<GameObject> markedPieces = new List<GameObject>();
    private GameObject puzzleObject;

    public float seconds = 60;

    public Text timer;
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
        }
    }

    // Use this for initialization
    void Start()
    {
        redScore.text = "0";
        yellowScore.text = "0";
        greenScore.text = "0";
        blueScore.text = "0";
        magentaScore.text = "0";

        puzzleObject = GameObject.Find("PuzzleObject");
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
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
                    //int squadSlot = -1;
                    Color color = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().color;
                    if (color == Color.red)
                    {
                        //squadSlot = 0;
                        print("red destroyed");
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green)
                    {
                        //squadSlot = 1;
                        print("green destroyed");
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue)
                    {
                        //squadSlot = 2;
                        print("blue destroyed");
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow)
                    {
                        //squadSlot = 3;
                        print("yellow destroyed");
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = setYellowValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.magenta)
                    {
                        //squadSlot = 4;
                        print("magenta destroyed");
                        magentaHit = hits.Length;
                        setMagentaValue += magentaHit;
                        magentaScore.text = setMagentaValue.ToString();
                        magentaHit = 0;
                    }
                    //GameObject.Find("Scripts").GetComponent<ShipScript>().Spawn(1, squadSlot);
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
                    //int squadSlot = -1;
                    Color color = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().color;
                    if (color == Color.red)
                    {
                        //squadSlot = 0;
                        print("red destroyed");
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green)
                    {
                        //squadSlot = 1;
                        print("green destroyed");
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue)
                    {
                        //squadSlot = 2;
                        print("blue destroyed");
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow)
                    {
                        //squadSlot = 3;
                        print("yellow destroyed");
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = setYellowValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.magenta)
                    {
                        //squadSlot = 4;
                        print("magenta destroyed");
                        magentaHit = hits.Length;
                        setMagentaValue += magentaHit;
                        magentaScore.text = setMagentaValue.ToString();
                        magentaHit = 0;
                    }
                    //GameObject.Find("Scripts").GetComponent<ShipScript>().Spawn(1, squadSlot);
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
}
