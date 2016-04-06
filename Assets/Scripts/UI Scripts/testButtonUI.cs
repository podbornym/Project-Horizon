using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testButtonUI : MonoBehaviour
{

    bool expandMenu = false;
    public Image flyup;
    Vector3 movePiece1;
    Vector3 returnPiece1;

    // Use this for initialization
    void Start()
    {
    }

    public void ExpandMenu()
    {
        if (!expandMenu)
        {
            expandMenu = true;
            flyup.GetComponent<Image>().enabled = true;
        }
        else
        {
            expandMenu = false;
            StartCoroutine(returnPiece());
        }
    }

    IEnumerator returnPiece()
    {
        yield return new WaitForSeconds(1);
        flyup.GetComponent<Image>().enabled = false;
    }
}