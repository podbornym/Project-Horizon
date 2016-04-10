using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickedScript : MonoBehaviour {

    public Text TextField1;
    public int buttonNumber;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IAmClicked()
    {
        print("Button " + buttonNumber + " clicked");
        TextField1.text = "Button number " + buttonNumber + " clicked";
    }
}
