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
            // Cases for the first Uk studio
            case "clue1":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue2":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue3":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue4":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue5":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue6":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UOne", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            // Cases for the second Uk studio
            case "clue7":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue8":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue9":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue10":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue11":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue12":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UTwo", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            // Cases for the third Uk studio
            case "clue13":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue14":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue15":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue16":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue17":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue18":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UThree", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            // Cases for the fourth Uk studio
            case "clue19":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue20":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue21":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue22":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue23":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue24":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFour", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            // Cases for the fifth Uk studio
            case "clue25":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue26":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue27":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue28":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue29":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue30":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("UFive", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            // Cases for the sixth Uk studio
            case "clue31":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 0);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue32":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 1);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue33":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 2);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue34":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 3);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue35":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 4);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            case "clue36":
                print("found me");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                UI.GetComponent<PersistVars>().ArrayAccess("USix", 5);
                UI.GetComponent<PersistVars>().KnowledgeIncrement();
                break;
            default:
                print("did not click on a valid clue object");
                break;
        }
    }
}
