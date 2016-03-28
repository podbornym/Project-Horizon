using UnityEngine;
using System.Collections;

public class portalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "portal_0_S":
                //dostuff
                break;
            case "portal_3_U":
                //dostuff
                break;
            case "portal_4_B":
                //dostuff
                break;
            default:
                Debug.Log("did not click on a valid portal object");
                break;
        }
    }
}
