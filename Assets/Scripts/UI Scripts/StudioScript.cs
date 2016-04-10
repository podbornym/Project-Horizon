using UnityEngine;
using System.Collections;

public class StudioScript : MonoBehaviour {

    public GameObject UI;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static bool cursorSet = false;
    public Texture2D standardCursor;    //blue, unlit cursor
    public Texture2D hoverCursor;       //blue, lit cursor

    // Use this for initialization
    void Start () {
        if (!cursorSet)
        {
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            cursorSet = true;
        }
	}

    void OnMouseEnter()
    {
        Cursor.SetCursor(hoverCursor, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
    }

    void OnMouseDown()
    {
        switch(gameObject.name)
        {
            case "clue1":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "clue2":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "clue3":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "clue4":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "clue5":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            case "clue6":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;
            default:
                print("did not click on a valid clue object");
                break;
        }
    }
}
