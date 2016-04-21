using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject UI;

	void Start ()
	{
		UI.GetComponent<Canvas> ().enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene ("mansion");
		}
	}
}
