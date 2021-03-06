﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class traceScriptTwo : MonoBehaviour {

    // These values are the Vector values
    public float startX=0;
    public float startY=0;
    public float endX=0;
    public float endY=0;
    public float boundRadius = .25f;

    // Mouse position of last Frame
    Vector3 mousePositionOld;

    // Stores whether things have been hit or not
    public bool firstHit = false;
    public bool lastHit = false;
    //public GameObject firstSphere;
    //public GameObject lastSphere;

    // add up the score
    public int hitCount = 0;
    public int missCount = 0;
    public float successRatio;

    // information-related variables
    public float timeRemaining = 5.9f;
    public float timeRemainingTotal = 5.9f;
    public int tabsLeft = 2;
    public Text time;
    public Text tabs;
    public Text warning;

    // Start button renderer
    public Renderer rend;

    // Score-related variables
    public GameObject scoreCircle;
    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;
    public Sprite none;

    // Help and reset stuff
    public Text directions;
    public Button resetButton;
    public Button continueButton;

	AudioSource source;
	public int counter;
	public bool first;

    void Start()
    {
        // directions.enabled = !directions.enabled;
        if (GameObject.Find("GENERALUI"))
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
        source = gameObject.AddComponent<AudioSource>();
		counter = 1;
		first = false;
    }
    void Awake()
    {
        continueButton.interactable = false;
        resetButton.interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
        // set up current mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Don't let the player do anything until time is up
        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            time.text = (timeRemaining).ToString("n1");
            if (Input.GetMouseButton(0) && GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
            {
                warning.text = "Don't start early!";
            }
            resetButton.interactable = false;
        }
        // Tell the player to go
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            rend.enabled = false;
            time.text = "Go!";
            warning.text = " ";
            resetButton.interactable = true;
        }

        // If you press tab (I will remove this when possible)
        if (Input.GetKeyDown("tab"))
        {
            tabProcedure();
        }

        //if the mousePosition is within the bounds of startPoint
        if (CheckBoundaries(firstHit, startX, startY, mousePosition))
            firstHit = true;

        //if the mousePosition is within the bounds of endPoint
        if (CheckBoundaries(lastHit, endX, endY, mousePosition))
            lastHit = true;

        // if the line is being traced (mouse is down and mouseposition has changed)
        if (firstHit == true && lastHit != true && mousePositionOld != mousePosition && Input.GetMouseButton(0))
        {
            //if the mousePosition is within the bounds of tracing line, hitCount is added to
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (mousePosition)) 
			{
				hitCount++;
				if (first == false) 
				{
					source.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Ukiyo-E") as AudioClip;
					first = true;
				}
				source.Play ();
				Debug.Log ("called");
			}
            // if there is no segement hit, then the missCount is added to
            else
                missCount++;
        }

        // resets mousePosition to get ready for the next frame
        mousePositionOld = mousePosition;

        if (timeRemaining >= 0)
        {
            firstHit = false;
            lastHit = false;
            hitCount = 0;
            missCount = 0;
        }

        // if the last part has been hit,
        // check other variables,
        // and ultimately decide if the game should end 
        if(lastHit == true)
        {
            
            if (firstHit == false)
            {
                lastHit = false;
            }
            else
            {
                CalculateScore();
                DisplayScore();
                //resetButton.interactable = false;
                continueButton.interactable = true;
                //print("continueButton not interactable");
            }
        }
    }

    // If the reset button is pressed
    public void tabProcedure()
    {
        if (tabsLeft > 0)
        {
            tabsLeft--;
            tabs.text = "Resets remaining: " + tabsLeft.ToString();
            timeRemaining = timeRemainingTotal;
            gameObject.GetComponent<Renderer>().enabled = true;
            rend.enabled = true;
            successRatio = 0;
            scoreCircle.GetComponent<SpriteRenderer>().sprite = none;
        }

        else
        {
            tabs.text = "No more resets!";
        }
    }

    // Display the corresponding Grade on-screen
    public void DisplayScore()
    {
		if (counter == 1) 
		{
			source.clip = Resources.Load ("Sound/Mini-Game SFX/General/Game_Win_Music") as AudioClip;
			source.Play ();
			counter++;
		}
        if (successRatio>=.80)
            scoreCircle.GetComponent<SpriteRenderer>().sprite = A;
        if (successRatio >= .70 && successRatio < .80)
            scoreCircle.GetComponent<SpriteRenderer>().sprite = B;
        if (successRatio >= .60 && successRatio < .70)
            scoreCircle.GetComponent<SpriteRenderer>().sprite = C;
        if (successRatio < .60)
            scoreCircle.GetComponent<SpriteRenderer>().sprite = D;
    }

    // Calculate the player's score
    public void CalculateScore()
    {
        if(lastHit == true)
            successRatio = (float)hitCount / (float)(missCount + hitCount);
        else
            successRatio = 0;
    }

    // Boundary check for first, last spots
    public bool CheckBoundaries(bool hit, float xValue, float yValue, Vector3 mousePosition)
    {
        if (hit == false && Input.GetMouseButton(0)
        && (xValue >= mousePosition.x - boundRadius) && (xValue <= mousePosition.x + boundRadius)
        && (yValue >= mousePosition.y - boundRadius) && (yValue <= mousePosition.y + boundRadius))
            return true;
        else    
            return false;
    }

    // Moves to the scene player came from
    public void toPreviousScene()
    {
        if (PersistVars.previousScene != "null")
        {
            if (successRatio >= .80)
                GameObject.Find("GENERALUI").GetComponent<PersistVars>().tracerScore = .9f;
            if (successRatio >= .70 && successRatio < .80)
                GameObject.Find("GENERALUI").GetComponent<PersistVars>().tracerScore = .8f;
            if (successRatio >= .60 && successRatio < .70)
                GameObject.Find("GENERALUI").GetComponent<PersistVars>().tracerScore = .7f;
            if (successRatio < .60)
                GameObject.Find("GENERALUI").GetComponent<PersistVars>().tracerScore = .6f;


            SceneManager.LoadScene(PersistVars.currentScene);
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
        }
    }

    // Toggle directions
    public void showDirections()
    {
        directions.enabled = !directions.enabled;
    }
}
