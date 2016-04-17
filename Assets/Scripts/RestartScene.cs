﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        if (PersistVars.previousScene != "null")
            GameObject.Find("GENERALUI").GetComponent<PersistVars>().match3Score = BoardCreation.match3Return;
            SceneManager.LoadScene(PersistVars.previousScene);
    }
}
