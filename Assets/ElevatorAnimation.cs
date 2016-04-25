using UnityEngine;
using System.Collections;
public class ElevatorAnimation : MonoBehaviour {
public Animation elevator;

	// Use this for initialization
	void Start () {
        elevator = gameObject.transform.GetComponent<Animation>();

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        elevator.Play("ElevatorOpening");
	}
}
