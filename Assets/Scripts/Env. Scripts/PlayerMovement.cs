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

    void moveStairs()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        iTween.MoveTo(cam, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
    }

    void moveCurve(string curveName, int speed)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(curveName), "speed", speed, "easetype", "linear", "oncomplete", "notMoving"));
    }

    void moveCurveReverse(string curveName, int speed)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPathReversed(curveName), "speed", speed, "easetype", "linear", "oncomplete", "notMoving"));
    }

    void moveElevator()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), "speed", 10, "easetype", "linear", "oncomplete", "notMoving"));
        iTween.MoveTo(cam, iTween.Hash("position", new Vector3(landingPos.x, landingPos.y + camOffset, cam.transform.position.z), "speed", 10, "easetype", "linear"));
    }

    void notMoving()
    {
        
        moving = false;
        myAnimator.SetInteger("Move", 0);
        columnOffset = 0;
        landing = null;
        
    }

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
                    landing.GetComponent<BoxCollider2D>().enabled = false;
                    landingPair = GameObject.Find("stairs2");
                    landingPos = landingPair.transform.position;
                    landingPair.GetComponent<BoxCollider2D>().enabled = true;
                    moveStairs();
                    break;
                case "stairs2":
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
                    //dostuff
                    print("to the ukiyo-e zone!!!");
                    notMoving();
                    break;
                case "portal_4_B":
                    //dostuff
                    print("to the baroque zone!!!");
                    notMoving();
                    break;
                //Surrealist options
                case "rightEdge":
                    //dostuff
                    landingPair = GameObject.Find("leftEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    cam.transform.position = new Vector3(landingPos.x + 10.27f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
                    break;
                case "leftEdge":
                    landingPair = GameObject.Find("rightEdge");
                    landingPos = landingPair.transform.position;
                    gameObject.transform.position = new Vector3(landingPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
                    cam.transform.position = new Vector3(landingPos.x - 10.27f, cam.transform.position.y, cam.transform.position.z);
                    notMoving();
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
