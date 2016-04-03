using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mastermind : MonoBehaviour {
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text answer5;
    public Text answer6;
    public Text timer;
    public Text correctText;
    public Text finalText;
    public bool allAnswered = false;
    public static float seconds;
    public static float correctTime = -1;
    public static float penaltyTime = -1;
    public static bool correct = false;
    public static string artStyle = "names";
    public static int paintingNo = 1;
    public static int questionNo = 1;
    public static GameObject correctButton;

    // Use this for initialization
    void Start () {
        // start with one minute, we'll see how it works from there
        seconds = 60;
        //correctText.FindObject<CorrectText>.GetComponent<>();

    }
	
	// Update is called once per frame
	void Update () {
        // Update the timer
        seconds -= Time.deltaTime;
        timer.text = seconds.ToString("0");

        // Stop the timer when it reaches 0 and finish
        if (seconds <= 0 && !allAnswered)
        {
            seconds = 0;
            penaltyTime = -1;
            correctText.text = "";
            timer.text = "Time's up!";
            timer.color = Color.red;

            if (!allAnswered)
            {
                AllDone();
            }
        }

        // Acknowledge when the player answers all the questions in time
        if (allAnswered)
        {
            timer.text = "All done!";
            timer.color = Color.black;
            penaltyTime = -1;
        }

        // After clicking an answer, wait half a second
        // Then remove the "in/correct" text and go to the next question, if correct
        if (correctTime != -1 && correctTime - seconds >= 0.5)
        {
            correctText.text = "";
            if (correct)
            {
                NextQuestion();
                correct = false;
            }
        }

        // After a penalty, wait half a second before changing the timer's color back to black
        if (penaltyTime != -1 && penaltyTime - seconds >= 0.5)
        {
            timer.color = Color.black;
        }

        // set question
        // set answers for each question
        // each question will relate to the piece the player is currently completing
        // need to be able to store/pull that data, and then show correct data
        // total of 4 questions
        // every correct button pressed by the player will remove one button for the next question, eventually you will be left with 3 buttons
        // each button will possess a right or wrong bool, so the OnClick is easier

        // can probably be done through ButtonPress script
        // loop through, and set for each question??

        if (seconds > 0 && !allAnswered)
        {
            if (artStyle == "names")
            {
                if (paintingNo == 1)
                {
                    if (questionNo == 1)
                    {
                        question.text = "Question 1: What is my name?";
                        answer1.text = "Matt";
                        answer2.text = "Matthew";
                        answer3.text = "Matty";
                        answer4.text = "Mattleship";
                        answer5.text = "Podman";
                        answer6.text = "Pods";
                        SetCorrectAnswer(2);
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Question 2: What is my quest?";
                        answer1.text = "To seek the Holy Grail";
                        answer2.text = "To slay the Ender Dragon";
                        answer3.text = "To become a Pokemon master";
                        answer4.text = "To save the princess";
                        answer5.text = "To defeat Handsome Jack";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(1);
                    }
                    if (questionNo == 3)
                    {
                        question.text = "Question 3: What is the capital of Assyria?";
                        answer1.text = "Baghdad";
                        answer2.text = "Al Basrah";
                        answer3.text = "Samarra";
                        answer4.text = "***Assur***";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4);
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Question 4: What is the air-speed velocity of an unladen swallow?";
                        answer1.text = "As fast as it wants to go";
                        answer2.text = "Depends on the wind resistance";
                        answer3.text = "Wait, African or European?";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(3);
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }
            }
        }

        // obtain level information
        // if level = baroque
            // if painting = 1
                // set question1, answers
                // set question2, answers-1
                // set question3, answers-2
                // set question4, answers-3
            // if painting = 2
                // set question1, answers
                // set question2, answers-1
                // set question3, answers-2
                // set question4, answers-3
            // if painting = 3
            // if painting = 4
            // if painting = 5
            // if painting = 6

        // if level = ukiyo-e
            // if painting = 1
            // if painting = 2
            // if painting = 3
            // if painting = 4
            // if painting = 5
            // if painting = 6

        // if level = surrealism
            // if painting = 1
            // if painting = 2
            // if painting = 3
            // if painting = 4
            // if painting = 5
            // if painting = 6
	
	}

    void SetCorrectAnswer(int i)
    {
        // set the correct answer to a specific button
        correctButton = GameObject.Find("Answer" + i);
        correctButton.GetComponent<ButtonPress>().isCorrect = true;
    }


    public void IsCorrect(int i)
    {
        // determine question, determine clicked button
        // if correct, go onto next question (called in Update() )
        // if wrong, reduce timer (also called in Update() )
        if (seconds > 0)
        {
            correctButton = GameObject.Find("Answer" + i);
            if (correctButton.GetComponent<ButtonPress>().isCorrect)
            {
                // Clicked the right answer
                correctText.text = "Correct!";
                correctText.color = Color.green;
                correct = true;
            }
            else
            {
                // Clicked a wrong answer
                correctText.text = "Incorrect!";
                correctText.color = Color.red;

                if (seconds > 0)
                {
                    seconds--;

                    // Change the timer's color to red upon getting a penalty
                    timer.color = Color.red;
                    penaltyTime = seconds;
                }
            }
            correctTime = seconds;
        }
    }

    public static void NextQuestion()
    {
        // use to show the next questions, remove the one correct answer
        // if last question, show score, then next scene?

        // reset all questions to false
        for (int i = 1; i < 7 - questionNo; i++)
        {
            correctButton = GameObject.Find("Answer" + i);
            correctButton.GetComponent<ButtonPress>().isCorrect = false;
        }

        // go to the next question
        questionNo++;
    }

    void AllDone()//bool allAnswered)
    {
        
        
        /*// If the quiz was finished in time
        if (allAnswered)
        {
            timer.text = "All done!";
        }
        // If time ran out before the quiz was finished
        else
        {
            penaltyTime = -1;
            correctTime = -1;
            correctText.text = "";
            timer.text = "Time's up!";
        }*/
        finalText.text = "You got " + (questionNo - 1) + " out of 4 questions right!";

        // Remove the other elements
        question.text = "";
        GameObject.Destroy(GameObject.Find("Answer1"));
        GameObject.Destroy(GameObject.Find("Answer2"));
        GameObject.Destroy(GameObject.Find("Answer3"));
        if (questionNo < 4)
        {
            GameObject.Destroy(GameObject.Find("Answer4"));
            if (questionNo < 3)
            {
                GameObject.Destroy(GameObject.Find("Answer5"));
                if (questionNo < 2)
                {
                    GameObject.Destroy(GameObject.Find("Answer6"));
                }
            }
        }
    }
}
