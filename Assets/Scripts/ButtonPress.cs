using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool isCorrect;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buttonClicked ()
    {
        print(isCorrect);
        //Mastermind.IsCorrect();
    }
}
