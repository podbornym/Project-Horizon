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
    public static string artStyle = "ukiyo-e";
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
            if (artStyle == "ukiyo-e")
            {
                if (paintingNo == 1) // Shoki Striding
                {
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Actor as Wakanoura Osana Komachi";
                        answer2.text = "Morita-za";
                        answer3.text = "Shibai Uki-e";
                        answer4.text = "Shoki Striding";
                        answer5.text = "Taking the Evening Cool by Ryōgoku Bridge";
                        answer6.text = "A Roofer's Precariousness";
                        SetCorrectAnswer(4); // Answer: Shoki Striding
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Tōshūsai Sharaku";
                        answer2.text = "Kitagawa Utamaro";
                        answer3.text = "Utagawa Hiroshige";
                        answer4.text = "Hishikawa Moronobu";
                        answer5.text = "Okumura Masanobu";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(5); // Answer: Okumura Masanobu
                    }
                    if (questionNo == 3)
                    {
                        question.text = "'Shoki Striding' was printed on what paper size?";
                        answer1.text = "Narrow";
                        answer2.text = "Pillar print";
                        answer3.text = "Hanging scroll";
                        answer4.text = "Large poem card";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(2); // Answer: Pillar print
                    }
                    if (questionNo == 4)
                    {
                        question.text = "What sets apart Masanobu's style, urushi-e, from other woodblock prints?";
                        answer1.text = "Thick lines";
                        answer2.text = "Lack of color";
                        answer3.text = "Figures in motion";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: Thick lines
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (paintingNo == 2) // Otani Oniji III as Yakko Edobei
                {
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Sakata Hangoro III as the villain Fujikawa Mizuemon";
                        answer2.text = "Segawa Kikujurō III as Oshizu, Wife of Tanabe";
                        answer3.text = "Ishikawa Ebizo IV as Takemura Sadanoshin";
                        answer4.text = "Sawamura Sōjurō III as Ogishi Kurando";
                        answer5.text = "Otani Oniji III as Yakko Edobei";
                        answer6.text = "Ichikawa Yaozo III as Tanabe Bunzo";
                        SetCorrectAnswer(5); // Answer: Otani Oniji III as Yakko Edobei
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Hishikawa Moronobu";
                        answer2.text = "Katsushika Hokusai";
                        answer3.text = "Kitagawa Utamaro";
                        answer4.text = "Utagawa Hiroshige";
                        answer5.text = "Tōshūsai Sharaku";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(5); // Answer: Tōshūsai Sharaku
                    }
                    if (questionNo == 3)
                    {
                        question.text = "The polychrome woodblock printing style that Sharaku used was known as what?";
                        answer1.text = "Urushi-e";
                        answer2.text = "Shini-e";
                        answer3.text = "Aizuri-e";
                        answer4.text = "Nishiki-e";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: Nishiki-e
                    }
                    if (questionNo == 4)
                    {
                        question.text = "What aspect did Sharaku focus on in his protraits?";
                        answer1.text = "Beauty";
                        answer2.text = "Energy";
                        answer3.text = "Truth";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: Energy
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (paintingNo == 3) // The Great Wave off Kanagawa
                {
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "The Great Wave off Kanagawa";
                        answer2.text = "Below Meguro";
                        answer3.text = "Shore of Tago Bay, Ejiri at Tōkaidō";
                        answer4.text = "South Wind, Clear Sky";
                        answer5.text = "Lake Suwa in Shinano Province";
                        answer6.text = "Bay of Noboto";
                        SetCorrectAnswer(1); // Answer: The Great Wave off Kanagawa
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Utagawa Hiroshige";
                        answer2.text = "Hishikawa Moronobu";
                        answer3.text = "Katsushika Hokusai";
                        answer4.text = "Okumura Masanobu";
                        answer5.text = "Tōshūsai Sharaku";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(3); // Answer: Katsushika Hokusai
                    }
                    if (questionNo == 3)
                    {
                        question.text = "'The Great Wave off Kanagawa' is the first of a print series called what?";
                        answer1.text = "Oceans of Wisdom";
                        answer2.text = "A Tour of the Waterfalls of the Provinces";
                        answer3.text = "One Hundred Views of Mount Fuji";
                        answer4.text = "Thirty-six Views of Mount Fuji";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: 
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Why were several woodblocks needed to print this piece?";
                        answer1.text = "Hokusair spent years on it before settling on the final design";
                        answer2.text = "The blocks wore down over time";
                        answer3.text = "Different blocks provided different colors";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(3); // Answer: Thirty-six Views of Mount Fuji
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (paintingNo == 4) // Three Beauties of the Present Day
                {
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Famous Beauties of Edo";
                        answer2.text = "Hairdresser";
                        answer3.text = "Three Beauties of the Present Day";
                        answer4.text = "Three Beauties Holding Bags of Snacks";
                        answer5.text = "An Array of Passionate Lovers";
                        answer6.text = "Stylish Amusements of the Four Seasons";
                        SetCorrectAnswer(3); // Answer: Three Beauties of the Present Day
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Tōshūsai Sharaku";
                        answer2.text = "Kitagawa Utamaro";
                        answer3.text = "Katsushika Hokusai";
                        answer4.text = "Utagawa Hiroshige";
                        answer5.text = "Okumura Masanobu";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(2); // Answer: Kitagawa Utamaro
                    }
                    if (questionNo == 3)
                    {
                        question.text = "What do the three women have that identifies who they are?";
                        answer1.text = "Unique clothing";
                        answer2.text = "Fashionable hairstyles";
                        answer3.text = "Different facial features";
                        answer4.text = "Family crests";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: Family crests
                    }
                    if (questionNo == 4)
                    {
                        question.text = "What aspect is represented by the triangle composition of the women?";
                        answer1.text = "Unity";
                        answer2.text = "Beauty";
                        answer3.text = "Fame";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: Unity
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (paintingNo == 5) // Lobby of a Brothel
                {
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Street Scene in Yoshiwara";
                        answer2.text = "Viewing Cherry Blossoms in Ueno";
                        answer3.text = "Women Dressmaking and Artesans at Work";
                        answer4.text = "A Banquet in a Joroya";
                        answer5.text = "Gardens and Pavilions of Pleasure";
                        answer6.text = "Lobby of a Brothel";
                        SetCorrectAnswer(6); // Answer: Lobby of a Brothel
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Katsushika Hokusai";
                        answer2.text = "Okumura Masanobu";
                        answer3.text = "Hishikawa Moronobu";
                        answer4.text = "Kitagawa Utamaro";
                        answer5.text = "Tōshūsai Sharaku";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(3); // Answer: Hishikawa Moronobu
                    }
                    if (questionNo == 3)
                    {
                        question.text = "Why did Moronobu reproduce his art with woodblock prints?";
                        answer1.text = "To prevent his work from being stolen";
                        answer2.text = "To make changes and revisions";
                        answer3.text = "To share his ideas with other artists";
                        answer4.text = "To make it more available to the public";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: To make it more available to the public
                    }
                    if (questionNo == 4)
                    {
                        question.text = "What aspect of Moronobu's art had the most influence on other ukiyo-e artists?";
                        answer1.text = "Contrasting black and white areas";
                        answer2.text = "A strong, linear style";
                        answer3.text = "Scenes of urban life";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: A strong, linear style
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (paintingNo == 6) // Sudden Shower
                {
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Suidō Bridge and the Surugadai Quarter";
                        answer2.text = "Sudden Shower over Shin-Ōhashi Bridge and Atake";
                        answer3.text = "Sumida River, the Wood of the Water God";
                        answer4.text = "Rain Shower at Shōno";
                        answer5.text = "Futami Bay in Ise Province";
                        answer6.text = "View of a Long Bridge Across a Lake";
                        SetCorrectAnswer(2); // Answer: Sudden Shower over Shin-Ōhashi Bridge and Atake
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Kitagawa Utamaro";
                        answer2.text = "Okumura Masanobu";
                        answer3.text = "Hishikawa Moronobu";
                        answer4.text = "Katsushika Hokusai";
                        answer5.text = "Utagawa Hiroshige";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(5); // Answer: Utagawa Hiroshige
                    }
                    if (questionNo == 3)
                    {
                        question.text = "'Sudden Shower over Shin-Ōhashi Bridge and Atake' is part of a print series called what?";
                        answer1.text = "Thirty-six Views of Mount Fuji";
                        answer2.text = "The Fifty-three Stations of the Tōkaidō";
                        answer3.text = "One Hundred Famous Views of Edo";
                        answer4.text = "Famous Views of the Sixty-odd Provinces";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(3); // Answer: One Hundred Famous Views of Edo
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Hiroshige used the bokashi technique in this piece to achieve what?";
                        answer1.text = "The parallel rain drops";
                        answer2.text = "The gradual darkening of the sky and water";
                        answer3.text = "The diagonal positioning of elements";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: Bokashi
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
