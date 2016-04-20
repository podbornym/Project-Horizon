using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public bool UIALive = true;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PersistVars.previousScene != null)
            {
                SceneManager.LoadScene(PersistVars.previousScene);
            }
            if (!gameObject.GetComponent<Canvas>().enabled)
            {
                gameObject.GetComponent<Canvas>().enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIALive)
            {
                gameObject.GetComponent<Canvas>().enabled = false;
                UIALive = false;
            }
            else
            {
                gameObject.GetComponent<Canvas>().enabled = true;
                UIALive = true;
            }
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
        PersistVars.previousScene = SceneManager.GetActiveScene().name;
        PersistVars.currentScene = "mansion";
        PersistVars.returningToHome = true;
        PersistVars.Ukiyo = false;
        PersistVars.Surreal = false;
        PersistVars.Baroque = false;
        GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = true;
        ExpandMenu();
        SceneManager.LoadScene("mansion");

    }

    public void PortalComingSoon()
    {
        GameObject.Find("PortalComingSoon").GetComponent<Image>().enabled = true;
        GameObject.Find("PortalText").GetComponent<Text>().enabled = true;
        StartCoroutine(PortalTextWait());
    }

    IEnumerator PortalTextWait()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("PortalComingSoon").GetComponent<Image>().enabled = false;
        GameObject.Find("PortalText").GetComponent<Text>().enabled = false;
    }

	public void SellClick()
	{
		sellName = EventSystem.current.currentSelectedGameObject.name;
		sellC.bHandle (sellName);
	}

    public void QuitToDesktop()
    {
        Application.Quit();
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
