using UnityEngine;
using System.Collections;

public class SellTest : MonoBehaviour {

	public int maxValue;
	public float m1, m2, m3, m4, m5, m6;
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
		avg = logic.Avg (m1, m2, m3, m4, m5, m6);
		avg = (float)System.Math.Round (avg,2);
		check = logic.ErrorCheck (buyer,avg);
		pay = logic.Payout (buyer, avg, maxValue);
		bkPay = logic.BkPay (counter, correct, maxValue);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			/*Debug.Log ("m1:" + m1);
			Debug.Log ("m2:" + m2);
			Debug.Log ("m3:" + m3);
			Debug.Log ("m4:" + m4);
			Debug.Log ("m5:" + m5);
			Debug.Log ("m6:" + m6);*/
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
}
