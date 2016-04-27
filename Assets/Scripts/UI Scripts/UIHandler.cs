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
    public Vector3 startPos;
    public GameObject WikiPrefab;
    public Text WikiButtonText;

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
            GoBack();
            //SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIALive)
            {
                HideMenu();
                UIALive = false;
            }
            else
            {
                UnhideMenu();
                UIALive = true;
            }
        }
    }

    public void GoBack()
    {
        if (PersistVars.previousScene != null)
        {
            SceneManager.LoadScene(PersistVars.previousScene);
        }
        if (!gameObject.GetComponent<Canvas>().enabled)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        switch (PersistVars.previousScene)
        {
            case "mansion":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Mansion");
                break;
            case "SurrealistZone":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Surrealist Zone");
                break;
            case "BaroqueZone":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Baroque Zone");
                break;
            case "Ukiyo-eZone":
                GameObject.Find("GENERALUI").GetComponent<UIHandler>().SetLocationText("Ukiyo-e Zone");
                break;
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
        if (PersistVars.currentScene != "mansion")
        {
            PersistVars.previousScene = SceneManager.GetActiveScene().name;
            PersistVars.currentScene = "mansion";
            PersistVars.returningToHome = true;
            PersistVars.Ukiyo = false;
            PersistVars.Surreal = false;
            PersistVars.Baroque = false;
            GameObject.Find("RenPortExcite").GetComponent<Image>().enabled = true;
            ExpandMenu();
            gameObject.GetComponent<AudioSource>().clip = null;
            SceneManager.LoadScene("mansion");
        }
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

    public void SetLocationText(string locText)
    {
        GameObject.Find("Location").GetComponent<Text>().text = locText;
    }

    public void SetPieceInfo(string pieceInfo)
    {
        GameObject.Find("Art Piece").GetComponent<Text>().text = pieceInfo;
    }

    public void ChangePaintingInfo()
    {
        print("In change painting info");
        switch(PersistVars.paintingNum)
        {
            case 1:
                SetPieceInfo("3 Beauties of the Present Day\n1793, Kitagawa Utamaro");
                break;
            case 2:
                SetPieceInfo("Fifty-Three Stations of the Tokaido\n1833, Utagawa Hiroshige");
                break;
            case 3:
                SetPieceInfo("The Great Wave off the Coast of Kanagawa\n1831, Katsushika Hokusai");
                break;
            case 4:
                SetPieceInfo("Shoki Striding\nc. 1741-51, Okumura Masanobu");
                break;
            case 5:
                SetPieceInfo("Sudden Shower over Shin-Ohashi Bridge and Atake\n,1857, Utagawa Hiroshige ");
                break;
            case 6:
                SetPieceInfo("Yakko Edobei\n1794, Toshusai Sharaku");
                break;
            case 7:
                SetPieceInfo("Through Birds Through Fire But Not Through Glass\n1943, Yves Tanguy");
                break;
            case 8:
                SetPieceInfo("Turin Spring\n1914, Giorgio de Chirico");
                break;
            case 9:
                SetPieceInfo("Alla Cuelga mi Vestido\n1933, Frida Kahlo");
                break;
            case 10:
                SetPieceInfo("The Slug Room\n1920, Max Ernst");
                break;
            case 11:
                SetPieceInfo("Tristan and Isolde\n1944, Salvador Dali");
                break;
            case 12:
                SetPieceInfo("The Healer\n1937, Rene Magritte");
                break;
            case 13:
                SetPieceInfo("The Three Trees\n1643, Rembrant Harmenszoon van Rijn");
                break;
            case 14:
                SetPieceInfo("The Board Partition with Letter Rack and Music Book\n1668, Cornelius Norbertus Gijsbrechts");
                break;
            case 15:
                SetPieceInfo("The Entombment of Christ\nc. 1603-04, Michelangelo Merisi da Caravaggio");
                break;
            case 16:
                SetPieceInfo("Bouquet of Flowers in a Glass Vase\n1685, Maria Van Oosterwijck");
                break;
            case 17:
                SetPieceInfo("Christ Preaching\n1652, Rembrant Harmenszoon van Rijn");
                break;
            case 18:
                SetPieceInfo("Rape of Persephone\n1622, Gian Lorenzo Bernini");
                break;
            default:
                print("did not start a valid painting");
                break;
        }
    }

    public void UnhideMenu()
    {
        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = true;
        GameObject.Find("UIUnhide").GetComponent<Image>().enabled = false;
    }

    public void HideMenu()
    {
        GameObject.Find("GENERALUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("UIUnhide").GetComponent<Image>().enabled = true;
    }

    public void openWiki()
    {
        if (GameObject.Find("Wiki_Prefab(Clone)") == null)
        {
            Instantiate(WikiPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            WikiButtonText.text = "Close Wiki";
        }
        else
        {
            GameObject destroyWiki = GameObject.Find("Wiki_Prefab(Clone)");
            Destroy(destroyWiki);
            WikiButtonText.text = "Launch Wiki";
        }

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
