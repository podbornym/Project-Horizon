using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {

    //public Renderer rend;
    public Text textWindow;
    // Use this for initialization
    void Start () {
        //rend = GetComponent<Renderer>();
        SetInvisible();
    }

    public void SetVisible()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
            textWindow.text = "Please select from the left, and then select a work of art.";
            //print("text should be changed");
        }
        //rend.enabled = true;
        else
            gameObject.SetActive(true);
            

    }
    public void SetInvisible()
    {
        //rend.enabled = false;
        gameObject.SetActive(false);
    }
}
