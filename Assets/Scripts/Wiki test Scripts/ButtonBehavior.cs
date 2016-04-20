using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

    //public Renderer rend;

    // Use this for initialization
    void Start () {
        //rend = GetComponent<Renderer>();
        SetInvisible();
    }

    public void SetVisible()
    {
        if (gameObject.activeSelf == true)
            gameObject.SetActive(false);
        //rend.enabled = true;
        else
            gameObject.SetActive(true);

    }
    public void SetInvisible()
    {
        //rend.enabled = false;
        gameObject.SetActive(false);
    }
}
