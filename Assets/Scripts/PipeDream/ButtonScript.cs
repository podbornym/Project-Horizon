using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ContinuePressed()
    {
        SceneManager.LoadScene(PersistVars.previousScene);
    }

    public void RestartPressed()
    {
        SceneManager.LoadScene(PersistVars.currentScene);
    }
}
