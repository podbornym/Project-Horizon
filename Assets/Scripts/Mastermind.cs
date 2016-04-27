using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Mastermind : MonoBehaviour
{
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text answer5;
    public Text answer6;
    public Text timer;
    public Text correctText;
    public int hiddenScore = 10;
    public static int masterReturn;
    public bool allAnswered = false;
    public float seconds;
    public float correctTime = -1;
    public float penaltyTime = -1;
    public bool correct = false;
    public string artStyle;
    public int paintingNo;
    public int questionNo;
    public GameObject correctButton;
    public Sprite gradeA;
    public Sprite gradeB;
    public Sprite gradeC;
    public Sprite gradeD;

    public Sprite backgroundZ1_1;
    public Sprite backgroundZ1_2;
    public Sprite backgroundZ1_3;
    public Sprite backgroundZ1_4;
    public Sprite backgroundZ1_5;
    public Sprite backgroundZ1_6;
    public Sprite imageZ1_1;
    public Sprite imageZ1_2;
    public Sprite imageZ1_3;
    public Sprite imageZ1_4;
    public Sprite imageZ1_5;
    public Sprite imageZ1_6;

    public Sprite backgroundZ2_1;
    public Sprite backgroundZ2_2;
    public Sprite backgroundZ2_3;
    public Sprite backgroundZ2_4;
    public Sprite backgroundZ2_5;
    public Sprite backgroundZ2_6;
    public Sprite imageZ2_1;
    public Sprite imageZ2_2;
    public Sprite imageZ2_3;
    public Sprite imageZ2_4;
    public Sprite imageZ2_5;
    public Sprite imageZ2_6;

    public Sprite backgroundZ3_1;
    public Sprite backgroundZ3_2;
    public Sprite backgroundZ3_3;
    public Sprite backgroundZ3_4;
    public Sprite backgroundZ3_5;
    public Sprite backgroundZ3_6;
    public Sprite imageZ3_1;
    public Sprite imageZ3_2;
    public Sprite imageZ3_3;
    public Sprite imageZ3_4;
    public Sprite imageZ3_5;
    public Sprite imageZ3_6;

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("GENERALUI"))
        {
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
        }
        // start with one minute, we'll see how it works from there
        seconds = 60;
        //correctText.FindObject<CorrectText>.GetComponent<>();

    }

    // Update is called once per frame
    void Update()
    {
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
            timer.color = Color.white;
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

        // After a penalty, wait half a second before changing the timer's color back to white
        if (penaltyTime != -1 && penaltyTime - seconds >= 0.5)
        {
            timer.color = Color.white;
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
            if (PersistVars.Ukiyo)
            {
                if (PersistVars.paintingNum == 1) // Three Beauties of the Present Day
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ1_1;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ1_1;
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

                if (PersistVars.paintingNum == 2) // Waitress at an Inn at Akasaka
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ1_2;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ1_2;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Street Scene in Yoshiwara";
                        answer2.text = "Lobby of a Brothel";
                        answer3.text = "Women Dressmaking and Artesans at Work";
                        answer4.text = "A Banquet in a Joroya";
                        answer5.text = "Gardens and Pavilions of Pleasure";
                        answer6.text = "Waitress at an Inn at Akasaka";
                        SetCorrectAnswer(6); // Answer: Waitress at an Inn at Akasaka
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

                if (PersistVars.paintingNum == 3) // The Great Wave off Kanagawa
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ1_3;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ1_3;
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
                        SetCorrectAnswer(4); // Answer: Thirty-six Views of Mount Fuji
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Why were several woodblocks needed to print this piece?";
                        answer1.text = "Hokusai spent years on it before settling on the final design";
                        answer2.text = "The blocks wore down over time";
                        answer3.text = "Different blocks provided different colors";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(3); // Answer: Different blocks provided different colors
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 4) // Shoki Striding
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ1_4;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ1_4;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Actor as Wakanoura Osana Komachi";
                        answer2.text = "Shöki The Devil Queller";
                        answer3.text = "Actor Hayakawa Hatsuse";
                        answer4.text = "Shoki Striding";
                        answer5.text = "The Spring Pony Dance";
                        answer6.text = "Yaoya Oshichi";
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

                if (PersistVars.paintingNum == 5) // Sudden Shower over Shin-Ōhashi Bridge and Atake
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ1_5;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ1_5;
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
                        SetCorrectAnswer(2); // Answer: The gradual darkening of the sky and water
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 6) // Otani Oniji III as Yakko Edobei
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ1_6;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ1_6;
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
            }

            if (PersistVars.Surreal)
            {
                if (PersistVars.paintingNum == 1) // Tristan and Isolde
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ2_1;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ2_1;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Tristan and Isolde";
                        answer2.text = "Desecration Descripti";
                        answer3.text = "Madrid. Drunk Man";
                        answer4.text = "The Persistence of Memory";
                        answer5.text = "Playing in the Dark";
                        answer6.text = "Cabaret Scene";
                        SetCorrectAnswer(1); // Answer: Tristan and Isolde
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Frida Kahlo";
                        answer2.text = "Giorgio de Chirico";
                        answer3.text = "René Magritte";
                        answer4.text = "Yves Tanguy";
                        answer5.text = "Salvador Dalí";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(5); // Answer: Salvador Dalí
                    }
                    if (questionNo == 3)
                    {
                        question.text = "What material did Salvador Dalí use to make this piece?";
                        answer1.text = "Lead";
                        answer2.text = "Watercolors";
                        answer3.text = "Oil";
                        answer4.text = "Chalk";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(3); // Answer: Oil
                    }
                    if (questionNo == 4)
                    {
                        question.text = "How does this piece portray Richard Wagner's opera of the same name?";
                        answer1.text = "Serious";
                        answer2.text = "Satirical";
                        answer3.text = "Humorous";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: Satirical
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 2) // The Healer
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ2_2;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ2_2;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "The Son of Man";
                        answer2.text = "The Pilgrim";
                        answer3.text = "The Healer";
                        answer4.text = "Golconda";
                        answer5.text = "Peirreries";
                        answer6.text = "The Voice of the Air";
                        SetCorrectAnswer(3); // Answer: The Healer
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "René Magritte";
                        answer2.text = "Yves Tanguy";
                        answer3.text = "Frida Kahlo";
                        answer4.text = "Salvador Dalí";
                        answer5.text = "Max Ernst";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(1); // Answer: René Magritte
                    }
                    if (questionNo == 3)
                    {
                        question.text = "How did Magritte want viewers to react to the objects in his paintings?";
                        answer1.text = "To reconsider how they view the objects";
                        answer2.text = "To question whether the objects exist";
                        answer3.text = "To find the humor in their depictions";
                        answer4.text = "To regain their appreciation for the objects";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(1); // Answer: To reconsider how they view the objects
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Why did Magritte claim the objects shown were not the objects they appeared to be?";
                        answer1.text = "They were optical illusions";
                        answer2.text = "They were somehow inaccurate";
                        answer3.text = "They were simply images";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(3); // Answer: They were simply images
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 3) // The Slug Room
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ2_3;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ2_3;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "At the First Clear Word";
                        answer2.text = "Fruit of a Long Experience";
                        answer3.text = "Towers";
                        answer4.text = "The Slug Room";
                        answer5.text = "Cormorants";
                        answer6.text = "Hydrometric Demonstration";
                        SetCorrectAnswer(4); // Answer: The Slug Room
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Salvador Dalí";
                        answer2.text = "Max Ernst";
                        answer3.text = "Giorgio de Chirico";
                        answer4.text = "René Magritte";
                        answer5.text = "Yves Tanguy";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(2); // Answer: Max Ernst
                    }
                    if (questionNo == 3)
                    {
                        question.text = "The fast-drying paint used in 'The Slug Room' is known as what?";
                        answer1.text = "Collage";
                        answer2.text = "Gouache";
                        answer3.text = "Decalcomania";
                        answer4.text = "Tempera";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: Tempera
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Whose theories inspired Ernst to use his psyche as a source of inspiration?";
                        answer1.text = "Sigmund Freud";
                        answer2.text = "Lawrence Kohlberg";
                        answer3.text = "Erik Erikson";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: Sigmund Freud
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 4) // Turin Spring
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ2_4;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ2_4;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Piazza d'Italia";
                        answer2.text = "Turin Spring";
                        answer3.text = "Playthings of the Prince";
                        answer4.text = "The Anguish of Departure";
                        answer5.text = "The Enigma of the Arrival and the Afternoon";
                        answer6.text = "The Great Tower";
                        SetCorrectAnswer(2); // Answer: Turin Spring
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Max Ernst";
                        answer2.text = "Frida Kahlo";
                        answer3.text = "Yves Tanguy";
                        answer4.text = "Giorgio de Chirico";
                        answer5.text = "Salvador Dalí";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(4); // Answer: Giorgio de Chirico
                    }
                    if (questionNo == 3)
                    {
                        question.text = "What kind of feeling is achieved through De Chirico's use of towers and long shadows?";
                        answer1.text = "Serenity";
                        answer2.text = "Emptiness";
                        answer3.text = "Fear";
                        answer4.text = "Helplessness";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(2); // Answer: Emptiness
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Paradoxically, what is another feeling achieved through his works?";
                        answer1.text = "Freedom";
                        answer2.text = "Bravery";
                        answer3.text = "Kinship";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: Freedom
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 5) // Through Birds, Through Fire but Not Through Glass
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ2_5;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ2_5;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Finish What I Have Begun";
                        answer2.text = "Indefinite Divisibility";
                        answer3.text = "The Satin Tuning Fork";
                        answer4.text = "Mama, Papa is Wounded!";
                        answer5.text = "Through Birds, Through Fire but Not Through Glass";
                        answer6.text = "Time Without Change";
                        SetCorrectAnswer(5); // Answer: Through Birds, Through Fire but Not Through Glass 
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Yves Tanguy";
                        answer2.text = "René Magritte";
                        answer3.text = "Giorgio de Chirico";
                        answer4.text = "Max Ernst";
                        answer5.text = "Frida Kahlo";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(1); // Answer: Yves Tanguy
                    }
                    if (questionNo == 3)
                    {
                        question.text = "How did Tanguy's works from his American period differ from his others?";
                        answer1.text = "Less variety of objects";
                        answer2.text = "More surreal figures";
                        answer3.text = "Less detailed backgrounds";
                        answer4.text = "More vibrant colors";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: More vibrant colors
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Tanguy's technique of painting from his subconsciousness is known as what?";
                        answer1.text = "Improvisational drawing";
                        answer2.text = "Automatic drawing";
                        answer3.text = "Imagination drawing";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: Automatic drawing
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 6) // My Dress Hangs There
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ2_6;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ2_6;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Tree of Hope Remain Strong";
                        answer2.text = "What the Water Gave Me";
                        answer3.text = "My Dress Hangs There";
                        answer4.text = "Self Portrait along the Boarder Line";
                        answer5.text = "Roots";
                        answer6.text = "Without Hope";
                        SetCorrectAnswer(3); // Answer: My Dress Hangs There
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Giorgio de Chirico";
                        answer2.text = "Salvador Dalí";
                        answer3.text = "Frida Kahlo";
                        answer4.text = "Max Ernst";
                        answer5.text = "René Magritte";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(3); // Answer: Frida Kahlo
                    }
                    if (questionNo == 3)
                    {
                        question.text = "What makes 'My Dress Hangs There' particularly unusual among Kahlo's work?";
                        answer1.text = "It reflects her personal opinion";
                        answer2.text = "It's not a self-portrait";
                        answer3.text = "It depicts a cityscape";
                        answer4.text = "It doesn't have any animals";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(2); // Answer: It's not a self-portrait
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Which of these is NOT a representation of Kahlo's dissatisfaction with America?";
                        answer1.text = "The barely-noticeable Statue of Liberty";
                        answer2.text = "The toilet bowl on top of the column";
                        answer3.text = "The dollar sign in the church window";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: The barely-noticeable Statue of Liberty
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }
            }

            if (PersistVars.Baroque)
            {
                if (PersistVars.paintingNum == 1) // The Three Trees
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ3_1;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ3_1;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "The Windmill";
                        answer2.text = "Cottage among Trees";
                        answer3.text = "Landscape with a Stone Bridge";
                        answer4.text = "The Three Crosses";
                        answer5.text = "The Three Trees";
                        answer6.text = "The Landscape with Good Samaritan";
                        SetCorrectAnswer(5); // Answer: The Three Trees
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Maria van Oosterwijck";
                        answer2.text = "Rembrandt Harmenszoon van Rijn";
                        answer3.text = "Caravaggio";
                        answer4.text = "Gian Lorenzo Bernini";
                        answer5.text = "Cornelis Norbertus Gysbrechts";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(2); // Answer: Rembrandt Harmenszoon van Rijn
                    }
                    if (questionNo == 3)
                    {
                        question.text = "Which of these parts of the landscape does not contain human figures?";
                        answer1.text = "The riverbed";
                        answer2.text = "The fields";
                        answer3.text = "The horizon";
                        answer4.text = "The treetops";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: The treetops
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Which of the techniques used to make 'The Three Trees' creates soft, fuzzy lines?";
                        answer1.text = "Engraving";
                        answer2.text = "Drypoint";
                        answer3.text = "Etching";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: Drypoint
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 2) // Board Partition with Letter Rack and Music Book
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ3_2;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ3_2;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Letter Rack with a Kit and Pistol";
                        answer2.text = "Studio Wall with Vanitas Still Life";
                        answer3.text = "Quodlibet";
                        answer4.text = "Reverse Side of a Painting, Notes Multiplied";
                        answer5.text = "A Cabinet in the Artist's Studio";
                        answer6.text = "Board Partition with Letter Rack and Music Book";
                        SetCorrectAnswer(6); // Answer: Board Partition with Letter Rack and Music Book
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Caravaggio";
                        answer2.text = "Rembrandt Harmenszoon van Rijn";
                        answer3.text = "Gian Lorenzo Bernini";
                        answer4.text = "Cornelis Norbertus Gysbrechts";
                        answer5.text = "Maria van Oosterwijck";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(4); // Answer: Cornelis Norbertus Gysbrechts
                    }
                    if (questionNo == 3)
                    {
                        question.text = "'Board Partition' uses trompe-l'œil, a technique that gives the optical illusion of what?";
                        answer1.text = "Movement";
                        answer2.text = "3D objects";
                        answer3.text = "Hidden images";
                        answer4.text = "False colors";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(2); // Answer: 3D objects
                    }
                    if (questionNo == 4)
                    {
                        question.text = "What is included in letter board paintings to make them an alternative to portraits?";
                        answer1.text = "Personalized objects";
                        answer2.text = "Biographical references";
                        answer3.text = "Hidden faces";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: Personalized objects
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 3) // The Entombment of Christ
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ3_3;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ3_3;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "The Entombment of Christ";
                        answer2.text = "The Taking of Christ";
                        answer3.text = "The Flagellation of Christ";
                        answer4.text = "The Denial of Saint Peter";
                        answer5.text = "Martyrdom of Saint Matthew";
                        answer6.text = "Death of the Virgin";
                        SetCorrectAnswer(1); // Answer: The Entombment of Christ
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Cornelis Norbertus Gysbrechts";
                        answer2.text = "Caravaggio";
                        answer3.text = "Maria van Oosterwijck";
                        answer4.text = "Gian Lorenzo Bernini";
                        answer5.text = "Rembrandt Harmenszoon van Rijn";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(2); // Answer: Caravaggio
                    }
                    if (questionNo == 3)
                    {
                        question.text = "The figures in 'The Entombment of Christ' are arranged in what composition?";
                        answer1.text = "Triangle";
                        answer2.text = "Circle";
                        answer3.text = "Diagonal line";
                        answer4.text = "X";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(3); // Answer: Diagonal line
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Which of the three women is the Virgin Mary?";
                        answer1.text = "On the left, holding her hand above John";
                        answer2.text = "In the middle, drying her face with a handkerchief";
                        answer3.text = "On the right, raising her arms in hysteria";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(1); // Answer: On the left, holding her hand above John
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 4) // Bouquet of Flowers in a Glass
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ3_4;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ3_4;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Roses and Butterfly";
                        answer2.text = "Flower Still Life";
                        answer3.text = "Bouquet of Flowers in a Glass";
                        answer4.text = "Flowers, Fruit and Insects";
                        answer5.text = "Vanitas-Still Life";
                        answer6.text = "Still Life with Flowers, Insects and a Shell";
                        SetCorrectAnswer(3); // Answer: Bouquet of Flowers in a Glass
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Gian Lorenzo Bernini";
                        answer2.text = "Cornelis Norbertus Gysbrechts";
                        answer3.text = "Rembrandt Harmenszoon van Rijn";
                        answer4.text = "Caravaggio";
                        answer5.text = "Maria van Oosterwijck";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(5); // Answer: Maria van Oosterwijck
                    }
                    if (questionNo == 3)
                    {
                        question.text = "The strong contrast between light and dark is a style called what?";
                        answer1.text = "Sfumato";
                        answer2.text = "Unione";
                        answer3.text = "Cangiante";
                        answer4.text = "Chiaroscuro";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: Chiaroscuro
                    }
                    if (questionNo == 4)
                    {
                        question.text = "What butterfly appears in this and many of Oosterwijck's works?";
                        answer1.text = "Painted Lady";
                        answer2.text = "Red Admiral";
                        answer3.text = "Kamehameha";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: Red Admiral
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 5) // Christ Preaching
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ3_5;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ3_5;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Christ Presented to the People";
                        answer2.text = "Descent from the Cross";
                        answer3.text = "Christ Preaching";
                        answer4.text = "Christ Healing the Sick";
                        answer5.text = "The Prodigal Son in the Tavern";
                        answer6.text = "Saul and David";
                        SetCorrectAnswer(3); // Answer: Christ Preaching
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Rembrandt Harmenszoon van Rijn";
                        answer2.text = "Maria van Oosterwijck";
                        answer3.text = "Caravaggio";
                        answer4.text = "Cornelis Norbertus Gysbrechts";
                        answer5.text = "Gian Lorenzo Bernini";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(1); // Answer: Rembrandt Harmenszoon van Rijn
                    }
                    if (questionNo == 3)
                    {
                        question.text = "Which event from Christ's ministry does this scene depict?";
                        answer1.text = "Forgiving the adulteress";
                        answer2.text = "Blessing the children";
                        answer3.text = "Reappearing to his disciples";
                        answer4.text = "No event in particular";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(4); // Answer: No event in particular
                    }
                    if (questionNo == 4)
                    {
                        question.text = "This piece's alternate name, 'La Petite Tombe,' refers to which figure?";
                        answer1.text = "The woman seated next to Christ";
                        answer2.text = "The boy lying on the ground";
                        answer3.text = "The man in the foreground";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(2); // Answer: The boy lying on the ground
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
                    }
                }

                if (PersistVars.paintingNum == 6) // The Rape of Persephone
                {
                    GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundZ3_6;
                    GameObject.Find("CurrentPiece").GetComponent<SpriteRenderer>().sprite = imageZ3_6;
                    if (questionNo == 1)
                    {
                        question.text = "What is the name of this piece?";
                        answer1.text = "Neptune and Triton";
                        answer2.text = "Apollo and Daphne";
                        answer3.text = "Ecstasy of Saint Teresa";
                        answer4.text = "Angel with the Crown of Thorns";
                        answer5.text = "The Rape of Persephone";
                        answer6.text = "The Vision of Constantine";
                        SetCorrectAnswer(5); // Answer: The Rape of Persephone
                    }
                    if (questionNo == 2)
                    {
                        question.text = "Who created this piece?";
                        answer1.text = "Rembrandt Harmenszoon van Rijn";
                        answer2.text = "Cornelis Norbertus Gysbrechts";
                        answer3.text = "Gian Lorenzo Bernini";
                        answer4.text = "Caravaggio";
                        answer5.text = "Maria van Oosterwijck";
                        GameObject.Destroy(GameObject.Find("Answer6"));
                        SetCorrectAnswer(3); // Answer: Gian Lorenzo Bernini
                    }
                    if (questionNo == 3)
                    {
                        question.text = "What material is the statue made of?";
                        answer1.text = "Marble";
                        answer2.text = "Granite";
                        answer3.text = "Sandstone";
                        answer4.text = "Slate";
                        GameObject.Destroy(GameObject.Find("Answer5"));
                        SetCorrectAnswer(1); // Answer: Marble
                    }
                    if (questionNo == 4)
                    {
                        question.text = "Who is the man kidnapping Persephone as depicted in the statue?";
                        answer1.text = "Zeus";
                        answer2.text = "Poseidon";
                        answer3.text = "Hades";
                        GameObject.Destroy(GameObject.Find("Answer4"));
                        SetCorrectAnswer(3); // Answer: Hades
                    }
                    if (questionNo >= 5)
                    {
                        allAnswered = true;
                        AllDone();
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
    }

    public void SetCorrectAnswer(int i)
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
                correctText.text = "O";
                correctText.color = Color.green;
                correct = true;
            }
            else
            {
                // Clicked a wrong answer
                correctText.text = "X";
                correctText.color = Color.red;

                //Subtract 1 from the player's overall score
                hiddenScore -= 1;

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

    public void NextQuestion()
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

    public void HelpButton()
    {
        // Toggle the help information on and off
        GameObject.Find("HelpUI").GetComponent<Image>().enabled = !GameObject.Find("HelpUI").GetComponent<Image>().enabled;
    }

    void AllDone()//bool allAnswered)
    {
        // Penalize the player if time ran out
        if (seconds <= 0)
        {
            hiddenScore -= 3;
        }

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

        GameObject.Find("ContinueButton").GetComponent<Button>().interactable = true;
        GameObject.Find("ResetButton").GetComponent<Button>().interactable = true;

        // Grade the player based on their hidden score
        // Scored 8, 9, or 10: grade A
        if (hiddenScore >= 8 && hiddenScore <= 10)
        {
            GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
            GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeA;
        }
        // Scored 6 or 7: grade B
        else if (hiddenScore >= 6 && hiddenScore <= 7)
        {
            GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
            GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeB;
        }
        // Scored 3, 4, or 5: grade C
        else if (hiddenScore >= 3 && hiddenScore <= 5)
        {
            GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
            GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeC;
        }
        // Scored 0, 1, or 2: grade D
        else if (hiddenScore <= 2)
        {
            GameObject.Find("GradeUI").GetComponent<Image>().enabled = true;
            GameObject.Find("GradeUI").GetComponent<Image>().sprite = gradeD;
        }
        masterReturn = hiddenScore * 10;
        if (masterReturn < 0)
        {
            masterReturn = 0;
        }
    }

    // Use this function to find the gameObject with the PersistentVars script, and get the previousScene component
    public void NextLevel()
    {
        if (PersistVars.previousScene != "null")
        {
            GameObject.Find("GENERALUI").GetComponent<PersistVars>().mastermindScore = masterReturn;
            SceneManager.LoadScene(PersistVars.previousScene);
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
        }
    }
}
