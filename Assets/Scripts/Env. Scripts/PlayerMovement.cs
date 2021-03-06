﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private static Vector3 moveToPos;
    private static Vector3 landingPos;
    private static GameObject landing = null;
    private static float offset;
    private static float camOffset;
    public bool moving = false;
    GameObject landingPair = null;
    int columnOffset = 0;
    public GameObject cam;
    public Texture2D normalCursor;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = new Vector2(30, 30);
    public static bool cursorSet = false;
    private Animator myAnimator;
    public MovieTexture openCinematic;
    private AudioSource openAudio;
    public int Move;
	public GameObject player;
	public AudioClip movement;
	public AudioClip interact;

    //use for stairs cam shtuff
    public bool approachLeft = true;

    // Use this for initialization
    void Start()
    {
		player = GameObject.Find("Player");
        if (!cursorSet)
        {
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
            cursorSet = true;
        }



        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;

        if (PersistVars.currentScene == "mansion")
        {
            if (!PersistVars.returningToHome)
            {
                gameObject.transform.position = GameObject.Find("introSpawn").transform.position;
                cam.transform.position = new Vector3(-51.4f, -1.42f, cam.transform.position.z);
                GameObject.Find("Art Piece").GetComponent<Text>().text = "No Current Painting";
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Mansion");

                // Prepare the opening cinematic to play the first time
                openAudio = GetComponent<AudioSource>();
                //openAudio.clip = openCinematic.audioClip;
                if (openCinematic != null)
                {
                    openCinematic.Play();
                    openAudio.Play();
                    Screen.fullScreen = true;
                }
            }
            else
            {
                gameObject.transform.position = GameObject.Find("hubSpawn").transform.position;
                cam.transform.position = new Vector3(-10.32f, -13f, cam.transform.position.z);
            }
        }

        myAnimator = GetComponent<Animator>();
    }

    void OnGUI()
    {
        // Play the opening cinematic
        if (openCinematic != null && openCinematic.isPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), openCinematic, ScaleMode.StretchToFill);
        }
    }

    void Update()
    {
        // Skip the opening cinematic upon pressing 'Escape'
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(openCinematic.isPlaying == true)
            {
                Screen.fullScreen = false;
                openCinematic.Stop();
                openAudio.Stop();
            }

            else
            {
                SceneManager.LoadScene("StartScene");
                GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
            }
        }
    }

    //both of these scripts are calling in the EnvInteracter Script when an object is clicked on, and then call moveStraight()
    public void MovePlayer(Vector3 target, GameObject start)
    {
        moveToPos = target;
        landing = start;
        moveStraight();
    }

    public void MovePlayer(Vector3 target, GameObject start, int offset)
    {
        moveToPos = target;
        landing = start;
        columnOffset = offset;
        moveStraight();
    }

    //moves the player to the object that was clicked on, and when the move to the target position is done this calls identifyLanding() to decide if the object clicked on was an object that
    //requires further interaction, such as stairs, doors, or curves
    //also sets boolean moving to true so that the player cannot click other objects while they are moving to an object
    void moveStraight()
    {
		player.GetComponent<AudioSource> ().PlayOneShot (movement, 1.0f);
        if (!moving)
        {
            if (gameObject.transform.position.x < moveToPos.x)
            {
                myAnimator.SetInteger("Move", -1);
            }
            else if (gameObject.transform.position.x > moveToPos.x)
            {
                myAnimator.SetInteger("Move", 1);
            }
            moving = true;
            iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(moveToPos.x + columnOffset, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "identifyLanding"));

        }
    }

    //moves the player and the camera up or down the stairs
    void moveStairs(bool ukiyo = false)
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        //checks for the stairs on the left side of the ukiyo-e map
        //if not on the left side, then do stairs as normal
        if (!ukiyo && (cam.transform.position.x != 11.59 && cam.transform.position.y != 2.7))
        {
            if (approachLeft)
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x - CameraScript.offsetInUse, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
            else
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x + CameraScript.offsetInUse, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
        }
        //else only move the cam up and down
        else
        {
            if (approachLeft)
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
            else
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
        }

    }

    //moves the player along a designated curve
    void moveCurve(string curveName, int speed)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(curveName), "speed", speed, "easetype", "linear", "oncomplete", "notMoving"));
    }

    //same as above, but moves backward along the curve
    void moveCurveReverse(string curveName, int speed)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPathReversed(curveName), "speed", speed, "easetype", "linear", "oncomplete", "notMoving"));
    }

    //moves the player downwards, as in using an elevator
    void moveElevator()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
    }

    //resets the vars that are needed during movement, lets the player click to move again, and resets the landing to null for the next click
    void notMoving()
    {

        moving = false;
        myAnimator.SetInteger("Move", 0);
        columnOffset = 0;
        landing = null;

        if (!gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    //This function takes the passed in landing object, if there is one, and performs necessary operations when the player arrives there
    //ie. move up the stairs after arriving at the base, or moving through a door after getting to it
    void identifyLanding()
    {
        if (landing != null)
        {
            offset = transform.position.y - moveToPos.y;
            camOffset = cam.transform.position.y - moveToPos.y;
            switch (landing.name)
            {
                //Mansion Options
                case "stairs1":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs();
                    break;
                case "stairs2":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs();
                    break;
                case "clock":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("chair");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveCurve("clockToChair", 10);
                    break;
                case "chair":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("clock");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveCurveReverse("clockToChair", 10);
                    break;
                case "elevTop":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("elevBot");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveElevator();
                    break;
                case "elevBot":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("elevTop");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveElevator();
                    break;
                case "Surrealism":
                    PersistVars.previousScene = "mansion";
                    PersistVars.currentScene = "SurrealistZone";
                    PersistVars.Surreal = true;
                    myAnimator.SetBool("PortalWalk", true);
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Surrealism Zone");
                    notMoving();
                    StartCoroutine(SurrealismPortalEnter());
                    break;
                case "Ukiyo-e":
                    PersistVars.previousScene = "mansion";
                    PersistVars.currentScene = "Ukiyo-eZone";
                    PersistVars.Ukiyo = true;
                    myAnimator.SetBool("PortalWalk", true);
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Ukiyo-E Zone");
                    notMoving();
                    StartCoroutine(UkiyoPortalEnter());
                    break;
                case "Baroque":
                    PersistVars.previousScene = "mansion";
                    PersistVars.currentScene = "BaroqueZone";
                    PersistVars.Baroque = true;
                    myAnimator.SetBool("PortalWalk", true);
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Baroque Zone");
                    notMoving();
                    StartCoroutine(BaroquePortalEnter());
                    break;
                case "portal_1":
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().PortalComingSoon();
                    notMoving();
                    break;
                case "portal_2":
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().PortalComingSoon();
                    notMoving();
                    break;
                case "portal_5":
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().PortalComingSoon();
                    notMoving();
                    break;
                //Surrealist options
                case "rightEdge":
                    myAnimator.SetInteger("Move", -1);
                    landingPair = GameObject.Find("leftEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(gameObject.transform.position.x + 5, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
                    cam.transform.position = new Vector3(landingPos.x + 10.25f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    myAnimator.SetInteger("Move", -1);
                    break;
                case "leftEdge":
                    myAnimator.SetInteger("Move", 1);
                    landingPair = GameObject.Find("rightEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(gameObject.transform.position.x - 5, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
                    cam.transform.position = new Vector3(landingPos.x - 10.25f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    myAnimator.SetInteger("Move", 1);
                    break;
                case "door_0S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_0";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 1");
                    StartCoroutine(doorZeroS());
                    notMoving();
                    break;
                case "door_1S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_1";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 2");
                    StartCoroutine(doorOneS());
                    notMoving();
                    break;
                case "door_2S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_2";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 3");
                    StartCoroutine(doorTwoS());
                    notMoving();
                    break;
                case "door_3S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_3";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 4");
                    notMoving();
                    StartCoroutine(doorThreeS());
                    break;
                case "door_4S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_4";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 5");
                    StartCoroutine(doorFourS());
                    notMoving();
                    break;
                case "door_5S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_5";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 6");
                    StartCoroutine(doorFiveS());
                    notMoving();
                    break;
                //Baroque options
                case "Bstairs1":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs3");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs();
                    break;
                case "Bstairs2":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs4");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs();
                    break;
                case "Bstairs3":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs();
                    break;
                case "Bstairs4":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs();
                    break;
                case "door_0B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_0";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 1");
                    notMoving();
                    SceneManager.LoadScene("B_0");
                    break;
                case "door_1B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_1";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 2");
                    notMoving();
                    SceneManager.LoadScene("B_1");
                    break;
                case "door_2B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_2";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 3");
                    notMoving();
                    SceneManager.LoadScene("B_2");
                    break;
                case "door_3B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_3";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 4");
                    notMoving();
                    SceneManager.LoadScene("B_3");
                    break;
                case "door_4B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_4";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 5");
                    notMoving();
                    SceneManager.LoadScene("B_4");
                    break;
                case "door_5B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_5";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 6");
                    notMoving();
                    SceneManager.LoadScene("B_5");
                    break;
                //Ukiyo-E options
                case "door_0U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_0";
                    notMoving();
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 1");
                    SceneManager.LoadScene("U_0");
                    break;
                case "door_1U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_1";
                    notMoving();
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 2");
                    SceneManager.LoadScene("U_1");
                    break;
                case "door_2U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_2";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 3");
                    notMoving();
                    SceneManager.LoadScene("U_2");
                    break;
                case "door_3U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_3";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 4");
                    notMoving();
                    SceneManager.LoadScene("U_3");
                    break;
                case "door_4U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_4";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 5");
                    notMoving();
                    SceneManager.LoadScene("U_4");
                    break;
                case "door_5U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_5";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 6");
                    notMoving();
                    SceneManager.LoadScene("U_5");
                    break;
                case "Ustairs1":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs3");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs(false);
                    break;
                case "Ustairs2":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs4");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs(true);
                    break;
                case "Ustairs3":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs(false);
                    break;
                case "Ustairs4":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs(true);
                    break;
                case "leftEndU":
                    myAnimator.SetInteger("Move", -1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("rightEndU");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveCurve("bridge", 10);
                    break;
                case "rightEndU":
                    myAnimator.SetInteger("Move", 1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("leftEndU");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveCurveReverse("bridge", 10);
                    break;
                default:
                    Debug.Log("did not access a name for a valid landing object");
                    break;
            }
        }
        else
        {
            notMoving();
        }
    }
    IEnumerator UkiyoPortalEnter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GENERALUI").GetComponent<AudioSource>().clip = null;
        SceneManager.LoadScene("Ukiyo-eZone");
    }
    IEnumerator BaroquePortalEnter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GENERALUI").GetComponent<AudioSource>().clip = null;
        SceneManager.LoadScene("BaroqueZone");
    }
    IEnumerator SurrealismPortalEnter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GENERALUI").GetComponent<AudioSource>().clip = null;
        SceneManager.LoadScene("SurrealistZone");
    }
    IEnumerator doorZeroS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_0");
    }
    IEnumerator doorOneS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_1");
    }
    IEnumerator doorTwoS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_2");
    }
    IEnumerator doorThreeS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_3");
    }
    IEnumerator doorFourS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_4");
    }
    IEnumerator doorFiveS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_5");
    }
}

