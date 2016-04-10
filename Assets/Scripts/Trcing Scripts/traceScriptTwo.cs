using UnityEngine;
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
    // They're already false by default, so...
    public bool firstHit = false;
    public bool lastHit = false;
    public bool aSegmentHit = false;

    // add up the score
    public int hitCount = 0;
    public int missCount = 0;
    public float successRatio;

    public float timeRemaining = 2f;
    public int tabsLeft = 5;
    public Text score;
    public Text time;
    public Text tabs;
    public Text warning;
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print(mousePosition);

        if (Input.GetMouseButton(0) && timeRemaining >= 0)
        {
            warning.text = "Don't start early!";
        }

        //if the mousePosition is within the bounds of startPoint
        if (CheckBoundaries(firstHit, startX, startY, mousePosition))
        {
            firstHit = true;
            print("Start Hit");
        }

        //if the mousePosition is within the bounds of endPoint
        if (CheckBoundaries(lastHit, endX, endY, mousePosition))
        {
            lastHit = true;
            print("Finish Hit");
        }

        //if the mousePosition is within the bounds of tracing line
        if( GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition) && firstHit == true)
        {
            if (mousePositionOld != mousePosition && lastHit != true && Input.GetMouseButton(0))
            {
                hitCount++;
                aSegmentHit = true;
            }
        }
        
        if (aSegmentHit != true && mousePositionOld != mousePosition && firstHit == true && lastHit != true && Input.GetMouseButton(0))
        {
            missCount++;
        }

        aSegmentHit = false;
        mousePositionOld = mousePosition;

        if(lastHit == true)
        {
            // The rules have become a bit strange.
            // I'm going to look into this
            if (firstHit == false)
            {
                lastHit = false;
            }
            else if (timeRemaining >= 0)
            {
                firstHit = false;
                lastHit = false;
                hitCount = 0;
                missCount = 0;
            }
            else
            {
                CalculateScore();
                DisplayScore();
            }

        }

        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            time.text = "Inspection Time Remaining: " + (timeRemaining).ToString("n2");
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            time.text = "Go!";
            warning.text = " ";
            if (tabs.text != "No more tabs!")
                tabs.text = "Tabs remaining: " + tabsLeft.ToString() + "  You can try again by pressing tab";
        }

        if (Input.GetKeyDown("tab"))
        {
            tabProcedure();
        }
    }

    public void tabProcedure()
    {
        if (tabsLeft > 0)
        {
            tabsLeft--;
            tabs.text = "Tabs remaining: " + tabsLeft.ToString();
            timeRemaining = 2f;
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        else
        {
            tabs.text = "No more tabs!";
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
}
