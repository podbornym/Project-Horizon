using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public GameObject TextField1;
    public GameObject TextField2;
    public GameObject TextField3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {

        }
    }
}
