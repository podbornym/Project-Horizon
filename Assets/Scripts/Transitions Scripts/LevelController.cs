using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.anyKey){
			TransitionController.levelTo = "TransitionTo";
			SceneManager.LoadScene("TransitionScene");
		}
	
	}
}