//archived code
/*
// Update is called once per frame
void Update()
{
    if (mousePressed)
    {
        Vector2 xCoord = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 10);
        player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 10);
    }

    if (player.transform.position == transform.position)
    {
        SceneManager.LoadScene("UIScene1");
    }
}

void OnMouseDown()
{
    mousePressed = true;
}*/
/*while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
            yield return null;
            if (transform.position.x == landingPos.x)
            {
                break;
            }
        }
        moving = false;*/

/* while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveToPos.x, transform.position.y, transform.position.z), Time.deltaTime * 10);
            yield return null;
            if (transform.position.x == moveToPos.x)
            {
                if (landing != null)
                {
                    offset = transform.position.y - moveToPos.y;
                    switch (landing.name)
                    {
                        case "stairs1":
                            landingPos = GameObject.Find("stairs2").transform.position;
                            StartCoroutine(moveStairs());
                            break;
                        case "stairs2":
                            landingPos = GameObject.Find("stairs1").transform.position;
                            StartCoroutine(moveStairs());
                            break;
                        case "clock":
                            moveCurve("clockToChair", 10);
                            break;
                        case "chair":
                            moveCurveReverse("clockToChair", 10);
                            break;
                        default:
                            Debug.Log("did not access a name for a valid landing object");
                            break;
                    }
                }
                break;
            }
        }
        moving = false;*/


