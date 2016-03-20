using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    GameObject cam;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown()
    {
        if(gameObject.tag == "column")
        {
            if (gameObject.transform.position.x < player.transform.position.x)
            {
                float moveCam = gameObject.transform.position.x - 11;
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(moveCam, cam.transform.position.y, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
            else
            {
                float moveCam = gameObject.transform.position.x + 11;
                iTween.MoveTo(cam, iTween.Hash("position", new Vector3(moveCam, cam.transform.position.y, cam.transform.position.z), "speed", 10, "easetype", "linear"));
            }
        }
    }
}