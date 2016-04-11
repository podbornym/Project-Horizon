using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickedScript : MonoBehaviour {

    public Text TextField1;
    public int buttonNumber;
    public string buttonName;

    public bool clue1Found;
    public bool clue2Found;
    public bool clue3Found;
    public bool clue4Found;
    public bool clue5Found;
    public bool clue6Found;

    public string clue1;
    public string clue2;
    public string clue3;
    public string clue4;
    public string clue5;
    public string clue6;

    public void IAmClicked()
    {
        print("Button " + buttonNumber + " clicked");
        //TextField1.text = "Button number " + buttonNumber + " clicked";
        TextField1.text = "Please select from the " + buttonName + " table of contents";
        if(clue1Found)
        	TextField1.text += "\n\n" + clue1;
        if(clue2Found)
        	TextField1.text += "\n\n" + clue2;
        if(clue3Found)
        	TextField1.text += "\n\n" + clue3;
        if(clue4Found)
        	TextField1.text += "\n\n" + clue4;
        if(clue5Found)
        	TextField1.text += "\n\n" + clue5;
        if(clue6Found)
        	TextField1.text += "\n\n" + clue6;
    }
}
