﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour {

	public static string levelTo;
	public int seconds;


	void Start (){
		StartCoroutine(loadTimer());
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Waits for 5 seconds, then loads next scene
	IEnumerator loadTimer()
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(levelTo);
	}
}