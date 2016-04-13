using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour {
    //we can use this script for storing stating vars that we want to persist across scene changes
    //will be used to both store these vars and handle changes within the UI
    private static bool createUI = true;
    public string testString = "";
    public bool expanded = false;
    public GameObject flyupMenu;
    public GameObject MoveToPos;
    public float offsetY;
	public SellingController sellC;
	public string sellName;

    void Awake()
    {
        if (createUI)
        {
            createUI = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void ExpandMenu()
    {
        if (!expanded)
        {
            offsetY = Mathf.Abs(flyupMenu.transform.position.y) + Mathf.Abs(MoveToPos.transform.position.y);
            iTween.MoveTo(flyupMenu, iTween.Hash("position", new Vector3(flyupMenu.transform.position.x, MoveToPos.transform.position.y, flyupMenu.transform.position.z), "speed", 300, "easetype", "linear"));
            expanded = true;
        }
        else
        {
            iTween.MoveTo(flyupMenu, iTween.Hash("position", new Vector3(flyupMenu.transform.position.x, MoveToPos.transform.position.y - offsetY, flyupMenu.transform.position.z), "speed", 300, "easetype", "linear"));
            expanded = false;
        }
    }

    public void goToHome()
    {
        PersistVars.returningToHome = true;
        SceneManager.LoadScene("mansion");
    }

	public void SellClick()
	{
		sellName = EventSystem.current.currentSelectedGameObject.name;
		sellC.bHandle (sellName);
	}

    /*void menuOpen()
    {
        expanded = true;
    }

    void menuClosed()
    {
        expanded = false;
    }*/
}
