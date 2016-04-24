using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerScipt : MonoBehaviour {

    public Text timeCounter;
    public static float seconds;
    public float zScore;
    public float zError;
    public float zTotalScore;
    public Text finishText;
	public float rotatoTotalScore;

	public Sprite helpScreen;
	public Sprite GradeA;
	public Sprite GradeB;
	public Sprite GradeC;
	public Sprite GradeD;

    public GameObject[] puzzlePieces = new GameObject[2];
    private SelectAndMove[] puzzleSM;

    void Awake()
    {
		//GameObject.Find ("Help Screen").GetComponent<Image> ().sprite = helpScreen;

        puzzleSM = new SelectAndMove[puzzlePieces.Length];
        int i = 0;
        foreach (GameObject cur in puzzlePieces)
        {
			print (cur);
			puzzleSM[i] = cur.GetComponent<SelectAndMove>();
            i++;
        }
        
    }

	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("GENERALUI").GetComponent<Canvas> ().enabled == true) 
		{
			GameObject.Find ("GENERALUI").GetComponent<Canvas> ().enabled = false;
		}


        seconds = 0;
        timeCounter = GameObject.Find("TimerText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        seconds += Time.deltaTime;
        timeCounter.text = seconds.ToString("0");	
	}

	public void continueButtonClicked()
	{
		if (PersistVars.previousScene != "null") 
		{
			GameObject.Find ("GENERALUI").GetComponent<PersistVars> ().rotatoScore = rotatoTotalScore;
			SceneManager.LoadScene (PersistVars.previousScene);
			GameObject.Find ("GENERALUI").GetComponent<Canvas> ().enabled = true;
		}

	}

	public void helpButtonClicked()
	{
		GameObject.Find ("Help Screen").GetComponent<Image> ().enabled = !GameObject.Find ("Help Screen").GetComponent<Image> ().enabled;

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
		foreach (GameObject cur in puzzlePieces)
        {
			print (cur);
            if (cur == null)
            {
                print("ERROR: cur[" + i + "] is null");
            }

			//print ("Piece[" + i + "] has position score " + cur.returnPosScore () + " and rotated score " + cur.returnZScore ());
//			print(cur.GetComponent<SelectAndMove>().returnPosScore() );

			/*
			posScore += cur.GetComponent<SelectAndMove>().returnPosScore();
			zTotalScore += cur.GetComponent<SelectAndMove>().returnZScore();
            i++;
            */
        }

        print("Returned position score: " + posScore);
        print("Rotation Score: " + zTotalScore);

		GameObject.Find ("GradeUI").GetComponent<Image> ().enabled = true;
		GameObject.Find ("GradeUI").GetComponent<Image> ().sprite = GradeA;

        if ((posScore < 9) && (zTotalScore < 15))
        {
            print("You have done 'A' quality work!");
			GameObject.Find ("GradeUI").GetComponent<Image> ().enabled = true;
			GameObject.Find ("GradeUI").GetComponent<Image> ().sprite = GradeA;
        }
        else if ((posScore < 15) && (zTotalScore < 23))
        {
            print("You have done 'B' quality work!");
			GameObject.Find ("GradeUI").GetComponent<Image> ().enabled = true;
			GameObject.Find ("GradeUI").GetComponent<Image> ().sprite = GradeB;
        }
        else if ((posScore < 20) && (zTotalScore < 30))
        {
            print("You have done 'C' quality work!");
			GameObject.Find ("GradeUI").GetComponent<Image> ().enabled = true;
			GameObject.Find ("GradeUI").GetComponent<Image> ().sprite = GradeC;
        }
        else
        {
            print("You have done 'D' quality work.");
			GameObject.Find ("GradeUI").GetComponent<Image> ().enabled = true;
			GameObject.Find ("GradeUI").GetComponent<Image> ().sprite = GradeD;
        }



    }
}
