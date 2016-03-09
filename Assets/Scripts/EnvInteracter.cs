﻿using UnityEngine;
using System.Collections;

public class EnvInteracter : MonoBehaviour {

    public Texture2D normalCursor;
    public Texture2D mouseOverCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static bool cursorSet = false;
    public GameObject player;

    // Use this for initialization
    void Start () {
        if (!cursorSet)
        {
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
            cursorSet = true;
        }
        player = GameObject.Find("Player");
	}

    void OnMouseEnter()
    {
        Cursor.SetCursor(mouseOverCursor, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
    }

    void OnMouseDown()
    {
        if (gameObject.tag != "Untagged")
        {
            player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
        }
        else
        {
            player.GetComponent<PlayerMovement>().MovePlayer(transform.position, null);
        }
        
    }
}
