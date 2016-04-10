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

        UI = GameObject.Find("GENERALUI");

        if (UI.GetComponent<Canvas>().enabled)
        {
            UI.GetComponent<Canvas>().enabled = false;
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
            case "object name":
                //do stuff
                break;
            default:
                print("did not click on a valid clue object");
                break;
        }
    }
}
