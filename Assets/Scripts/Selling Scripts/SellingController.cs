using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SellingController : MonoBehaviour {

	public int maxValue;
	public float m1, m2, m3, m4, m5, m6;
	public string buyer;
	public float avg;
	public SellingLogic logic;
	public bool check;
	public bool counter;
	public int correct;
	public int Pay;
	public PersistVars vars;
	public GameObject highText;
	public GameObject medText;
	public GameObject lowText;
	public GameObject blkText;
	public Button highButton;
	public Button medButton;
	public Button lowButton;
	public Button blkButton;
	public DialogueReader reader;

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
		maxValue = PersistVars.maxValue[PersistVars.paintingNum-1];
		PersistVars.currentScene = "SellingScene";

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
		highButton.interactable = false;
		medButton.interactable = false;
		lowButton.interactable = false;
		blkButton.interactable = false;

		Color highlight = new Color ();
		ColorUtility.TryParseHtmlString ("#69D63A54", out highlight);

		if (bName == "cButtonH") {
			highButton.GetComponent<Image>().color = highlight;
			buyer = "high";
		} 
		else if (bName == "cButtonM") {
			medButton.GetComponent<Image>().color = highlight;
			buyer = "med";
		}
		else if (bName == "cButtonL") {
			lowButton.GetComponent<Image>().color = highlight;
			buyer = "low";
		}
		else if (bName == "cButtonB") {
			blkButton.GetComponent<Image>().color = highlight;
			buyer = "blk";
		}
		check = logic.ErrorCheck (buyer, avg);
		Pay = logic.Payout (buyer,avg,maxValue);
		reader.NextLine ();
	}

	public void bReset() {
		Color clear = new Color ();
		ColorUtility.TryParseHtmlString ("#FFFFFF00", out clear);

		highButton.interactable = true;
		medButton.interactable = true;
		lowButton.interactable = true;
		blkButton.interactable = true;
		highButton.GetComponent<Image>().color = clear;
		medButton.GetComponent<Image>().color = clear;
		lowButton.GetComponent<Image>().color = clear;
		blkButton.GetComponent<Image>().color = clear;
	}
}
