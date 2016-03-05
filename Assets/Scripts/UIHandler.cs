using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {
    //we can use this script for storing stating vars that we want to persist across scene changes
    //will be used to both store these vars and handle changes within the UI
    private static bool createUI = true;
    public string testString = "";

    void Awake()
    {
        if (createUI)
        {
            createUI = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
