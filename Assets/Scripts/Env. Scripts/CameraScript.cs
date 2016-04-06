using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    GameObject cam;
    float mansionCamOffset = 20.54f;
    float surrealCamOffset = 20.45f;
    float baroqueCamOffset = 11.65f;
    float ukiyoCamOffset = 5f;

    public float offsetInUse = 0.0f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera");

        string activeScene = SceneManager.GetActiveScene().name;

        switch (activeScene)
        {
            case "mansion":
                offsetInUse = mansionCamOffset;
                break;
            case "SurrealistZone":
                offsetInUse = surrealCamOffset;
                break;
            case "BaroqueZone":
                offsetInUse = baroqueCamOffset;
                break;
            case "UkiyoeZone":
                offsetInUse = ukiyoCamOffset;
                break;
            default:
                print("no valid scene for cam movement was loaded");
                break;
        }
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if(gameObject.tag == "column")
            {
                if (gameObject.transform.position.x < player.transform.position.x)
                {
                    float moveCam = cam.transform.position.x - offsetInUse;
                    iTween.MoveTo(cam, iTween.Hash("position", new Vector3(moveCam, cam.transform.position.y, cam.transform.position.z), "speed", 10, "easetype", "linear"));
                }
                else
                {
                    float moveCam = cam.transform.position.x + offsetInUse;
                    iTween.MoveTo(cam, iTween.Hash("position", new Vector3(moveCam, cam.transform.position.y, cam.transform.position.z), "speed", 10, "easetype", "linear"));
                }
            }
        }
    }
}