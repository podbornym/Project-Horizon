using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpotTheDiffManager : MonoBehaviour
{
    public static float seconds;
    public float penaltyTime = NotADiff.penaltyTime;
    public int totalDiff;
    public static int foundDiff;
    public static bool foundAll = false;
    public Text howManyFound;
    public static Text timeCounter;
    public List<GameObject> possibleList;

    // Use this for initialization
    void Start()
    {
        seconds = 60;
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
            int numRandom = Random.Range(1, possibleList.Count);
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
            seconds = 0;
            timeCounter.text = "Time's up!";
            timeCounter.color = Color.red;
        }

        // Acknowledge when the player finds every difference
        if (foundDiff == 5)
        {
            foundAll = true;
            timeCounter.text = "You win!";
            penaltyTime = -1;
            timeCounter.color = Color.white;
        }

    }

    public void AddDifference(int value)
    {
        foundDiff = value;
    }
}
