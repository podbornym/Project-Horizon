using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour {
    public Text helpText;
    public bool clicked = true;
    public float timer;

	// Use this for initialization
	void Start () {
        helpText.enabled = true;
        timer = 20;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            TextDisappear();
        }
	}

    // Show text on click
    public void ShowHelpText()
    {
        if (clicked == false)
        {
            helpText.enabled = true;
            clicked = true;
            timer = 8;
        }
        if (clicked == true)
        {
            Update();
            clicked = false;
        }
    }

    // Disable the text element
    public void TextDisappear()
    {
        helpText.enabled = false;
        clicked = false;
    }
}
