using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellingController : MonoBehaviour {

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
	public PersistVars vars;
	public GameObject highText;
	public GameObject medText;
	public GameObject lowText;
	public GameObject blkText;
	public Button highButton;
	public Button medButton;
	public Button lowButton;
	public Button blkButton;

	// Use this for initialization
	void Start () {
		// Setting variables
		m1 = vars.match3Score;
		m2 = vars.rotatoScore;
		m3 = vars.pipeDreamScore;
		m4 = vars.tracerScore;
		m5 = vars.findDiffScore;
		m6 = vars.mastermindScore;
		avg = logic.Avg (m1, m2, m3, m4, m5, m6);
		avg = (float)System.Math.Round (avg,2);

		// Setting estimate values
		Text hText = highText.GetComponent<Text>();
		hText.text = "$"+(int)(maxValue * .90);
		Text mText = medText.GetComponent<Text>();
		mText.text = "$"+(int)(maxValue * .80);
		Text lText = lowText.GetComponent<Text>();
		lText.text = "$"+(int)(maxValue * .75);
		Text bText = blkText.GetComponent<Text>();
		bText.text = "$"+(int)(maxValue * .70);
	}

	public void bHandle(string bName) {
		if (bName == "cButtonH") {
			buyer = "high";
		} 
		else if (bName == "cButtonM") {
			buyer = "med";
		}
		else if (bName == "cButtonL") {
			buyer = "low";
		}
		else if (bName == "cButtonB") {
			buyer = "blk";
		}

		check = logic.ErrorCheck (buyer,avg);

		if (check == false) {
			Debug.Log ("failed check");
		} 
		else {
			if (buyer == "blk") {
				bkPay = logic.BkPay (counter, correct, maxValue);
				Debug.Log ("Payout: " + bkPay);
			} 
			else {
				pay = logic.Payout (buyer, avg, maxValue);
				Debug.Log ("Payout: " + pay);
			}
		}

		highButton.interactable = false;
		medButton.interactable = false;
		lowButton.interactable = false;
		blkButton.interactable = false;
	}
}
