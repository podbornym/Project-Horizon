using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScene : MonoBehaviour {
    public string previous;
    //public float match3Score;
    // Use this script to easily restart a game, or go back to the level they were on previously
    // Variables are not preserved, so if you need values to stay the same, make sure to attach them to the PersistVars.cs script
    
    // Use this function to easily restart the level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Use this function to find the gameObject with the PersistentVars script, and get the previousScene component
    public void NextLevel()
    {
        if (GameObject.Find("GradeImage").GetComponent<Image>().enabled == false)
        {
            GameObject.Find("Scripts").GetComponent<BoardCreation>().TallyScore();
            float timer = 2;
            timer -= Time.deltaTime;
            print (timer);
            if (PersistVars.previousScene != "null")// && timer < 0)
            {
                GameObject.Find("GENERALUI").GetComponent<PersistVars>().match3Score = BoardCreation.match3Return;
                SceneManager.LoadScene(PersistVars.currentScene);
                GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
            }
        }
    }
}
