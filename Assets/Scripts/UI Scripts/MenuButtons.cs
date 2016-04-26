using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public Texture2D newCursor;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = new Vector2(30, 30);

    void Start()
    {
        Cursor.SetCursor(newCursor, hotSpot, cursorMode);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("mansion");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void OverviewButton()
    {
        SceneManager.LoadScene("OverView");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void CreditsNext()
    {
        SceneManager.LoadScene("CreditsSecond");
    }
}
