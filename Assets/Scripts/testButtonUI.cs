using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testButtonUI : MonoBehaviour {

    bool expandMenu = false;
    public Image piece1;
    public Image piece2;
    public Image piece3;
    public Image piece4;
    Vector3 movePiece1;
    Vector3 returnPiece1;

    // Use this for initialization
    void Start () {
        piece1.enabled = false;
        piece2.enabled = false;
        piece3.enabled = false;
        piece4.enabled = false;
        movePiece1 = piece1.rectTransform.position + new Vector3(0, 100, 0);
        returnPiece1 = piece1.rectTransform.position;
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
            StartCoroutine(returnPiece());
        }
    }

    void Update()
    {
        if(expandMenu)
        {
            piece1.enabled = true;
            piece1.rectTransform.position = Vector3.MoveTowards(piece1.rectTransform.position, movePiece1, Time.deltaTime * 100);
        }
        if(!expandMenu)
        {
            piece1.rectTransform.position = Vector3.MoveTowards(piece1.rectTransform.position, returnPiece1, Time.deltaTime * 100);
            
        }
    }

    IEnumerator returnPiece()
    {
        yield return new WaitForSeconds(1);
        piece1.enabled = false;
    }
}
