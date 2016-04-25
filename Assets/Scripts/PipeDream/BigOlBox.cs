using UnityEngine;
using System.Collections;

public class BigOlBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (GameObject.Find("Cover").GetComponent<SpriteRenderer>().enabled == true)
        {
            GameObject.Find("Cover").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Pipe Dream Manager").GetComponent<PipeDreamManager>().gameRunning = true;
            GameObject.Find("Pipe Dream Manager").GetComponent<PipeDreamManager>().StartFlow();
            Destroy(gameObject);
        }
    }
}
