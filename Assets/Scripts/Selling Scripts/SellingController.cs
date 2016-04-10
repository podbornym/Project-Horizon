using UnityEngine;
using System.Collections;

public class SellingController : MonoBehaviour {

	public int maxValue;
	public float m1, m2, m3, m4, m5, m6, clues;
	public string buyer;
	float avg;
	public SellingLogic logic;
	bool check;
	int pay;
	int bkPay;
	public bool counter;
	public int correct;

	// Use this for initialization
	void Start () {
		avg = logic.Avg (m1, m2, m3, m4, m5, m6, clues);
		avg = (float)System.Math.Round (avg,2);
		check = logic.ErrorCheck (buyer,avg);
		pay = logic.Payout (buyer, avg, maxValue);
		bkPay = logic.BkPay (counter, correct, maxValue);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {

			Debug.Log ("buyer:" + buyer);
			Debug.Log ("avg:"+avg);
			Debug.Log ("pass:"+check);
			if (buyer == "black") {
				Debug.Log ("payment:"+bkPay);
			} 
			else {
				Debug.Log ("payment:"+pay);
			}
		}


	}

	//void OnButclick () {
	//}
}
