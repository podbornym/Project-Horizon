﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpotTheDiffManager : MonoBehaviour
{
    public static float seconds;
    public float penaltyTime = NotADiff.penaltyTime;
    public int totalDiff;
    public static int foundDiff;
    public static bool foundAll = false;
    public Text howManyFound;
    public static Text timeCounter;
    public Text timeUp;
    public List<GameObject> possibleList;
    public static int findDiffReturn;
    public Sprite gradeA;
    public Sprite gradeB;
    public Sprite gradeC;
    public Sprite gradeD;

	AudioSource src;
	public int counter;

    // Use this for initialization
    void Start()
    {
		counter = 1;
		src = gameObject.AddComponent<AudioSource>();
        if (GameObject.Find("GENERALUI"))
        {
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
        }

        seconds = 90;
        // Get the UI text components
        howManyFound = GameObject.Find("FoundDiffText").GetComponent<Text>();
        timeCounter = GameObject.Find("TimerText").GetComponent<Text>();

        // Randomize which differences will appear
        // Create a list of 10 differences
        possibleList = new List<GameObject>(10);
        for (int i = 1; i < 11; i++)
        {
            possibleList.Add(GameObject.Find("Diff " + i));
        }
        // Create an array for 5 differences to keep
        GameObject[] diffArray = new GameObject[5];

        // Randomly select 5 of the 10 differences
        // Each difference will be added to the array
        // and removed from the list so it can't be picked twice
        for (int i = 0; i < diffArray.Length; i++)
        {
            int numRandom = Random.Range(0, possibleList.Count);
            diffArray[i] = GameObject.Find("Diff " + numRandom);
            possibleList.RemoveAt(numRandom);
        }
        // Remove the other 5 differences that weren't picked
        foreach (GameObject g in possibleList)
        {
            Destroy(g);
        }



        /*        List<int> numList = new List<int>(10);
                for (int i = 1; i < 11; i++)
                {
                    numList.Add(i);
                }
                // Create an array for 10 differences
                int[] diffArray = new int[5];

                // Randomly select 10 of the 20 integers
                // Each integer will be added to the array
                // and removed from the list so it can't be picked twice
                for (int j = 0; j < diffArray.Length; j++)
                {
                    int numRandom = Random.Range(1, numList.Count);
                    diffArray[j] = numList[numRandom];
                    numList.RemoveAt(numRandom);
                }

                //diff = GameObject.FindGameObjectsWithTag("difference").GetComponent();
                //diff = GameObject.FindGameObjectsWithTag("difference");
                //print(diff);
                // Remove all differences that weren't picked
                SpotTheDiff.NotPicked(diffArray);
                //NotPicked(diffArray);*/

    }

    // Update is called once per frame
    void Update()
    {
        if (foundDiff >= 1)
        {
            // Update how many differences have been found
            howManyFound.text = foundDiff.ToString();
        }

        // Count down 1 second
        seconds -= Time.deltaTime;
        timeCounter.text = seconds.ToString("0");

        // Stop the timer when it reaches 0
        if (seconds <= 0 && !foundAll)
        {
			/*if (counter == 1) 
			{
				src.clip = Resources.Load ("Sound/Mini-Game SFX/General/Game_Over_Music") as AudioClip;
				src.Play ();
				counter++;
				Debug.Log ("reached");
			}*/
            seconds = 0;
            timeCounter.text = "";
            timeUp.text = "Time's up!";
            timeUp.color = Color.red;
            FinalScore();
        }

        // Acknowledge when the player finds every difference
        if (foundDiff == 5)
        {
			/*if (counter == 1) 
			{
				src.clip = Resources.Load ("Sound/Mini-Game SFX/General/Game_Win_Music") as AudioClip;
				src.Play ();
				counter++;
			}*/
            foundAll = true;
            timeCounter.text = "";
            timeUp.text = "You win!";
            penaltyTime = -1;
            FinalScore();
        }

    }

    public void AddDifference(int value)
    {
        foundDiff = value;
    }

    public void HelpButton()
    {
        // Toggle the help information on and off
        GameObject.Find("HelpUI").GetComponent<Image>().enabled = !GameObject.Find("HelpUI").GetComponent<Image>().enabled;
    }

    public void FinalScore()
    {
		if (counter == 1 && foundAll) 
		{
			src.clip = Resources.Load ("Sound/Mini-Game SFX/General/Game_Win_Music") as AudioClip;
			src.Play ();
			counter++;
		} 
		else 
		{
			src.clip = Resources.Load ("Sound/Mini-Game SFX/General/Game_Over_Music") as AudioClip;
			src.Play ();
			counter++;
		}
        GameObject.Find("ContinueButton").GetComponent<Button>().interactable = true;
        GameObject.Find("ResetButton").GetComponent<Button>().interactable = true;

        // The player found all 5 mistakes
        if (foundAll)
        {
            // The player took less than a minute: score 100 / grade A
            if (seconds > 30)
            {
                GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeA;
                findDiffReturn = 100;
            }
            // The player took more than a minute: score 90 / grade A
            else
            {
                GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeA;
                findDiffReturn = 90;
            }
        }
        // The player ran out of time
        else
        {
            // Only 4 differences were found: score 80 / grade B
            if (foundDiff == 4)
            {
                GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeB;
                findDiffReturn = 80;
            }
            // Only 3 differences were found: score 70 / grade C
            else if (foundDiff == 3)
            {
                GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeC;
                findDiffReturn = 70;
            }
            // 2 or fewer differences were found: score 60 / grade D
            else if (foundDiff <= 2)
            {
                GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
                GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeD;
                findDiffReturn = 60;
            }
        }
    }

    // Use this function to find the gameObject with the PersistentVars script, and get the previousScene component
    public void NextLevel()
    {
        if (PersistVars.currentScene != "null")
        {
            GameObject.Find("GENERALUI").GetComponent<PersistVars>().findDiffScore = findDiffReturn;
            SceneManager.LoadScene(PersistVars.currentScene);
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
        }
    }
}
