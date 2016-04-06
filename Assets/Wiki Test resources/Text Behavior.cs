using UnityEngine;
using System.Collections;

public class TextBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setInvisible()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void setVisible()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