/*if(mousePressed)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveToPos.x, transform.position.y, transform.position.z), Time.deltaTime * 10);
        if(transform.position.x == moveToPos.x)
        {
            if (landing != null)
            {
                toLanding = true;
                offset = transform.position.y - moveToPos.y;
            }        
            //make mousePressed false so that you stop moving
            mousePressed = false;
        }
    }
    if(toLanding)
    {
        switch (landing.name)
        {
            case "stairs1":
                landingPos = GameObject.Find("stairs2").transform.position;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                break;
            case "stairs2":
                landingPos = GameObject.Find("stairs1").transform.position;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                break;
            case "clock":
                //landingPos = GameObject.Find("chair").transform.position;
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                //if 
                break;
            case "chair":
                landingPos = GameObject.Find("clock").transform.position;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                break;
            default:
                Debug.Log("did not access a name for a valid landing object");
                break;
        }
        if (transform.position.x == landingPos.x)
        {
            //after using landing to find the pair, set it to null again for next use
            landing = null;
            toLanding = false;
            mousePressed = false;
        }
    }*/
/*using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    private static Vector3 moveToPos;
    private static Vector3 landingPos;
    private static GameObject landing = null;
    private static float offset;
    private static float camOffset;
    public bool moving = false;
    GameObject landingPair = null;
    int columnOffset = 0;
    public GameObject cam;
    public Texture2D normalCursor;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = new Vector2(30, 30);
    public static bool cursorSet = false;
    private Animator myAnimator;
    public int Move;

    //use for stairs cam shtuff
    public bool approachLeft = true;

    // Use this for initialization
    void Start () {
        if (!cursorSet)
        {
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
            cursorSet = true;
        }

        

        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;

        if (PersistVars.currentScene == "mansion")
        {
            if (!PersistVars.returningToHome)
            {
                gameObject.transform.position = GameObject.Find("introSpawn").transform.position;
                cam.transform.position = new Vector3(-51.4f, -1.42f, cam.transform.position.z);
                GameObject.Find("Art Piece").GetComponent<Text>().text = "No Current Painting";
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Mansion");
            }
            else
            {
                gameObject.transform.position = GameObject.Find("hubSpawn").transform.position;
                cam.transform.position = new Vector3(-10.32f, -13f, cam.transform.position.z);
            }
        }

        myAnimator = GetComponent<Animator>();
    }
    
    //both of these scripts are calling in the EnvInteracter Script when an object is clicked on, and then call moveStraight()
    public void MovePlayer(Vector3 target, GameObject start)
    {
        moveToPos = target;
        landing = start;
        moveStraight();
    }

    public void MovePlayer(Vector3 target, GameObject start, int offset)
    {
        moveToPos = target;
        landing = start;
        columnOffset = offset;
        moveStraight();
    }

    //moves the player to the object that was clicked on, and when the move to the target position is done this calls identifyLanding() to decide if the object clicked on was an object that
    //requires further interaction, such as stairs, doors, or curves
    //also sets boolean moving to true so that the player cannot click other objects while they are moving to an object
    void moveStraight()
    {
        if (!moving)
        {
            if (gameObject.transform.position.x < moveToPos.x)
            {
                myAnimator.SetInteger("Move", -1);
            }
            else if (gameObject.transform.position.x > moveToPos.x)
            {
                myAnimator.SetInteger("Move", 1);
            }
            moving = true;
            iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(moveToPos.x + columnOffset, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "identifyLanding"));

        }
    }

    //moves the player and the camera up or down the stairs
    void moveStairs(bool ukiyo = false)
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        //checks for the stairs on the left side of the ukiyo-e map
        //if not on the left side, then do stairs as normal
        if (!ukiyo && (cam.transform.position.x !=11.59 && cam.transform.position.y != 2.7))
        {
            if (approachLeft)
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x - CameraScript.offsetInUse, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
            else
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x + CameraScript.offsetInUse, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
        }
        //else only move the cam up and down
        else
        {
            if (approachLeft)
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
            else
            {
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
        }

    }

    //moves the player along a designated curve
    void moveCurve(string curveName, int speed)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(curveName), "speed", speed, "easetype", "linear", "oncomplete", "notMoving"));
    }

    //same as above, but moves backward along the curve
    void moveCurveReverse(string curveName, int speed)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPathReversed(curveName), "speed", speed, "easetype", "linear", "oncomplete", "notMoving"));
    }

    //moves the player downwards, as in using an elevator
    void moveElevator()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
    }

    //resets the vars that are needed during movement, lets the player click to move again, and resets the landing to null for the next click
    void notMoving()
    {
        
        moving = false;
        myAnimator.SetInteger("Move", 0);
        columnOffset = 0;
        landing = null;
        
        if(!gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    //This function takes the passed in landing object, if there is one, and performs necessary operations when the player arrives there
    //ie. move up the stairs after arriving at the base, or moving through a door after getting to it
    void identifyLanding()
    {
        if (landing != null)
        {
            offset = transform.position.y - moveToPos.y;
            camOffset = cam.transform.position.y - moveToPos.y;
            switch (landing.name)
            {
                //Mansion Options
                case "stairs1":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs();
                    break;
                case "stairs2":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs();
                    break;
                case "clock":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("chair");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveCurve("clockToChair", 10);
                    break;
                case "chair":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("clock");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveCurveReverse("clockToChair", 10);
                    break;
                case "elevTop":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("elevBot");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveElevator();
                    break;
                case "elevBot":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("elevTop");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveElevator();
                    break;
                case "Surrealism":
                    PersistVars.previousScene = "mansion";
                    PersistVars.currentScene = "SurrealistZone";
                    PersistVars.Surreal = false;
                    myAnimator.SetBool("PortalWalk", true);
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Surrealism Zone");
                    notMoving();
                    StartCoroutine(SurrealismPortalEnter());
                    break;
                case "Ukiyo-e":
                    PersistVars.previousScene = "mansion";
                    PersistVars.currentScene = "Ukiyo-eZone";
                    PersistVars.Ukiyo = true;
                    myAnimator.SetBool("PortalWalk", true);
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Ukiyo-E Zone");
                    notMoving();
                    StartCoroutine(UkiyoPortalEnter());
                    break;
                case "Baroque":
                    PersistVars.previousScene = "mansion";
                    PersistVars.currentScene = "BaroqueZone";
                    PersistVars.Baroque = true;
                    myAnimator.SetBool("PortalWalk", true);
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Baroque Zone");
                    notMoving();
                    StartCoroutine(BaroquePortalEnter());
                    break;
                case "portal_1":
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().PortalComingSoon();
                    notMoving();
                    break;
                case "portal_2":
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().PortalComingSoon();
                    notMoving();
                    break;
                case "portal_5":
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().PortalComingSoon();
                    notMoving();
                    break;
                //Surrealist options
                case "rightEdge":
                    myAnimator.SetInteger("Move", -1);
                    landingPair = GameObject.Find("leftEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(gameObject.transform.position.x + 5, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
                    cam.transform.position = new Vector3(landingPos.x + 10.25f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    myAnimator.SetInteger("Move", -1);
                    break;
                case "leftEdge":
                    myAnimator.SetInteger("Move", 1);
                    landingPair = GameObject.Find("rightEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(gameObject.transform.position.x - 5, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
                    cam.transform.position = new Vector3(landingPos.x - 10.25f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    myAnimator.SetInteger("Move", 1);
                    break;
                case "door_0S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_0";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 1");
                    StartCoroutine(doorZeroS());
                    notMoving();
                    break;
                case "door_1S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_1";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 2");
                    StartCoroutine(doorOneS());
                    notMoving();
                    break;
                case "door_2S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_2";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 3");
                    StartCoroutine(doorTwoS());
                    notMoving();
                    break;
                case "door_3S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_3";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 4");
                    notMoving();
                    StartCoroutine(doorThreeS());
                    break;
                case "door_4S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_4";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 5");
                    StartCoroutine(doorFourS());
                    notMoving();
                    break;
                case "door_5S":
                    myAnimator.SetBool("DoorWalkIn", true);
                    PersistVars.previousScene = "SurrealistZone";
                    PersistVars.currentScene = "S_5";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 6");
                    StartCoroutine(doorFiveS());
                    notMoving();
                    break;
                //Baroque options
                case "Bstairs1":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs3");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs();
                    break;
                case "Bstairs2":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs4");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs();
                    break;
                case "Bstairs3":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs();
                    break;
                case "Bstairs4":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs();
                    break;
                case "door_0B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_0";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 1");
                    notMoving();
                    SceneManager.LoadScene("B_0");
                    break;
                case "door_1B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_1";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 2");
                    notMoving();
                    SceneManager.LoadScene("B_1");
                    break;
                case "door_2B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_2";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 3");
                    notMoving();
                    SceneManager.LoadScene("B_2");
                    break;
                case "door_3B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_3";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 4");
                    notMoving();
                    SceneManager.LoadScene("B_3");
                    break;
                case "door_4B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_4";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 5");
                    notMoving();
                    SceneManager.LoadScene("B_4");
                    break;
                case "door_5B":
                    PersistVars.previousScene = "BaroqueZone";
                    PersistVars.currentScene = "B_5";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 6");
                    notMoving();
                    SceneManager.LoadScene("B_5");
                    break;
                //Ukiyo-E options
                case "door_0U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_0";
                    notMoving();
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 1");
                    SceneManager.LoadScene("U_0");
                    break;
                case "door_1U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_1";
                    notMoving();
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 2");
                    SceneManager.LoadScene("U_1");
                    break;
                case "door_2U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_2";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 3");
                    notMoving();
                    SceneManager.LoadScene("U_2");
                    break;
                case "door_3U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_3";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 4");
                    notMoving();
                    SceneManager.LoadScene("U_3");
                    break;
                case "door_4U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_4";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 5");
                    notMoving();
                    SceneManager.LoadScene("U_4");
                    break;
                case "door_5U":
                    PersistVars.previousScene = "Ukiyo-eZone";
                    PersistVars.currentScene = "U_5";
                    GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Studio 6");
                    notMoving();
                    SceneManager.LoadScene("U_5");
                    break;
                case "Ustairs1":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs3");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs(false);
                    break;
                case "Ustairs2":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs4");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs(true);
                    break;
                case "Ustairs3":
                    myAnimator.SetInteger("Move", -1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveStairs(false);
                    break;
                case "Ustairs4":
                    myAnimator.SetInteger("Move", 1);
                    //landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveStairs(true);
                    break;
                case "leftEndU":
                    myAnimator.SetInteger("Move", -1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("rightEndU");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = true;
                    moveCurve("bridge", 10);
                    break;
                case "rightEndU":
                    myAnimator.SetInteger("Move", 1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("leftEndU");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    approachLeft = false;
                    moveCurveReverse("bridge", 10);
                    break;
                default:
                    Debug.Log("did not access a name for a valid landing object");
                    break;
            }
        }
        else
        {
            notMoving();
        }
    }
    IEnumerator UkiyoPortalEnter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GENERALUI").GetComponent<AudioSource>().clip = null;
        SceneManager.LoadScene("Ukiyo-eZone");
    }
    IEnumerator BaroquePortalEnter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GENERALUI").GetComponent<AudioSource>().clip = null;
        SceneManager.LoadScene("BaroqueZone");
    }
    IEnumerator SurrealismPortalEnter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GENERALUI").GetComponent<AudioSource>().clip = null;
        SceneManager.LoadScene("SurrealistZone");
    }
    IEnumerator doorZeroS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_0");
    }
    IEnumerator doorOneS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_1");
    }
    IEnumerator doorTwoS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_2");
    }
    IEnumerator doorThreeS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_3");
    }
    IEnumerator doorFourS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_4");
    }
    IEnumerator doorFiveS()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_5");
    }
}

//archived code
/*
// Update is called once per frame
void Update()
{
    if (mousePressed)
    {
        Vector2 xCoord = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 10);
        player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 10);
    }

    if (player.transform.position == transform.position)
    {
        SceneManager.LoadScene("UIScene1");
    }
}

void OnMouseDown()
{
    mousePressed = true;
}*/
/*while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
            yield return null;
            if (transform.position.x == landingPos.x)
            {
                break;
            }
        }
        moving = false;*/

