using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {
	
	// Update is called once per frame
	public void BackPressed () {
        if (PersistVars.previousScene != null)
        {
            SceneManager.LoadScene(PersistVars.previousScene);
        }
        if (!GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled)
        {
            GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
        }
        switch (PersistVars.previousScene)
        {
            case "mansion":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Mansion");
                break;
            case "SurrealistZone":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Surrealist Zone");
                break;
            case "BaroqueZone":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Baroque Zone");
                break;
            case "Ukiyo-eZone":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Ukiyo-e Zone");
                break;
        }
    }
}
