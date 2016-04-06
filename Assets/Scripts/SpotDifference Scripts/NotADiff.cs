using UnityEngine;
using System.Collections;

public class NotADiff : MonoBehaviour
{

    public static float penaltyTime = -1;
    bool foundAll = SpotTheDiffManager.foundAll;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // After a penalty, wait half a second before changing the timer's color back to white
        if (penaltyTime != -1 && penaltyTime - SpotTheDiffManager.seconds >= 0.5)
        {
            SpotTheDiffManager.timeCounter.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        if (SpotTheDiffManager.seconds > 0 && !foundAll)
        {
            SpotTheDiffManager.seconds--;

            // Change the timer's color to red upon getting a penalty
            SpotTheDiffManager.timeCounter.color = Color.red;
            penaltyTime = SpotTheDiffManager.seconds;
        }


    }
}
