using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class traceScript : MonoBehaviour {

    public float timeRemaining = 2f;
    public Text sub;
    public Text time;
    public Text tabs;
    public string introText;
    public int tabsLeft = 5;

    public GameObject LineReader;
    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {

        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            time.text = "Time Remaining: " + (timeRemaining).ToString("n2");
            /*ILineReader.GetComponent<MatchThreeManager>().firstHit = false;
            LineReader.GetComponent<MatchThreeManager>().lastHit = false;*/

        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            sub.text = "Go!";
            time.text = " ";
        }

        /*if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }*/

        if (Input.GetKeyDown("tab"))
        {
            if(tabsLeft > 0)
            {
                tabsLeft--;
                tabs.text = "Tabs left: " + tabsLeft.ToString();
                timeRemaining = 2f;
                sub.text = introText;
                gameObject.GetComponent<Renderer>().enabled = true;
            }

            else
            {
                timeRemaining = 0f;
                LineReader.GetComponent<traceLayoutManager>().CalculateScore();
            }
        }

        /*if (Input.GetKeyUp("tab"))
        {
            print("no left shift, better make it invisible");
            gameObject.GetComponent<Renderer>().enabled = false;
        }*/
        // if tab is down, don't let the player trace

    }
}