/* while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveToPos.x, transform.position.y, transform.position.z), Time.deltaTime * 10);
            yield return null;
            if (transform.position.x == moveToPos.x)
            {
                if (landing != null)
                {
                    offset = transform.position.y - moveToPos.y;
                    switch (landing.name)
                    {
                        case "stairs1":
                            landingPos = GameObject.Find("stairs2").transform.position;
                            StartCoroutine(moveStairs());
                            break;
                        case "stairs2":
                            landingPos = GameObject.Find("stairs1").transform.position;
                            StartCoroutine(moveStairs());
                            break;
                        case "clock":
                            moveCurve("clockToChair", 10);
                            break;
                        case "chair":
                            moveCurveReverse("clockToChair", 10);
                            break;
                        default:
                            Debug.Log("did not access a name for a valid landing object");
                            break;
                    }
                }
                break;
            }
        }
        moving = false;*/


/*if(mousePressed)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveToPos.x, transform.position.y, transform.position.z), Time.deltaTime * 10);
        if(transform.position.x == moveToPos.x)
        {
            if (landing != null)
            {
                toLanding = true;
                offset = transform.position.y - moveToPos.y;
            }        
            //make mousePressed false so that you stop moving
            mousePressed = false;
        }
    }
    if(toLanding)
    {
        switch (landing.name)
        {
            case "stairs1":
                landingPos = GameObject.Find("stairs2").transform.position;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                break;
            case "stairs2":
                landingPos = GameObject.Find("stairs1").transform.position;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                break;
            case "clock":
                //landingPos = GameObject.Find("chair").transform.position;
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                //if 
                break;
            case "chair":
                landingPos = GameObject.Find("clock").transform.position;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
                break;
            default:
                Debug.Log("did not access a name for a valid landing object");
                break;
        }
        if (transform.position.x == landingPos.x)
        {
            //after using landing to find the pair, set it to null again for next use
            landing = null;
            toLanding = false;
            mousePressed = false;
        }
    }*/