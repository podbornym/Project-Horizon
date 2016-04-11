using UnityEngine;
using System.Collections;

public class InitializeClues : MonoBehaviour {

    public GameObject UI;
    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;
    public GameObject clue5;
    public GameObject clue6;
    // Use this for initialization
    void Start () {
        UI = GameObject.Find("GENERALUI");
        UI.GetComponent<DialogueReader>().clueOne = clue1;
        UI.GetComponent<DialogueReader>().clueTwo = clue2;
        UI.GetComponent<DialogueReader>().clueThree = clue3;
        UI.GetComponent<DialogueReader>().clueFour = clue4;
        UI.GetComponent<DialogueReader>().clueFive = clue5;
        UI.GetComponent<DialogueReader>().clueSix = clue6;
        UI.GetComponent<DialogueReader>().clueOne.gameObject.GetComponent<Collider2D>().enabled = false;
        UI.GetComponent<DialogueReader>().clueTwo.gameObject.GetComponent<Collider2D>().enabled = false;
        UI.GetComponent<DialogueReader>().clueThree.gameObject.GetComponent<Collider2D>().enabled = false;
        UI.GetComponent<DialogueReader>().clueFour.gameObject.GetComponent<Collider2D>().enabled = false;
        UI.GetComponent<DialogueReader>().clueFive.gameObject.GetComponent<Collider2D>().enabled = false;
        UI.GetComponent<DialogueReader>().clueSix.gameObject.GetComponent<Collider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
