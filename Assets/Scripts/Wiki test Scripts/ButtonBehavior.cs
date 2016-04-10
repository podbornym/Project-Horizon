using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        SetInvisible();
    }

    public void SetVisible()
    {
        rend.enabled = true;
        gameObject.SetActive(true);

    }
    public void SetInvisible()
    {
        rend.enabled = false;
        gameObject.SetActive(false);
    }
}
