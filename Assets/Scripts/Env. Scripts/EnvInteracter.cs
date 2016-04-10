using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EnvInteracter : MonoBehaviour {

    public Texture2D normalCursor;
    public Texture2D mouseOverCursor;
    public Texture2D leftArrow;
    public Texture2D rightArrow;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static bool cursorSet = false;
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}

    void OnMouseEnter()
    {
        if (gameObject.tag == "column" && gameObject.transform.position.x < player.transform.position.x)
        {
            Cursor.SetCursor(leftArrow, hotSpot, cursorMode);
        }
        else if (gameObject.tag == "column" && gameObject.transform.position.x > player.transform.position.x)
        {
            Cursor.SetCursor(rightArrow, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(mouseOverCursor, hotSpot, cursorMode);
        }
        
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
    }

    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if (gameObject.tag == "bridge" || gameObject.tag == "stairs" || gameObject.tag == "elevator" || gameObject.tag == "portal")
            {
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
            }
            else if (gameObject.tag == "column")
            {
                if (gameObject.transform.position.x < player.transform.position.x)
                {
                    player.GetComponent<PlayerMovement>().MovePlayer(transform.position, null, -5);
                }
                else
                {
                    player.GetComponent<PlayerMovement>().MovePlayer(transform.position, null, 5);
                }
            }
            else
            {
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, null);
            }
        }
    }
}
