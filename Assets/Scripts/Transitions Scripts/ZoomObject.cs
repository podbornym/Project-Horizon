using UnityEngine;
using System.Collections;

public class ZoomObject : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		while (transform.localScale.x < 1.0) {
			transform.localScale += new Vector3 (0.1F,0.1F,0.0F);
		}
	}
		
}
