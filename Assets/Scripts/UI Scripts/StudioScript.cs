using UnityEngine;
using System.Collections;

public class StudioScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
	}
}
