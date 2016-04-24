﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EnvInteracter : MonoBehaviour {

    public Texture2D normalCursor;
    public Texture2D mouseOverCursor;
    public Texture2D pinkCursor;
    public Texture2D leftArrow;
    public Texture2D rightArrow;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = new Vector2(30, 30);
    public static bool cursorSet = false;
    public GameObject player;
    public GameObject ukiyo;
    public GameObject baroque;
    public GameObject surrealism;
    private Animator ukioyAnimator;
    private Animator baroqueAnimator;
    private Animator surrealismAnimator;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        if (PersistVars.currentScene == "mansion")
        {
            try
            {
                ukiyo = GameObject.Find("Ukiyo-e");
                ukioyAnimator = ukiyo.GetComponent<Animator>();
                baroque = GameObject.Find("Baroque");
                baroqueAnimator = baroque.GetComponent<Animator>();
                surrealism = GameObject.Find("Surrealism");
                surrealismAnimator = surrealism.GetComponent<Animator>();
            }
            catch
            {

            }
        }
    }

    void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if ((gameObject.tag == "column" || gameObject.name == "leftEdge") && gameObject.transform.position.x < player.transform.position.x)
            {
                Cursor.SetCursor(leftArrow, hotSpot, cursorMode);
            }
            else if ((gameObject.tag == "column" || gameObject.name == "rightEdge") && gameObject.transform.position.x > player.transform.position.x)
            {
                Cursor.SetCursor(rightArrow, hotSpot, cursorMode);
            }
            else if (gameObject.tag == "portal")
            {
                Cursor.SetCursor(pinkCursor, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(mouseOverCursor, hotSpot, cursorMode);
            }
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
            if (gameObject.tag == "portal")
            {
                ukioyAnimator.SetInteger("OpenUkiyo-eDoor", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                ukioyAnimator.SetInteger("UkiyoIsOpen", 100);

                StartCoroutine(Portal());

            }
            if (gameObject.tag == "BaroquePortal")
            {
                baroqueAnimator.SetInteger("BaroqueIsOpening", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                baroqueAnimator.SetInteger("BaroqueIsOpening", 100);

                StartCoroutine(Portal());

            }
            if (gameObject.tag == "SurrealismPortal")
            {
                surrealismAnimator.SetInteger("SurrealismIsOpening", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                surrealismAnimator.SetInteger("SurrealismIsOpen", 100);

                StartCoroutine(Portal());

            }
            /* else
             {
                 player.GetComponent<PlayerMovement>().MovePlayer(transform.position, null);
             }*/
        }
    }
    IEnumerator Portal()
    {
        yield return new WaitForSeconds(2);

    }
}
