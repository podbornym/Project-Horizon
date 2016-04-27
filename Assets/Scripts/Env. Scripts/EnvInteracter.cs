using UnityEngine;
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
    public GameObject TopElevator;
    public GameObject BottomElevator;
    public GameObject surrealism;
    private Animator ukioyAnimator;
    private Animator baroqueAnimator;
    private Animator surrealismAnimator;
    private Animator TElevator;
    private Animator BElevator;

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

                TElevator = TopElevator.GetComponent<Animator>();

                BElevator = BottomElevator.GetComponent<Animator>();
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
            else if (gameObject.tag == "UkiyoEportal"|| gameObject.tag == "BaroquePortal"||gameObject.tag == "SurrealismPortal" || gameObject.tag == "portal")
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
            if (gameObject.tag == "bridge" || gameObject.tag == "stairs" /*|| gameObject.tag == "elevator" || gameObject.tag == "ElevatorBottom"*/ || gameObject.tag == "portal")
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
            else if (gameObject.tag == "UkiyoEportal")
            {
				ukiyo.GetComponent<AudioSource> ().Play ();
                ukioyAnimator.SetInteger("OpenUkiyo-eDoor", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                StartCoroutine(UkiyoPortal());

            }
            else if (gameObject.tag == "BaroquePortal")
            {
				baroque.GetComponent<AudioSource> ().Play ();
                baroqueAnimator.SetInteger("BaroqueIsOpening", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                StartCoroutine(BaroquePortal());

            }
            else if (gameObject.tag == "SurrealismPortal")
            {
				surrealism.GetComponent<AudioSource> ().Play ();
                surrealismAnimator.SetInteger("SurrealismIsOpening", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                StartCoroutine(SurrealismPortal());

            }
            else if(gameObject.tag == "elevator")
            {
                TElevator.SetInteger("Elevator", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                StartCoroutine(ElevatorTop());
            }
            else if (gameObject.tag == "ElevatorBottom")
            {
                BElevator.SetInteger("ElevatorBottom", 1);
                player.GetComponent<PlayerMovement>().MovePlayer(transform.position, gameObject);
                StartCoroutine(ElevatorBottom());
            }
            /* else
             {
                 player.GetComponent<PlayerMovement>().MovePlayer(transform.position, null);
             }*/
        }
    }
    IEnumerator BaroquePortal()
    {
        yield return new WaitForSeconds(1.09f);
        baroqueAnimator.SetInteger("BaroqueIsOpen", 100);


    }
    IEnumerator UkiyoPortal()
    {
        yield return new WaitForSeconds(1.09f);
        ukioyAnimator.SetInteger("UkiyoIsOpen", 100);


    }
    IEnumerator SurrealismPortal()
    {
        yield return new WaitForSeconds(1.09f);
        surrealismAnimator.SetInteger("SurrealismIsOpen", 100);


    }
    IEnumerator ElevatorTop()
    {
        yield return new WaitForSeconds(1.3f);
        BElevator.SetInteger("ElevatorBottom", 1);
        yield return new WaitForSeconds(.7f);
        TElevator.SetInteger("Elevator", -1);
        BElevator.SetInteger("ElevatorBottom", -1);
        yield return new WaitForSeconds(2f);
        TElevator.SetInteger("Elevator", 0);
        BElevator.SetInteger("ElevatorBottom", 0);
    }
    IEnumerator ElevatorBottom()
    {
        yield return new WaitForSeconds(1.3f);
        TElevator.SetInteger("Elevator", 1);
        yield return new WaitForSeconds(.7f);
        BElevator.SetInteger("ElevatorBottom", -1);
        TElevator.SetInteger("Elevator", -1);
        yield return new WaitForSeconds(2f);
        BElevator.SetInteger("ElevatorBottom", 0);
        TElevator.SetInteger("Elevator",0);
    }
}
