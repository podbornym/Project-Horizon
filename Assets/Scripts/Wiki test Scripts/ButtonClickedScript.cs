using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickedScript : MonoBehaviour {

    public Text TextField1;
    public int buttonNumber;
    public string buttonName;

    public void IAmClicked()
    {
        print("Button " + buttonNumber + " clicked");
        //TextField1.text = "Button number " + buttonNumber + " clicked";
        TextField1.text = "Please select from the " + buttonName + " table of contents";
    }
}
