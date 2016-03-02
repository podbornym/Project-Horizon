using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testButtonUI : MonoBehaviour {

    bool expandMenu = false;
    public Image piece1;
    public Image piece2;
    public Image piece3;
    public Image piece4;

    // Use this for initialization
    void Start () {
        piece1.enabled = false;
        piece2.enabled = false;
        piece3.enabled = false;
        piece4.enabled = false;
        Vector3 piece1.rectTransform.position + new Vector3(0, 20, 0);
    }
	
	public void ExpandMenu()
    {
        if (!expandMenu)
        {
            expandMenu = true;
        }
        else
        {
            expandMenu = false;
        }
    }

    void Update()
    {
        if(expandMenu)
        {

            piece1.enabled = true;
            piece1.rectTransform.position = Vector3.MoveTowards(piece1.rectTransform.position, piece1.rectTransform.position + new Vector3(0, 5, 0), Time.deltaTime * 100);
        }
    }
}
