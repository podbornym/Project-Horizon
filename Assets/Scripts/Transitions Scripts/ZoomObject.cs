using UnityEngine;
using System.Collections;

public class ZoomObject : MonoBehaviour {
	// scaling rate
	float scaleRate = 0.001f;
	// moving rate
	float moveRate = 0.001f;
	// Min and Max values for scale and position (move)
	float minMove = 6.75f;
	float maxMove = 7.0f;
	float minScale = 0.75f;
	float maxScale = 1.0f;

	// Update is called once per frame
	void Update () {
		// Checks if scale is in min/max bounds
		// Changes sign of scaleRate if out-of-bounds
		if (transform.localScale.x < minScale) {
			scaleRate = Mathf.Abs (scaleRate);
		} 
		else if (transform.localScale.x > maxScale) {
			scaleRate = -Mathf.Abs (scaleRate);
		}

		// Checks if position is in min/max bounds
		// Changes sign of moveRate if out-of-bounds
		if (transform.localPosition.x < minMove) {
			moveRate = Mathf.Abs (moveRate);
		} 
		else if (transform.localPosition.x > maxMove) {
			moveRate = 	-Mathf.Abs (moveRate);
		}
		ApplyScaleRate ();
		ApplyMoveRate ();
	}

	// Changes obj. scale
	public void ApplyScaleRate() {
		transform.localScale += Vector3.one * scaleRate;
	}

	// Changes obj. position
	public void ApplyMoveRate() {
		transform.localPosition += new Vector3(moveRate, -moveRate, 0.0f);
	}
}
