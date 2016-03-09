using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    private static bool mousePressed = false;
    private static Vector3 moveToPos;
    private static Vector3 landingPos;
    private static GameObject landing = null;
    private static float offset;
    private static bool toLanding = false;
    private bool moving = false;

    // Use this for initialization
    void Start () {
	    
	}

    void Update()
    {
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
    }

    public void MovePlayer(Vector3 target, GameObject start)
    {
        moveToPos = target;
        mousePressed = true;
        landing = start;
        StartCoroutine(moveStraight());
    }

    IEnumerator moveStraight()
    {
        if (!moving)
        {
            moving = true;
            while (true)
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
                                moveCurve();
                                break;
                            case "chair":
                                moveCurveReverse();
                                break;
                            default:
                             Debug.Log("did not access a name for a valid landing object");
                                break;
                        }
                    }
                    break;
                }
            }
            moving = false;
        }
    }

    IEnumerator moveStairs()
    {
        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(landingPos.x, landingPos.y + offset, transform.position.z), Time.deltaTime * 10);
            yield return null;
            if (transform.position.x == landingPos.x)
            {
                break;
            }
        }
        moving = false;
    }

    void moveCurve()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("clockToChair"), "speed", 10, "easetype", "linear"));
        //todo implement oncomplete(moving == false) both here and in reverse, and make the function moveCurve
        //take in the string for the path name and the speed to run the animation at 
        moving = false;
    }

    void moveCurveReverse()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPathReversed("clockToChair"), "speed", 10, "easetype", "linear"));
        moving = false;
    }
}
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
