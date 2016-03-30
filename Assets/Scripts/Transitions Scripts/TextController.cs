using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	// Array of facts to be displayed
	public string[] facts;
	// Index of array
	public int index =0;

	// Use this for initialization
	void Start () {
		Text txt = gameObject.GetComponent<Text> ();
		txt.text = facts[index];
	}

}
