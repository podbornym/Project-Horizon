﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    // add up the score
    public int hitCount = 0;
    public int missCount = 0;
    public float successRatio;

    // information related variables
    public float timeRemaining = 5.9f;
    public float timeRemainingTotal = 5.9f;
    public int tabsLeft = 5;
    public Text score;
    public Text time;
    public Text tabs;
    public Text warning;

    void Start()
    {
        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        // set up current mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            time.text = "Inspection Time Remaining: " + (timeRemaining).ToString("n1");
            if (Input.GetMouseButton(0) && GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
            {
                warning.text = "Don't start early!";
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            time.text = "Go!";
            warning.text = " ";
            if (tabs.text != "No more resets!")
                tabs.text = "Resets remaining: " + tabsLeft.ToString();
        }

        if (Input.GetKeyDown("tab"))
            tabProcedure();

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
            if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
                hitCount++;
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
            }
        }
    }

    public void tabProcedure()
    {
        if (tabsLeft > 0)
        {
            tabsLeft--;
            tabs.text = "Resets remaining: " + tabsLeft.ToString();
            timeRemaining = timeRemainingTotal;
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        else
        {
            tabs.text = "No more resets!";
        }
    }

    public void DisplayScore()
    {
        if (successRatio>=.90)
            score.text = "Grade: A.";
        if (successRatio >= .80 && successRatio < .90)
            score.text = "Grade: B.";
        if (successRatio >= .70 && successRatio < .80)
            score.text = "Grade: C.";
        if (successRatio >= .60 && successRatio < .70)
            score.text = "Grade: D.";
        if (successRatio < .60)
            score.text = "Grade: F.";
    }

    public void CalculateScore()
    {
        if(lastHit == true)
            successRatio = (float)hitCount / (float)(missCount + hitCount);
        else
            successRatio = 0;
    }

    public bool CheckBoundaries(bool hit, float xValue, float yValue, Vector3 mousePosition)
    {
        if (hit == false && Input.GetMouseButton(0)
        && (xValue >= mousePosition.x - boundRadius) && (xValue <= mousePosition.x + boundRadius)
        && (yValue >= mousePosition.y - boundRadius) && (yValue <= mousePosition.y + boundRadius))
            return true;
        else    
            return false;
    }

    public void toPreviousScene()
    {
        //will add this soon
    }
}