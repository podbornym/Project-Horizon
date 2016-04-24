﻿using UnityEngine;
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
            switch(PersistVars.previousScene)
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
        switch(PersistVars.paintingNum)
        {
            case 1:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 2:
                SetPieceInfo("3 Beauties of the Present Day\n1793, Kitagawa Utamaro");
                break;
            case 3:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 4:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 5:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 6:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 7:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 8:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 9:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 10:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 11:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 12:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 13:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 14:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 15:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 16:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 17:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
                break;
            case 18:
                SetPieceInfo("3 Beauties of the Present Day\nc. 1792-93, Kitagawa Utamaro");
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
        }
        else
        {
            GameObject destroyWiki = GameObject.Find("Wiki_Prefab(Clone)");
            Destroy(destroyWiki);
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
