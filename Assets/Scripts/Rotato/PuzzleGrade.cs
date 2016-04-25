using UnityEngine;
using System.Collections;

public class PuzzleGrade : MonoBehaviour {

	public float zScore;
	private float zRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		zRotation = transform.localEulerAngles.z;

	}

	public float returnPosScore()
	{
		float posScore = Vector3.Distance( GameObject.Find("PuzzleBackground").transform.position, transform.position );

		//print("pos score: " + score);

		return posScore;
	}

	public float returnZScore()
	{

		if (zRotation > 180)
		{
			zScore = 360 - zRotation;
		}
		else if (zRotation < 180)
		{
			zScore = zRotation;
		}

		//print(zScore);
		return zScore;
	}
}
