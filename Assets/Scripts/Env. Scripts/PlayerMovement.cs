using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    private static Vector3 moveToPos;
    private static Vector3 landingPos;
    private static GameObject landing = null;
    private static float offset;
    private static float camOffset;
    private bool moving = false;
    GameObject landingPair = null;
    int columnOffset = 0;
    public GameObject cam;
    public Texture2D normalCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static bool cursorSet = false;
    private Animator myAnimator;
    public int Move;
    public bool IdleLeft;
    public bool IdleRight;
    // Use this for initialization
    void Start () {
        if (!cursorSet)
        {
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
            cursorSet = true;
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
                //IdleLeft = false;
                //IdleRight = true;
            }
            if(gameObject.transform.position.x>moveToPos.x)
            {
                myAnimator.SetInteger("Move", 1);
                //IdleLeft = true;
                //IdleRight = false;
            }
            moving = true;
            iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(moveToPos.x + columnOffset, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "identifyLanding"));

        }
    }

    //moves the player and the camera up or down the stairs
    void moveStairs()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        if (landing.transform.position.x < gameObject.transform.position.x)
        {
            iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x + CameraScript.offsetInUse, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
        }
        else
        {
            iTween.MoveTo(cam, iTween.Hash("position", new Vector3(cam.transform.position.x - CameraScript.offsetInUse, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
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
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "stairs2":
                    myAnimator.SetInteger("Move", -1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
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
                case "portal_0_S":
                    SceneManager.LoadScene("SurrealistZone");
                    notMoving();
                    break;
                case "portal_3_U":
                    SceneManager.LoadScene("Ukiyo-eZone");
                    notMoving();
                    break;
                case "portal_4_B":
                    SceneManager.LoadScene("BaroqueZone");
                    notMoving();
                    break;
                //Surrealist options
                case "rightEdge":
                    landingPair = GameObject.Find("leftEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(gameObject.transform.position.x + 5, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
                    cam.transform.position = new Vector3(landingPos.x + 10.25f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    break;
                case "leftEdge":
                    landingPair = GameObject.Find("rightEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(gameObject.transform.position.x - 5, transform.position.y, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
                    cam.transform.position = new Vector3(landingPos.x - 10.25f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    break;
                case "door_0S":
                    SceneManager.LoadScene("S_0");
                    notMoving();
                    break;
                case "door_1S":
                    SceneManager.LoadScene("S_1");
                    notMoving();
                    break;
                case "door_2S":
                    SceneManager.LoadScene("S_2");
                    notMoving();
                    break;
                case "door_3S":
                    SceneManager.LoadScene("S_3");
                    notMoving();
                    break;
                case "door_4S":
                    SceneManager.LoadScene("S_4");
                    notMoving();
                    break;
                //Baroque options
                case "Bstairs1":
                    myAnimator.SetInteger("Move", -1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs3");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "Bstairs2":
                    myAnimator.SetInteger("Move", 1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs4");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "Bstairs3":
                    myAnimator.SetInteger("Move", 1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "Bstairs4":
                    myAnimator.SetInteger("Move", -1);
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Bstairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "door_0B":
                    SceneManager.LoadScene("B_0");
                    notMoving();
                    break;
                case "door_1B":
                    SceneManager.LoadScene("B_1");
                    notMoving();
                    break;
                case "door_2B":
                    SceneManager.LoadScene("B_2");
                    notMoving();
                    break;
                case "door_3B":
                    SceneManager.LoadScene("B_3");
                    notMoving();
                    break;
                case "door_4B":
                    SceneManager.LoadScene("B_4");
                    notMoving();
                    break;
                //Ukiyo-E options
                case "door_0U":
                    SceneManager.LoadScene("U_0");
                    notMoving();
                    break;
                case "door_1U":
                    SceneManager.LoadScene("U_1");
                    notMoving();
                    break;
                case "door_2U":
                    SceneManager.LoadScene("U_2");
                    notMoving();
                    break;
                case "door_3U":
                    SceneManager.LoadScene("U_3");
                    notMoving();
                    break;
                case "door_4U":
                    SceneManager.LoadScene("U_4");
                    notMoving();
                    break;
                case "Ustairs1":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs3");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "Ustairs2":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs4");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "Ustairs3":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs1");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "Ustairs4":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("Ustairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "leftEndU":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("rightEndU");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveCurve("bridge", 10);
                    break;
                case "rightEndU":
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("leftEndU");
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
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
