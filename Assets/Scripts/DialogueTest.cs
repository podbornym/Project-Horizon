using UnityEngine;
using System.Collections;

public class DialogueTest : MonoBehaviour {

    public string[,] dialogue1 = { { "hello", "goodbye", "clue1", "clue2" }, { "hey", "bye", "I dont know", "I'm not sure" } };
    public string[,] dialogue2 = { { "hello", "goodbye", "clue1", "clue2" }, { "hey", "bye", "You Found it", "I'm not sure" } };
    public string[,] dialogue3 = { { "hello", "goodbye", "clue1", "clue2" }, { "hey", "bye", "I dont know", "Cool Find" } };
    public string[,] dialogue4 = { { "hello", "goodbye", "clue1", "clue2" }, { "hey", "bye", "You Found it", "Cool Find" } };
    public GameObject clue1;
    public GameObject clue2;
    bool[] ClueFound = { false, false };
    private int init = 0;
    string[,] currentDialogue;

    // Use this for initialization
    void Start ()
    {
        currentDialogue = dialogue1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int test = 0;
        if (ClueFound[0] && !ClueFound[1])
        {
            currentDialogue = dialogue2;
        }
        if (!ClueFound[0] && ClueFound[1])
        {
            currentDialogue = dialogue3;
        }
        if (ClueFound[0] && ClueFound[1])
        {
            currentDialogue = dialogue4;
        }
        if (init == 0)
        {
            Debug.Log("Options:");
            Debug.Log("1 - " + currentDialogue[0, 0] + ":    2 - " + currentDialogue[0, 1] + ":    3 - " + currentDialogue[0, 2] + ":    4 - " + currentDialogue[0, 3]);
            init += 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(currentDialogue[1, 0]);
            Debug.Log("Options:");
            Debug.Log("1 - " + currentDialogue[0, 0] + ":    2 - " + currentDialogue[0, 1] + ":    3 - " + currentDialogue[0, 2] + ":    4 - " + currentDialogue[0, 3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(currentDialogue[1, 1]);
            Debug.Log("Options:");
            Debug.Log("1 - " + currentDialogue[0, 0] + ":    2 - " + currentDialogue[0, 1] + ":    3 - " + currentDialogue[0, 2] + ":    4 - " + currentDialogue[0, 3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(currentDialogue[1, 2]);
            Debug.Log("Options:");
            Debug.Log("1 - " + currentDialogue[0, 0] + ":    2 - " + currentDialogue[0, 1] + ":    3 - " + currentDialogue[0, 2] + ":    4 - " + currentDialogue[0, 3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(currentDialogue[1, 3]);
            Debug.Log("Options:");
            Debug.Log("1 - " + currentDialogue[0, 0] + ":    2 - " + currentDialogue[0, 1] + ":    3 - " + currentDialogue[0, 2] + ":    4 - " + currentDialogue[0, 3]);
        }
        if (Input.GetMouseButtonDown(0))
        {
            FindClue();
        }
    }
    void FindClue()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if (hit)
        {
            if(hit.collider.gameObject.tag == "clue")
            {
                if (hit.collider.gameObject == clue1)
                {
                    ClueFound[0] = true;
                    Debug.Log("Found Clue 1");
                }
                if (hit.collider.gameObject == clue2)
                {
                    ClueFound[1] = true;
                    Debug.Log("Found Clue 2");
                }
            }
        }
    }
    
}
