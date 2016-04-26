using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Collections.Generic;

public class StudioScript : MonoBehaviour {

    public GameObject UI;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static bool cursorSet = false;
    public Texture2D standardCursor;    //blue, unlit cursor
    public Texture2D hoverCursor;       //blue, lit cursor
    public AudioClip clueClick = Resources.Load("Sound/UI SFX/Important Click", typeof (AudioClip)) as AudioClip;
    public AudioClip click = Resources.Load("Sound/UI SFX/General Click", typeof(AudioClip)) as AudioClip;

    // Use this for initialization
    void Start () {
        if (!cursorSet)
        {
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            cursorSet = true;
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        UI = GameObject.Find("GENERALUI");
	}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //load previous scene
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

    void OnMouseUp()
    {
        if(gameObject.GetComponent<AudioSource>())
        {
            Destroy(gameObject.GetComponent<AudioSource>());
        }
    }

    void OnMouseDown()
    {
        AudioSource audio = new AudioSource();
        /*if(gameObject.tag == "clue")
        {
            audio.clip = clueClick;
            audio.PlayOneShot(clueClick);
        }
        else
        {
            audio.clip = click;
            audio.PlayOneShot(click);
        }*/
        switch(gameObject.name)
        {
            // Cases for the first Uk studio
            case "clue1":
                print("found 1");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();

                Button b = GameObject.Find("Button (1)").GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue2":
                print("found 2");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();

                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue3":
                print("found 3");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();

                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue4":
                print("found 4");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue5":
                print("found 5");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue6":
                print("found 6");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the second Uk studio
            case "clue7":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue8":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue9":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue10":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue11":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue12":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the third Uk studio
            case "clue13":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue14":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue15":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue16":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue17":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue18":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the fourth Uk studio
            case "clue19":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue20":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue21":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue22":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue23":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue24":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the fifth Uk studio
            case "clue25":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue26":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue27":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue28":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue29":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue30":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the sixth Uk studio
            case "clue31":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue32":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue33":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue34":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue35":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue36":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the first Surrealism studio
            case "clue37":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SOne", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue38":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SOne", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue39":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SOne", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue40":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SOne", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue41":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SOne", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue42":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SOne", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the second Surrealism studio
            case "clue43":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("STwo", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue44":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("STwo", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue45":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("STwo", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue46":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("STwo", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue47":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("STwo", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue48":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("STwo", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the third Surrealism studio
            case "clue49":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SThree", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue50":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SThree", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue51":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SThree", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue52":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SThree", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue53":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SThree", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue54":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SThree", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the fourth Surrealism studio
            case "clue55":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFour", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue56":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFour", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue57":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFour", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue58":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFour", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue59":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFour", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue60":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFour", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the fifth Surrealism studio
            case "clue61":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFive", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue62":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFive", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue63":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFive", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue64":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFive", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue65":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFive", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue66":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SFive", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the sixth Surrealism studio
            case "clue67":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SSix", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue68":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SSix", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue69":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SSix", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue70":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SSix", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue71":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SSix", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue72":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("SSix", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;

            // Cases for the first Baroque studio
            case "clue73":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BOne", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue74":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BOne", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue75":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BOne", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue76":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BOne", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue77":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BOne", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue78":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BOne", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the second Baroque studio
            case "clue79":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BTwo", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue80":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BTwo", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue81":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BTwo", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue82":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BTwo", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue83":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BTwo", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue84":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BTwo", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the third Broque studio
            case "clue85":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BThree", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue86":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BThree", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue87":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BThree", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue88":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BThree", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue89":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BThree", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue90":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BThree", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the fourth Baroque studio
            case "clue91":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFour", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue92":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFour", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue93":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFour", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue94":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFour", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue95":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFour", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue96":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFour", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the fifth Baroque studio
            case "clue97":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFive", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue98":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFive", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue99":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFive", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue100":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFive", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue101":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFive", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue102":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BFive", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            // Cases for the sixth Baroque studio
            case "clue103":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BSix", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (1)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue104":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BSix", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (2)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue105":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BSix", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (3)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue106":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BSix", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (4)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue107":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BSix", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (5)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            case "clue108":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("BSix", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                b = GameObject.Find("Button (6)").GetComponent<Button>();
                cb = b.colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = new Color(1, 0.92f, 0.016f, 1);
                b.colors = cb;
                break;
            default:
                print("did not click on a valid clue object");
                break;
        }
    }
}
