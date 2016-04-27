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
	public GameObject highText;
	public GameObject medText;
	public GameObject lowText;
	public GameObject blkText;
	public Button highButton;
	public Button medButton;
	public Button lowButton;
	public Button blkButton;
	public DialogueReader reader;
	public string blockedClient;
	public GameObject UI;

	// Use this for initialization
	void Start () {
		UI = GameObject.Find ("GENERALUI");
		// Setting variables
		counter = true;
		m1 = UI.GetComponent<PersistVars>().match3Score;
		m2 = UI.GetComponent<PersistVars>().rotatoScore;
		m3 = UI.GetComponent<PersistVars>().pipeDreamScore;
		m4 = UI.GetComponent<PersistVars>().tracerScore;
		m5 = UI.GetComponent<PersistVars>().findDiffScore;
		m6 = UI.GetComponent<PersistVars>().mastermindScore;
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

		Color block = new Color ();
		ColorUtility.TryParseHtmlString ("#888888CC", out block);

		blockedClient = PersistVars.blocked[PersistVars.paintingNum-1];

		if (blockedClient=="high")
		{
			highButton.interactable = false;
			highButton.GetComponent<Image>().color = block;
		}
		if (blockedClient=="med")
		{
			medButton.interactable = false;
			medButton.GetComponent<Image>().color = block;
		}
		if (blockedClient=="low")
		{
			lowButton.interactable = false;
			lowButton.GetComponent<Image>().color = block;
		}
		if (blockedClient=="blk" || (PersistVars.paintingNum>6 && PersistVars.paintingNum<13))
		{
			blkButton.interactable = false;
			blkButton.GetComponent<Image>().color = block;
		}
			
		highButton.GetComponent<Button>().onClick.AddListener(() => {UI.GetComponent<UIHandler>().SellClick();});
		medButton.GetComponent<Button>().onClick.AddListener(() => {UI.GetComponent<UIHandler>().SellClick();});
		lowButton.GetComponent<Button>().onClick.AddListener(() => {UI.GetComponent<UIHandler>().SellClick();});
		blkButton.GetComponent<Button>().onClick.AddListener(() => {UI.GetComponent<UIHandler>().SellClick();});
	}

	public void bHandle(string bName) {
		Debug.Log ("bhandle");
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
		UI.GetComponent<DialogueReader> ().NextLine ();
		//reader.NextLine ();
	}

	public void bReset() {
		Color clear = new Color ();
		ColorUtility.TryParseHtmlString ("#FFFFFF00", out clear);

		if (blockedClient!="high")
		{
			highButton.interactable = true;
			highButton.GetComponent<Image>().color = clear;
		}
		if (blockedClient!="med")
		{
			medButton.interactable = true;
			medButton.GetComponent<Image>().color = clear;
		}
		if (blockedClient!="low")
		{
			lowButton.interactable = true;
			lowButton.GetComponent<Image>().color = clear;
		}
		if (blockedClient!="blk" && (PersistVars.paintingNum<7))
		{
			blkButton.interactable = true;
			blkButton.GetComponent<Image>().color = clear;
		}
	}
}
