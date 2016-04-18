using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScipt : MonoBehaviour {

    public Text timeCounter;
    public static float seconds;
    public float zScore;
    public float zError;
    public float zTotalScore;
    public Text finishText;

    public GameObject[] puzzlePieces = new GameObject[3];
    private SelectAndMove[] puzzleSM;

    void Awake()
    {
        puzzleSM = new SelectAndMove[puzzlePieces.Length];
        int i = 0;
        foreach (GameObject cur in puzzlePieces)
        {
            puzzleSM[i] = cur.GetComponent<SelectAndMove>();
            i++;
        }
    }

	// Use this for initialization
	void Start () {
        seconds = 0;
        timeCounter = GameObject.Find("TimerText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        seconds += Time.deltaTime;
        timeCounter.text = seconds.ToString("0");	
	}

    public void finishButtonClicked()
    {
        //GameObject.FindGameObjectWithTag("WaveArt").GetComponent<SelectAndMove>().finishButtonClicked();

        //        zScore = zError/zPerfectScore;//out of 100 ---> 0


        if (puzzleSM == null)
        {
            print("ERROR: waveSM is null");
        }

        int i = 0;
        float posScore = 0;
        zTotalScore = 0;
        foreach (SelectAndMove cur in puzzleSM)
        {
            if (cur == null)
            {
                print("ERROR: cur[" + i + "] is null");
            }
			print ("Piece[" + i + "] has position score " + cur.returnPosScore () + " and rotated score " + cur.returnZScore ());
            posScore += cur.returnPosScore();
            zTotalScore += cur.returnZScore();
            i++;
        }
        //posScore /= 4.0f;
        //zTotalScore /= 4.0f;
        //if (zTotalScore > 180)
        //{
        //    zTotalScore = 360 - zTotalScore;
        //}
        print("Returned position score: " + posScore);
        print("Rotation Score: " + zTotalScore);


        if ((posScore < 9) && (zTotalScore < 15))
        {
            print("You have done 'A' quality work!");
            finishText.text = "You have earned an A for this work";
        }
        else if ((posScore < 15) && (zTotalScore < 23))
        {
            print("You have done 'B' quality work!");
        }
        else if ((posScore < 20) && (zTotalScore < 30))
        {
            print("You have done 'C' quality work!");
        }
        else
        {
            print("You have done 'D' quality work.");
            finishText.color = Color.red;
            finishText.text = "You have earned a D for this work";
        }
    }
}
