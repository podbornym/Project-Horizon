using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	// Array of facts to be displayed
	public string[] facts;
	public ZoomObject zoom;
	// Index of array
	public int index;

	// Use this for initialization
	void Start () {
		index = zoom.index;
		Text txt = gameObject.GetComponent<Text> ();
		txt.text = facts[index];
	}

}
