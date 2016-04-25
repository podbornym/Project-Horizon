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

    // Sets the sprites for Ukiyo-e levels
    public Sprite ukiyoOne;
    public Sprite ukiyoTwo;
    public Sprite ukiyoThree;
    public Sprite ukiyoFour;
    public Sprite ukiyoFive;
    // Sets the sprites for the Surrealism levels
    public Sprite surrealOne;
    public Sprite surrealTwo;
    public Sprite surrealThree;
    public Sprite surrealFour;
    public Sprite surrealFive;
    // Sets the sprites for the Baroque levels
    public Sprite baroqueOne;
    public Sprite baroqueTwo;
    public Sprite baroqueThree;
    public Sprite baroqueFour;
    public Sprite baroqueFive;

    //public Scene currentScene;

    private float deltaTime = 0.0f;
    private float timeSinceSpawned = 0.0f;
    private List<GameObject> allPieces = new List<GameObject>();
    private List<GameObject> markedPieces = new List<GameObject>();
    private GameObject puzzleObject;

    // Timer variables for setting time, keeping track of dragging
    private float seconds = 90;
    public Text timer;

    private float warningSec = 7f;
    private float warningTimer = 0f;    

    // Variables for keeping track of score
    public Text redScore;
    public Text yellowScore;
    public Text blueScore;
    public Text greenScore;
    public Text magentaScore;

    // Sets the value of the score
    private int setRedValue = 0;
    private int setGreenValue = 0;
    private int setBlueValue = 0;
    private int setYellowValue = 0;
    private int setMagentaValue = 0;

    // Keeps track of how many tiles were matched, adds them to the int above
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
    
    // Set specific goal for this level
    private int setRedTotal;
    private int setGreenTotal;
    private int setBlueTotal;
    private int setYellowTotal;
    private int setMagentaTotal;

    // Set text for the color category
    private string setRed;
    private string setGreen;
    private string setBlue;
    private string setYellow;
    private string setMagenta;

    public float dragPenalty;

    public Text warningText;

    public PersistVars match3;

    // Sets Ukiyo-e backgrounds per level
    public Sprite u0Back;
    public Sprite u1Back;
    public Sprite u2Back;
    public Sprite u3Back;
    public Sprite u4Back;
    public Sprite u5Back;
    // Sets Surrealism backgrounds per level
    public Sprite s0Back;
    public Sprite s1Back;
    public Sprite s2Back;
    public Sprite s3Back;
    public Sprite s4Back;
    public Sprite s5Back;
    // Sets Baroque backgrounds per level
    public Sprite b0Back;
    public Sprite b1Back;
    public Sprite b2Back;
    public Sprite b3Back;
    public Sprite b4Back;
    public Sprite b5Back;

    // Sprites for use in grading
    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;

    // Sliders for visual cues
    public Slider red;
    public Slider green;
    public Slider yellow;
    public Slider blue;
    public Slider magenta;

    public static float match3Return;

	// clips
	public AudioClip m1;
	public AudioClip m2;
	public AudioClip m3;
	public AudioClip m4;
	public AudioClip m5;

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

        // Once time is up, disallow player movement, allow the player to continue
        if(seconds <= 0)
        {
            dragging = true;
            spawning = true;
            timer.color = Color.red;
            timer.text = "Time's Up!";

            TallyScore();
            //GameObject.Find("Next Button").GetComponent<Button>().interactable = true;
        }

        warningTimer += Time.deltaTime;

        // If the player is dragging for too long, add a score penalty
        if(dragging && seconds > 0)
        {
            if(warningTimer >= warningSec)
            {
                warningTimer = 0f;
                dragPenalty += .02f;
                warningText.color = Color.red;
                warningText.text = "Warning: Dragging for too long will incur a score penalty!";
            }
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            seconds -= 10;
        }

        red.value = setRedValue;
        green.value = setGreenValue;
        yellow.value = setYellowValue;
        blue.value = setBlueValue;
        magenta.value = setMagentaValue;
    }

    // Use this for initialization
    void Start()
    {
        // Disable the UI's canvas, attach the PersistBVars script to our match3 object
        if(GameObject.Find("GENERALUI"))
        {
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
            //match3 = GameObject.Find("GENERALUI").GetComponent<PersistVars>();
        }

        //PersistVars.Ukiyo = true; //make sure to remove once the game gets going
        //print(PersistVars.currentScene);
        //string scene = PersistVars.currentScene;

        // Set score, text, background variables to Ukiyo-e
        if(PersistVars.Ukiyo)
        {
            setRed = "Flower: ";
            setYellow = "Octopus: ";
            setGreen = "Frog: ";
            setBlue = "Fish: ";
            setMagenta = "Coin: ";

            switch(PersistVars.currentScene)
            {
                case "U_0": // 1st Ukiyo-e studio
                    setRedTotal = 15;
                    setYellowTotal = 15;
                    setGreenTotal = 25;
                    setBlueTotal = 3;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = u0Back;
                    break;
                case "U_1": // 2nd Ukiyo-e studio
                    setRedTotal = 10;
                    setYellowTotal = 10;
                    setGreenTotal = 10;
                    setBlueTotal = 10;
                    setMagentaTotal = 10;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = u1Back;
                    break;
                case "U_2": // 3rd Ukiyo-e studio
                    setRedTotal = 25;
                    setYellowTotal = 3;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 25;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = u2Back;
                    break;
                case "U_3": // 4th Ukiyo-e studio
                    setRedTotal = 3;
                    setYellowTotal = 25;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 25;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = u3Back;
                    break;
                case "U_4": // 5th Ukiyo-e studio
                    setRedTotal = 10;
                    setYellowTotal = 3;
                    setGreenTotal = 3;
                    setBlueTotal = 40;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = u4Back;
                    break;
                case "U_5": // 6th Ukiyo-e studio
                    setRedTotal = 20;
                    setYellowTotal = 3;
                    setGreenTotal = 30;
                    setBlueTotal = 3;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = u5Back;
                    break;
                default: // No valid Ukiyo-e studio
                    print("did not find a valid studio for match3 ukiyo-e variables");
                    setRedTotal = 10;
                    setYellowTotal = 10;
                    setGreenTotal = 10;
                    setBlueTotal = 10;
                    setMagentaTotal = 10;
                    break;
            }
        }
        // Set score, text, background variables to Surrealism
        if (PersistVars.Surreal)
        {
            setRed = "Apple: ";
            setYellow = "Skull: ";
            setGreen = "Pipe: ";
            setBlue = "Hat: ";
            setMagenta = "Clock: ";

            switch (PersistVars.currentScene)
            {
                case "S_O": // 1st Surrealism studio
                    setRedTotal = 23;
                    setYellowTotal = 3;
                    setGreenTotal = 23;
                    setBlueTotal = 23;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = s0Back;
                    break;
                case "S_1": // 2nd Surrealism studio
                    setRedTotal = 3;
                    setYellowTotal = 50;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = s1Back;
                    break;
                case "S_2": // 3rd Surrealism studio
                    setRedTotal = 25;
                    setYellowTotal = 3;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 25;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = s2Back;
                    break;
                case "S_3": // 4th Surrealism studio
                    setRedTotal = 3;
                    setYellowTotal = 50;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 50;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = s3Back;
                    break;
                case "S_4": // 5th Surrealism studio
                    setRedTotal = 10;
                    setYellowTotal = 3;
                    setGreenTotal = 3;
                    setBlueTotal = 40;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = s4Back;
                    break;
                case "S_5": // 6th Surrealism studio
                    setRedTotal = 30;
                    setYellowTotal = 3;
                    setGreenTotal = 20;
                    setBlueTotal = 3;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = s5Back;
                    break;
                default: // No valid Surrealism studio found
                    print("did not find a valid studio for match3 surrealism variables");
                    setRedTotal = 10;
                    setYellowTotal = 10;
                    setGreenTotal = 10;
                    setBlueTotal = 10;
                    setMagentaTotal = 10;
                    break;
            }
        }
        // Set score, text, background variables to Baroque
        if (PersistVars.Baroque)
        {
            setRed = "Blue: ";
            setYellow = "Orangel: ";
            setGreen = "Green: ";
            setBlue = "Blue: ";
            setMagenta = "Pearl: ";

            switch (PersistVars.currentScene)
            {
                case "B_O": // 1st Baroque studio
                    setRedTotal = 23;
                    setYellowTotal = 3;
                    setGreenTotal = 23;
                    setBlueTotal = 23;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = b0Back;
                    break;
                case "B_1": // 2nd Baroque studio
                    setRedTotal = 3;
                    setYellowTotal = 50;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = b1Back;
                    break;
                case "B_2": // 3rd Baroque studio
                    setRedTotal = 25;
                    setYellowTotal = 3;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 25;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = b2Back;
                    break;
                case "B_3": // 4th Baroque studio
                    setRedTotal = 3;
                    setYellowTotal = 25;
                    setGreenTotal = 3;
                    setBlueTotal = 3;
                    setMagentaTotal = 25;
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = b3Back;
                    break;
                case "B_4": // 5th Baroque studio
                    setRedTotal = 10;
                    setYellowTotal = 1;
                    setGreenTotal = 1;
                    setBlueTotal = 40;
                    setMagentaTotal = 1;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = b4Back;
                    break;
                case "B_5": // 6th Baroque studio
                    setRedTotal = 30;
                    setYellowTotal = 3;
                    setGreenTotal = 20;
                    setBlueTotal = 3;
                    setMagentaTotal = 3;
                    GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().sprite = b5Back;
                    break;
                default: // No valid Baroque studio found
                    print("did not find a valid studio for match3 baroque variables");
                    setRedTotal = 10;
                    setYellowTotal = 10;
                    setGreenTotal = 10;
                    setBlueTotal = 10;
                    setMagentaTotal = 10;
                    break;
            }
        }

        // Set the color of the backgrund sprite, to make it appear further in the background
        GameObject.Find("BackgroundImage").GetComponent<SpriteRenderer>().color = Color.grey;// new Color(36, 36, 36, 255);//232323FF;

        // Set our score total equal to those values of the correct variables found above
        redTotal.text = "/" + setRedTotal + " |";
        yellowTotal.text = "/" + setYellowTotal + " |";
        greenTotal.text = "/" + setGreenTotal + " |";
        blueTotal.text = "/" + setBlueTotal + " |";
        magentaTotal.text = "/" + setMagentaTotal;
        // Set our correct tile text to those values of the correct variables found above
        redScore.text =  setRed + "0";
        yellowScore.text = setYellow + "0";
        greenScore.text = setGreen + "0";
        blueScore.text = setBlue + "0";
        magentaScore.text = setMagenta + "0";

        red.maxValue = setRedTotal;
        green.maxValue = setGreenTotal;
        yellow.maxValue = setYellowTotal;
        blue.maxValue = setBlueTotal;
        magenta.maxValue = setMagentaTotal;

        // Find our "parent" puzzle tile
        puzzleObject = GameObject.Find("PuzzleObject");

        // Instantiate the board at Start()
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                // Look into giving priority to other pieces
                GameObject newPiece = Instantiate(puzzlePiecePrefab, new Vector2(-2.2f + i * 0.87f, -4.5f + j * 0.87f), Quaternion.identity) as GameObject;
                //GameObject newPiece = Instantiate(puzzlePiecePrefab, new Vector2(-2.2f + i * 0.87f, j * 0.87f), Quaternion.identity) as GameObject;
                newPiece.transform.SetParent(puzzleObject.transform);
                // Set the tile sprites to Ukiyo-e sprites
                if (PersistVars.Ukiyo)
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
                // Set the tile sprites to Surrealism sprites
                if (PersistVars.Surreal)
                {
                    switch (Random.Range(0, 5))
                    {
                        case 0:
                            newPiece.GetComponent<SpriteRenderer>().sprite = surrealOne;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                            break;
                        case 1:
                            newPiece.GetComponent<SpriteRenderer>().sprite = surrealTwo;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                            break;
                        case 2:
                            newPiece.GetComponent<SpriteRenderer>().sprite = surrealThree;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                            break;
                        case 3:
                            newPiece.GetComponent<SpriteRenderer>().sprite = surrealFour;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                            break;
                        case 4:
                            newPiece.GetComponent<SpriteRenderer>().sprite = surrealFive;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                            break;
                    }
                }
                // Set the tile sprites to Baroque sprites
                if (PersistVars.Baroque)
                {
                    switch (Random.Range(0, 5))
                    {
                        case 0:
                            newPiece.GetComponent<SpriteRenderer>().sprite = baroqueOne;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                            break;
                        case 1:
                            newPiece.GetComponent<SpriteRenderer>().sprite = baroqueTwo;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                            break;
                        case 2:
                            newPiece.GetComponent<SpriteRenderer>().sprite = baroqueThree;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                            break;
                        case 3:
                            newPiece.GetComponent<SpriteRenderer>().sprite = baroqueFour;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                            break;
                        case 4:
                            newPiece.GetComponent<SpriteRenderer>().sprite = baroqueFive;
                            newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                            break;
                    }
                }
            }
        }
    }

    // Create new pieces when others have been popped
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
                    // Set the tile sprites to Ukiyo-e sprites
                    if (PersistVars.Ukiyo)
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
                    // Set the tile sprites to Surrealism sprites
                    if (PersistVars.Surreal)
                    {
                        switch (Random.Range(0, 5))
                        {
                            case 0:
                                newPiece.GetComponent<SpriteRenderer>().sprite = surrealOne;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                                break;
                            case 1:
                                newPiece.GetComponent<SpriteRenderer>().sprite = surrealTwo;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                                break;
                            case 2:
                                newPiece.GetComponent<SpriteRenderer>().sprite = surrealThree;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                                break;
                            case 3:
                                newPiece.GetComponent<SpriteRenderer>().sprite = surrealFour;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                                break;
                            case 4:
                                newPiece.GetComponent<SpriteRenderer>().sprite = surrealFive;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                                break;
                        }
                    }
                    // Set the tile sprites to Baroque sprites
                    if (PersistVars.Baroque)
                    {
                        switch (Random.Range(0, 5))
                        {
                            case 0:
                                newPiece.GetComponent<SpriteRenderer>().sprite = baroqueOne;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.green;
                                break;
                            case 1:
                                newPiece.GetComponent<SpriteRenderer>().sprite = baroqueTwo;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.red;
                                break;
                            case 2:
                                newPiece.GetComponent<SpriteRenderer>().sprite = baroqueThree;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.blue;
                                break;
                            case 3:
                                newPiece.GetComponent<SpriteRenderer>().sprite = baroqueFour;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.yellow;
                                break;
                            case 4:
                                newPiece.GetComponent<SpriteRenderer>().sprite = baroqueFive;
                                newPiece.GetComponent<PuzzlePiece>().color = Color.magenta;
                                break;
                        }
                    }
                }
            }
        }
        timeSinceSpawned = 1.0f;
    }

    // Add the current tile pieces (on the board) to our list
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
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m1, 1.0f);
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = setRed + setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green || sprite == ukiyoTwo || sprite == surrealTwo || sprite == baroqueTwo)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m2, 1.0f);
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = setGreen + setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue || sprite == ukiyoThree || sprite == surrealThree || sprite == baroqueThree)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m3, 1.0f);
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = setBlue + setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow || sprite == ukiyoFour || sprite == surrealFour || sprite == baroqueFour)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m4, 1.0f);
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = setYellow + setYellowValue.ToString();
                        yellowHit = 0;
                    }
                    if (color == Color.magenta || sprite == ukiyoFive || sprite == surrealFive || sprite == baroqueFive)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m5, 1.0f);
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
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m1, 1.0f);
                        redHit = hits.Length;
                        setRedValue += redHit;
                        redScore.text = setRed + setRedValue.ToString();
                        redHit = 0;
                    }
                    if (color == Color.green || sprite == ukiyoTwo || sprite == surrealTwo || sprite == baroqueTwo)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m2, 1.0f);
                        greenHit = hits.Length;
                        setGreenValue += greenHit;
                        greenScore.text = setGreen + setGreenValue.ToString();
                        greenHit = 0;
                    }
                    if (color == Color.blue || sprite == ukiyoThree || sprite == surrealThree || sprite == baroqueThree)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m3, 1.0f);
                        blueHit = hits.Length;
                        setBlueValue += blueHit;
                        blueScore.text = setBlue + setBlueValue.ToString();
                        blueHit = 0;
                    }
                    if (color == Color.yellow || sprite == ukiyoFour || sprite == surrealFour || sprite == baroqueFour)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m4, 1.0f);
                        yellowHit = hits.Length;
                        setYellowValue += yellowHit;
                        yellowScore.text = setYellow + setYellowValue.ToString();
                        yellowHit = 0;
                    }
                    if (color == Color.magenta || sprite == ukiyoFive || sprite == surrealFive || sprite == baroqueFive)
                    {
						puzzleObject.GetComponent<AudioSource> ().PlayOneShot (m5, 1.0f);
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

    // Determine and display score
    public void TallyScore()
    {
        // Determine if the player reached the necessary score
        /*if ((setYellowValue >= setYellowTotal && setBlueValue >= setBlueTotal && setGreenValue >= setGreenTotal && setRedValue >= setRedTotal && setMagentaValue >= setMagentaTotal) ||
            (setYellowValue - setYellowTotal <= -2 && setBlueValue - setYellowTotal <=-2 && setGreenValue - setGreenTotal <=-2 && setRedValue - setRedTotal <=-2 && setMagentaValue - setMagentaTotal <=-2))
        {*/
            int percentage = (setYellowValue % setYellowTotal + setBlueValue % setYellowTotal + setGreenValue % setGreenTotal + setRedValue % setRedTotal + setMagentaValue % setMagentaTotal) / 5;
            //float match3Return;

            if (percentage <= 1)
            {
                match3Return = (1 - dragPenalty) * 100 + 10;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
                GameObject.Find("GradeImage").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeImage").GetComponent<Image>().sprite = A;
            }

            if (percentage <= 2 && percentage > 1)
            {
                match3Return = (.9f - dragPenalty) * 100 + 10;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
                GameObject.Find("GradeImage").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeImage").GetComponent<Image>().sprite = A;
            }

            if (percentage <= 3 && percentage > 2)
            {
                match3Return = (.8f - dragPenalty) * 100 + 10;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
                GameObject.Find("GradeImage").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeImage").GetComponent<Image>().sprite = B;
            }

            if (percentage >= 4 && percentage > 3)
            {
                match3Return = (.7f - dragPenalty) * 100 + 10;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
                GameObject.Find("GradeImage").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeImage").GetComponent<Image>().sprite = C;
            }

            if (percentage > 4)
            {
                match3Return = (.6f - dragPenalty) * 100 + 10;
                warningText.color = Color.green;
                warningText.text = "Your score was: " + match3Return + "%";
                GameObject.Find("GradeImage").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeImage").GetComponent<Image>().sprite = D;
            }
        //}

        /*else
        {
            GameObject.Find("GradeImage").GetComponent<Image>().enabled = true;
            GameObject.Find("GradeImage").GetComponent<Image>().sprite = D;
        }*/
    }
}
