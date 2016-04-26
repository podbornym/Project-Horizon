using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ContinuePressed()
    {
        if (GameObject.Find("Cover").GetComponent<SpriteRenderer>().enabled == true)
        {
            GameObject.Find("Cover").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Pipe Dream Manager").GetComponent<PipeDreamManager>().gameRunning = true;
            GameObject.Find("Pipe Dream Manager").GetComponent<PipeDreamManager>().StartFlow();
        }
        else
        {
            GameObject.Find("GENERALUI").GetComponent<PersistVars>().pipeDreamScore = PipeDreamManager.pipeDreamReturn;
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
            SceneManager.LoadScene(PersistVars.currentScene);
        }
    }

    public void RestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HelpPressed()
    {
        if (GameObject.Find("HelpImage").GetComponent<Image>().enabled == false)
        {
            GameObject.Find("HelpImage").GetComponent<Image>().enabled = true;
            GameObject.Find("HelpText").GetComponent<Text>().enabled = true;
        }
        else
        {
            GameObject.Find("HelpImage").GetComponent<Image>().enabled = false;
            GameObject.Find("HelpText").GetComponent<Text>().enabled = false;
        }
    }
}
