﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class traceScript : MonoBehaviour {

    public float timeRemaining = 2f;
    public int tabsLeft = 5;
    public Text time;
    public Text tabs;
    public Text warning;

    public GameObject LineReader;
	
	// Update is called once per frame
	void Update () {

        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            time.text = "Inspection Time Remaining: " + (timeRemaining).ToString("n2");
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            time.text = "Go!";
            warning.text = " ";
            if (tabs.text != "No more tabs!")
                tabs.text = "Tabs remaining: " + tabsLeft.ToString() + "  You can try again by pressing tab";
        }

        if (Input.GetKeyDown("tab"))
        {
            tabProcedure();
        }
    }

    public void tabProcedure()
    {
        if (tabsLeft > 0)
        {
            tabsLeft--;
            tabs.text = "Tabs remaining: " + tabsLeft.ToString();
            timeRemaining = 2f;
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        else
        {
            tabs.text = "No more tabs!";
        }
    }
}
