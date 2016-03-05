using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public GameObject player;
    public bool mousePressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(mousePressed)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 10);
        }

        if (player.transform.position == transform.position)
        {
            SceneManager.LoadScene("UIScene1");
        }
	}

    void OnMouseDown()
    {
        mousePressed = true;
    }
}
