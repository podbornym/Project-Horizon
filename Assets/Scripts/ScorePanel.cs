using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour {
    //bool showScorePanel = false;
    public GameObject panel;
    public Slider mediumSlider;
    public Slider inspirationSlider;
    public Slider disciplineSlider;
    public Slider historicalSlider;
    public Slider toolsSlider;

	// Use this for initialization
	void Start () {
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    //if they have finished painting
        //show score
	}

    public void ShowScorePanel()
    {
        panel.SetActive(true);
    }

    
}
