using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class traceLayoutManager : MonoBehaviour {

    // These values are the Vector values
    public float startX=0;
    public float startY=0;
    public float endX=0;
    public float endY=0;
    public float[] linePointsX;
    public float[] linePointsY;
    public float boundRadius;

    // we might not need some of these Vectors
    // it's easier to not even use them
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3[] linePoints;
    Vector3 mousePositionOld;

    // Stores whether things have been hit or not
    // They're already false by default, so...
    public bool firstHit = false;
    public bool lastHit = false;
    public bool[] lineHit; // We don't really need to know if the lines have been hit...
    public bool complete = false;
    public bool aSegmentHit = false;

    // add up the score
    public int hitCount = 0;
    public int missCount = 0;
    public float successRatio;

    public Text score;
    public Text warning;


    public GameObject Tracer;

    void Awake() {}

	// Use this for initialization
	void Start ()
    {
        //Set up the startPoint, endPoint, linePoints

        /*startPoint.Set(startX, startY, -10);
        endPoint.Set(endX, endY, 0);*/
		
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && Tracer.GetComponent<traceScript>().timeRemaining >= 0)
        {
            warning.text = "Don't start early!";
        }
        //if the mousePosition is within the bounds of startPoint
        if (firstHit == false && Input.GetMouseButton(0)
            && (startX >= mousePosition.x - boundRadius) && (startX <= mousePosition.x + boundRadius)
            && (startY >= mousePosition.y - boundRadius) && (startY <= mousePosition.y + boundRadius))
        {
            firstHit = true;
            print("Start Hit");
        }

        //if the mousePosition is within the bounds of endPoint
        if (lastHit == false && Input.GetMouseButton(0)
            && (endX >= mousePosition.x - boundRadius) && (endX <= mousePosition.x + boundRadius)
            && (endY >= mousePosition.y - boundRadius) && (endY <= mousePosition.y + boundRadius))
        {
            lastHit = true;
            print("Finish Hit");
        }

        //if the mousePosition is within the bounds of linePoints
        for (int i = 0; i < linePointsX.Length; i++)
        {
            if (firstHit == true
            && (linePointsX[i] >= mousePosition.x - boundRadius) && (linePointsX[i] <= mousePosition.x + boundRadius)
            && (linePointsY[i] >= mousePosition.y - boundRadius) && (linePointsY[i] <= mousePosition.y + boundRadius))
            {
                if (mousePositionOld != mousePosition && lastHit != true && Input.GetMouseButton(0))
                {
                    hitCount++;
                    //lineHit[i] = true;
                    //print("Line part " + i + " Hit");
                    aSegmentHit = true;
                }
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
            else if (Tracer.GetComponent<traceScript>().timeRemaining >= 0)
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
        {
            successRatio = 0;
            //DisplayScore();
        }
    }
}
